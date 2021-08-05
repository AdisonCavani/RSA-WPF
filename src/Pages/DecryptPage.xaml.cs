using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Notifications;
using RSA;
using RSA_WPF.Properties;

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for DecryptPage.xaml
    /// </summary>
    public partial class DecryptPage : Page
    {
        public DecryptPage()
        {
            InitializeComponent();
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string cipherText = CipherTextBox.Text;
            string privateKey = PrivateKey.Text;

            if (!string.IsNullOrEmpty(cipherText) && !string.IsNullOrEmpty(privateKey))
            {
                var output = RsaEncryption.Decrypt(cipherText, privateKey);

                PlainTextBox.Text = output;
            }
        }

        private void PastePrivateKey(object sender, RoutedEventArgs e)
        {
            PrivateKey.Text = Clipboard.GetText();
            Clipboard.Clear();
        }

        private void ClearPrivateKey(object sender, RoutedEventArgs e)
        {
            string privateKey = PlainTextBox.Text;
            PlainTextBox.Text = string.Empty;

            if (Clipboard.GetText() == privateKey)
            {
                Clipboard.Clear();
                privateKey = string.Empty;
            }
        }

        private void PasteCipher(object sender, RoutedEventArgs e)
        {
            CipherTextBox.Text = Clipboard.GetText();
        }

        private void ClearCipher(object sender, RoutedEventArgs e)
        {
            string cipher = CipherTextBox.Text;
            CipherTextBox.Text = string.Empty;

            if (Clipboard.GetText() == cipher)
            {
                Clipboard.Clear();
                cipher = string.Empty;
            }
        }

        private async void CopyPlainText(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextBox.Text;

            if (!string.IsNullOrEmpty(plainText))
            {
                Clipboard.SetText(plainText);

                if (Settings.Default.ClearClipboardTime != 0)
                {
                    // Show toast notification
                    new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddText("Plain text was copied to clipboard")
                        .AddText($"Clipboard will automaticaly clear in {(byte)Settings.Default["ClearClipboardTime"]} seconds!")
                        .Show();

                    await Task.Delay((byte)Settings.Default["ClearClipboardTime"] * 1000); // Convert sec to ms
                    if (Clipboard.GetText() == plainText)
                    {
                        Clipboard.Clear();
                        plainText = string.Empty;
                    }
                }
            }
        }

        private void ClearPlainText(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextBox.Text;
            PlainTextBox.Text = string.Empty;

            if (Clipboard.GetText() == plainText)
            {
                Clipboard.Clear();
                plainText = string.Empty;
            }
        }
    }
}
