using Microsoft.Toolkit.Uwp.Notifications;
using RSA;
using RSA_WPF.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

                // Show toast notification
                new ToastContentBuilder()
                    .AddArgument("action", "viewConversation")
                    .AddArgument("conversationId", 9813)
                    .AddText("Plain text was copied to clipboard")
                    .AddText($"Clipboard will automaticaly clear in {(byte)Settings.Default["ClearClipboardTime"]} seconds!")
                    .Show();

                if ((bool)Settings.Default["ClearClipboard"] == true)
                {
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
