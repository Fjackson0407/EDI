using System.Windows;

namespace Valid.Fulfillment.Client.Views
{
    /// <summary>
    /// Interaction logic for WarningPrompt.xaml
    /// </summary>
    public partial class WarningPrompt : Window
    {
        public bool OkBtnPressed { get; set; }

        public WarningPrompt(string message, string titleString)
        {
            InitializeComponent();
            LblMessage.Content = message;
            Window_Prompt.Title = titleString;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            OkBtnPressed = true;
            Close();
        }

    }
}
