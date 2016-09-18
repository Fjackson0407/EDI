using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Valid.Fulfillment.Client.Views
{
    /// <summary>
    /// Interaction logic for SerialRangePrompt.xaml
    /// </summary>
    public partial class SerialRangePrompt : Window
    {
        public bool OkBtnPressed { get; set; }

        public SerialRangePrompt()
        {
            InitializeComponent();
            TboxStart.Text = "";
            TboxEnd.Text = "";
            TboxStart.Focus();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TboxStart.Text) && !string.IsNullOrEmpty(TboxEnd.Text))
            {
                OkBtnPressed = true;
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            OkBtnPressed = false;
            Close();
        }

        private void TbxDeviceId_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox == null)
            {
                return;
            }

            if (e.Text.EndsWith("/n"))
            {
                OkBtnPressed = true;
                Close();
            }

            //Only accept Letters and Numbers
            if (!e.Text.All(char.IsLetterOrDigit))
            {
                e.Handled = true;
            }

            //Limit entry to 10 characters
            if (textbox.Text.Length > 10)
            {
                e.Handled = true;
            }

            OnPreviewTextInput(e);
        }

        private void TbxDeviceId_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                OkBtnPressed = true;
                Close();
            }
        }

    }
}
