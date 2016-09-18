using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Domain;
using log4net;
using log4net.Config;
using Valid.Fulfillment.Client.ViewModels;
using Valid.Fulfillment.Common.Enums;
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Data;
using static Helpers.EDIHelperFunctions;

namespace Valid.Fulfillment.Client.Views
{
    /// <summary>
    /// Interaction logic for StoreDetailWindow.xaml
    /// </summary>
    public partial class StoreDetailWindow : Window
    {
        private StoreDetail_ViewModel _viewModel;
        public Settings _AppSettings { get; set; }
        public EOrderStatus _OrderStatus;
        private ILog _logger;

        public StoreDetailWindow(Settings settings, IEnumerable<StoreInfoFromEDI850> OrderInfoList, string UserName, string OrderType, EOrderStatus OrderStatus)
        {
            _logger = LogManager.GetLogger(typeof(EFRepository));
            XmlConfigurator.Configure();

            _AppSettings = settings;

            if (_AppSettings.StartFullScreen)
            {
                WindowState = WindowState.Maximized;
            }

            InitializeComponent();

            _OrderStatus = OrderStatus;
            _viewModel = new StoreDetail_ViewModel(_AppSettings, OrderInfoList, UserName, OrderType, _OrderStatus);
            DataContext = _viewModel;
        }

        private void Img_Logo_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                BitmapImage b = new BitmapImage();
                b.BeginInit();
                b.UriSource = new Uri(_AppSettings.ImageUri);
                b.EndInit();
                var image = sender as Image;
                image.Source = b;
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Error loading image - {0}", ex.Message));
            }
            
        }

        private void Datagrid_StoreDetail_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            var dataRow = (StoreDetailGrid)datagrid_StoreDetail.SelectedItem;
            if (dataRow != null)
            {
                var orderDetailWindow = new OrderDetailWindow(_AppSettings,
                    _viewModel.OrderDetailList.Where(x => x.OrderStoreNumber == dataRow.StoreNumber),
                    _viewModel.CurentUser);
                orderDetailWindow.ShowDialog();
             
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            _viewModel.UpdateStoreDetailGrid();

        }
    }
}
