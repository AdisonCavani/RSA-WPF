using RSA;
using System.Windows;
using System.Windows.Controls;

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for EncryptPage.xaml
    /// </summary>
    public partial class EncryptPage : Page
    {
        public EncryptPage()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string plainText = PlainTextBox.Text;
            string publicKey = PublicKey.Text;

            if (!string.IsNullOrEmpty(plainText) && !string.IsNullOrEmpty(publicKey))
            {
                var output = RsaEncryption.Encrypt(plainText, publicKey);

                CipherTextBox.Text = output;
            }
        }

        private void PastePublicKey(object sender, RoutedEventArgs e)
        {
            PublicKey.Text = Clipboard.GetText();
        }

        private void PastePlainText(object sender, RoutedEventArgs e)
        {
            PlainTextBox.Text += Clipboard.GetText();
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

        private void CopyCipher(object sender, RoutedEventArgs e)
        {
            string cipher = CipherTextBox.Text;

            if (!string.IsNullOrEmpty(cipher))
            {
                Clipboard.SetText(cipher);
            }
        }
    }
}
