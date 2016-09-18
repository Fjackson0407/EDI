using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using log4net;
using log4net.Config;
using Valid.Fulfillment.Client.ViewModels;
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Client.Views;
using Valid.Fulfillment.Common.Enums;

namespace Valid.Fulfillment.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILog _logger;
        private DateTime _runTimeStart;
        private Dictionary<string, string> _SettingsDictionary;
        private MainWindow_ViewModel _viewModel;

        public Settings AppSettings { get; set; }

        public MainWindow()
        {
            var keys = ConfigurationManager.AppSettings.AllKeys;
            _SettingsDictionary = keys.ToDictionary(key => key, key => ConfigurationManager.AppSettings.Get(key));
            AppSettings = new Settings(_SettingsDictionary);
      
            _runTimeStart = DateTime.Now;

            _logger = LogManager.GetLogger(typeof(MainWindow));
            XmlConfigurator.Configure();
            _logger.Info("Application Started");

            if (AppSettings.StartFullScreen)
            {
                WindowState = WindowState.Maximized;
            }

            InitializeComponent();

            _viewModel = new MainWindow_ViewModel(AppSettings);
            DataContext = _viewModel;
            
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

        protected void Event_WindowClosing(object sender, CancelEventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you want to Exit? Press OK to Continue", "Alert",
                    MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                var runTimeEnd = DateTime.Now;
                var ts = new TimeSpan(runTimeEnd.Ticks - _runTimeStart.Ticks);
                _logger.Info(string.Format("Application Completed - Run Time: {0:g}", ts));
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var startDate = DateTime.Now.AddDays(- (int)DateTime.Now.DayOfWeek);
            var endDate = DateTime.Now.AddDays(6 - (int)DateTime.Now.DayOfWeek);
            Dp_StartDate.SelectedDate = startDate;
            Dp_EndDate.SelectedDate = endDate;
        }

        private void Datagrid_AmexDetail_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataRow = (FulfillmentBreakdown)datagrid_AmexDetail.SelectedItem;
            var orderDetailListByDc = _viewModel.AmexOrderDetailList.Where(x => x.DCNumber == dataRow.DcNumber);
                                                                     
            var storeDetailWindow = new StoreDetailWindow(AppSettings, orderDetailListByDc, _viewModel.CurrentUser.UserName, EOrderType.Amex.ToString(), _viewModel.OrderStatus);
            storeDetailWindow.ShowDialog();
        }

        private void Datagrid_VisaMcDetail_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataRow = (FulfillmentBreakdown)datagrid_VisaMcDetail.SelectedItem;
            var orderDetailListByDc = _viewModel.VisaMcOrderDetailList.Where(x => x.DCNumber == dataRow.DcNumber);
            var storeDetailWindow = new StoreDetailWindow(AppSettings, orderDetailListByDc, _viewModel.CurrentUser.UserName, EOrderType.VisaMc.ToString(), _viewModel.OrderStatus);
            storeDetailWindow.ShowDialog();
        }

        //ToDo: This is from link to summary and may not be implemented
        private void VisaMcSummary_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var storeDetailWindow = new StoreDetailWindow(AppSettings, _viewModel.VisaMcOrderDetailList, _viewModel.CurrentUser.UserName, EOrderType.VisaMc.ToString(), _viewModel.OrderStatus);
            //storeDetailWindow.ShowDialog();
        }

        //ToDo: This is from link to summary and may not be implemented
        private void AmexSummary_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //var storeDetailWindow = new StoreDetailWindow(AppSettings, _viewModel.AmexOrderDetailList, _viewModel.CurrentUser.UserName, EOrderType.Amex.ToString(), _viewModel.OrderStatus);
            //storeDetailWindow.ShowDialog();
        }

        private void Btn_Login_OnClick(object sender, RoutedEventArgs e)
        {
            var userLoginWindow = new UserLoginWindow(AppSettings, _viewModel.LoadUserData().ToList());
            userLoginWindow.ShowDialog();
            _viewModel.CurrentUser = userLoginWindow.m_viewModel.UserInfo_SelectedItem;
            if (!string.IsNullOrEmpty(_viewModel.CurrentUser.UserName))
            {
                _viewModel.LoadButtonVisibility = Visibility.Visible;
            }
            else
            {
                _viewModel.LoadButtonVisibility = Visibility.Hidden;
            }
        }

        private void Btn_Load_OnClick(object sender, RoutedEventArgs e)
        {
            if (Dp_StartDate.SelectedDate.HasValue && Dp_EndDate.SelectedDate.HasValue)
            {
                _viewModel.SetOrderStatus(Rbtn_OpenOders.IsChecked.Value, Rbtn_ClosedOrders.IsChecked.Value);
                _viewModel.LoadOrderData(Dp_StartDate.SelectedDate.Value, Dp_EndDate.SelectedDate.Value);
            }
        }

        private void OnStatusChanged(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null && _viewModel.MasterOrderDetailList.Any())
            {
                _viewModel.SetOrderStatus(Rbtn_OpenOders.IsChecked.Value, Rbtn_ClosedOrders.IsChecked.Value);
                _viewModel.FilterOrderDetails();
            }
        }


        private void Cbox_PurchaseOrders_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_viewModel != null && _viewModel.MasterOrderDetailList.Any() && cbox_PurchaseOrders.SelectedItem != null)
            {
                var po = (PurchaseOrderInfo)cbox_PurchaseOrders.SelectedItem;
                _viewModel.SelectedPurchaseOrder = po;
                _viewModel.FilterOrderDetails();
            }
            
        }

        private void MainWindow_OnActivated(object sender, EventArgs e)
        {
            if (_viewModel != null && _viewModel.MasterOrderDetailList.Any() && cbox_PurchaseOrders.SelectedItem != null)
            {
                var po = (PurchaseOrderInfo)cbox_PurchaseOrders.SelectedItem;
                _viewModel.SelectedPurchaseOrder = po;
                _viewModel.FilterOrderDetails();
            }
        }
    }
}
