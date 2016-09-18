using System;
using System.Collections.Generic;
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
using Valid.Fulfillment.Common.Models;
using Valid.Fulfillment.Data;

namespace Valid.Fulfillment.Client.Views
{
    /// <summary>
    /// Interaction logic for UserLoginWindow.xaml
    /// </summary>
    public partial class UserLoginWindow : Window
    {
        public UserLogin_ViewModel m_viewModel;
        public Settings AppSettings { get; set; }
        private ILog _logger;

        public UserLoginWindow(Settings settings, List<UserTable> userInfoList)
        {
            _logger = LogManager.GetLogger(typeof(EFRepository));
            XmlConfigurator.Configure();

            InitializeComponent();
            AppSettings = settings;
            m_viewModel = new UserLogin_ViewModel(userInfoList);
            DataContext = m_viewModel;
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

        private void Cbox_User_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = (ComboBox)sender;
            m_viewModel.UserInfo_SelectedItem = (UserTable)cb.SelectedValue;
        }

        private void Btn_Login_OnClick(object sender, RoutedEventArgs e)
        {
            if (m_viewModel.ValidatePassword(Tbox_Password.Password))
            {
                this.Close();
            }
            Lbl_Error.Visibility = Visibility.Visible;
        }

        private void Btn_Logout_OnClick(object sender, RoutedEventArgs e)
        {
            m_viewModel.UserInfo_SelectedItem = new UserTable();
            this.Close();
        }



        private void Tbx_Password_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox == null)
            {
                return;
            }

            if (e.Text.EndsWith("/n"))
            {
                Btn_Login_OnClick(null, null);
            }

            //Only accept Letters and Numbers
            //if (!e.Text.All(char.IsLetterOrDigit))
            //{
            //    e.Handled = true;
            //}

            //Limit entry to 10 characters
            //if (textbox.Text.Length > 10)
            //{
            //    e.Handled = true;
            //}

            OnPreviewTextInput(e);
        }

        private void Tbx_Password_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Btn_Login_OnClick(null, null);
            }
        }

    }
}

