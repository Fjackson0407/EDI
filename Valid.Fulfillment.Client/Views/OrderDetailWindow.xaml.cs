using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Domain;
using log4net;
using log4net.Config;
using Valid.Fulfillment.Common;
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Client.ViewModels;
using Valid.Fulfillment.Client.Views;
using Valid.Fulfillment.Common.Mappers;
using Valid.Fulfillment.Data;

namespace Valid.Fulfillment.Client
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private OrderDetail_ViewModel _viewModel;
        private ScannerCapture _scanner;
        private Mapper _mapper;
        public Settings AppSettings { get; set; }
        private ILog _logger;
        

        public OrderDetailWindow(Settings settings, IEnumerable<StoreInfoFromEDI850> orderInfoList, string username)
        {
            _logger = LogManager.GetLogger(typeof(EFRepository));
            XmlConfigurator.Configure();

            AppSettings = settings;

            if (AppSettings.StartFullScreen)
            {
                WindowState = WindowState.Maximized;
            }

            InitializeComponent();
            _mapper = new Mapper();
            _viewModel = new OrderDetail_ViewModel(AppSettings, orderInfoList, username);
            _viewModel.OrderType = _mapper.MapCompanyCodeToOrderType(orderInfoList.FirstOrDefault().CompanyCode).ToString();
            DataContext = _viewModel;

            tblk_DcId.Text = orderInfoList.FirstOrDefault().DCNumber;
            tblk_Store.Text = orderInfoList.FirstOrDefault().OrderStoreNumber;
            tblk_Account.Text = orderInfoList.FirstOrDefault().PONumber;
        }

        private void Img_Logo_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(@AppSettings.ImageUri);
                b.EndInit();
                var image = sender as Image;
                image.Source = b;
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error loading Image - {0}", ex.Message));
            }
            
        }

        private void OrderDetailWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (_scanner == null)
            {
                _scanner = new ScannerCapture(this, 100,
                    EScannerCaptureUnprintableCharacters.STX,
                    EScannerCaptureUnprintableCharacters.EOT);


                _scanner.ScanComplete += ScanComplete;
                _scanner.ScanError += ScanError;
                _scanner.Enabled = true;
            }
        }

        private void OrderDetailWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (_scanner != null)
            {
                _scanner.Enabled = false;
            }

        }

        private void OrderDetailWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (_viewModel.OrderDetailGridList.Any(x => string.IsNullOrEmpty(x.Label)))
            {
                
                if (MessageBox.Show("All Carton Labels Have not been printed. Press OK to Continue", "Alert", MessageBoxButton.OKCancel) ==
                    MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ScanError(string errorMessage)
        {
            MessageBox.Show(string.Format("Scanner Error: {0}", errorMessage), "Error", MessageBoxButton.OK,
                MessageBoxImage.Exclamation);
        }

        private void ScanComplete(string scanValue)
        {
            _viewModel.StatusMessage = string.Format("Scan Received : {0}", scanValue);
            switch (scanValue.Length)
            {
                //21 is the number of characters scanned.  This could be replaced with another test if we can
                //develop a rule to determine if the scan is a serial range.
                //The default below is matching a specific value so a test is not neccesary.
                case 21:
                    if (datagrid_OrderDetail.SelectedItem != null && (_viewModel.UpcMatched == Visibility.Visible) && !_viewModel.PrintBtnEnabled)
                    {
                        _viewModel.StatusMessage = string.Format("Scan Processed as SerialRange : {0}", scanValue);
                        if (_viewModel.SerialRangeIsAvailable(_viewModel.SerialRangeToSerialList(scanValue)))
                        {
                            _viewModel.AddSerialRange(scanValue, ((StoreInfoFromEDI850) datagrid_OrderDetail.SelectedItem));
                            _viewModel.CheckReadyToPrint();
                        }
                    }
                    break;
                default:
                    if (datagrid_OrderDetail.SelectedItem != null)
                    {
                        if (scanValue == ((StoreInfoFromEDI850) datagrid_OrderDetail.SelectedItem).UPCode)
                        {
                            _viewModel.StatusMessage = string.Format("Scan Processed as matching UPC Code : {0}", scanValue);
                            _viewModel.UpcMatched = Visibility.Visible;
                            _viewModel.CheckReadyToPrint();
                        }
                    }
                    break;
            }
        }

        private void Btn_Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Reprint_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.ReprintCartonLabel();
        }

        private void Btn_Print_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.StatusMessage = string.Format("Print Button Pressed");
            var label = _viewModel.PrintCartonLabel();
            _viewModel.StatusMessage = string.Format("Print Button Pressed...Label Printed");
            _viewModel.UpdateOrders(label);
            _viewModel.StatusMessage = string.Format("Print Button Pressed...Label Printed...Order Updated");
            var prompt = new WarningPrompt("Box Label Print Complete", "Info");
            prompt.ShowDialog();
            this.Close();
        }

        private void Datagrid_OrderDetail_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagrid_OrderDetail.SelectedItem != null)
            {
                var storeOrderDetail = (StoreInfoFromEDI850)datagrid_OrderDetail.SelectedItem;
                _viewModel.StatusMessage = string.Format("Order Selection Changed : Line {0}", storeOrderDetail.CustomerLineNumber);
                _viewModel.LoadSerialRangeList(storeOrderDetail);
                _viewModel.CheckReadyToPrint();
            }
        }

        //ToDo: Make the Delete row work
        private void MenuItem_DeleteRow_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.StatusMessage = string.Format("Delete Serial Range Selected");
            //var dataRow = (Domain.SerialRageNumber) sender;
            if (datagrid_SerialRangeList.SelectedItem != null)
            {
                _viewModel.RemoveSerialRange((SerialRageNumber)datagrid_SerialRangeList.SelectedItem);
                _viewModel.CheckReadyToPrint();
            }
        }

        private void MenuItem_AddRow_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModel.StatusMessage = string.Format("Add Serial Range Selected");
            if (datagrid_OrderDetail.SelectedItem != null && !_viewModel.PrintBtnEnabled)
            {
                var prompt = new SerialRangePrompt();
                prompt.ShowDialog();
                if (prompt.OkBtnPressed)
                {
                    var value = string.Format("{0}-{1}", prompt.TboxStart.Text, prompt.TboxEnd.Text);
                    if (_viewModel.SerialRangeIsAvailable(_viewModel.SerialRangeToSerialList(value)))
                    {
                        _viewModel.AddSerialRange(value, ((StoreInfoFromEDI850)datagrid_OrderDetail.SelectedItem));
                    }
                    _viewModel.StatusMessage = string.Format("Add Serial Range Selected...{0}-{1}", prompt.TboxStart.Text, prompt.TboxEnd.Text);
                }
                _viewModel.CheckReadyToPrint();
            }
        }


    }
}
