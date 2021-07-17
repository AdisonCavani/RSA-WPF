using RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Toolkit.Uwp.Notifications;

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for GeneratePage.xaml
    /// </summary>
    public partial class GeneratePage : Page
    {
        public GeneratePage()
        {
            InitializeComponent();
            KeySize.SelectedIndex = 2; // Default key lenght - 2048
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var keyPair = RsaEncryption.GenerateKeyPair();
            PrivateKeyTextBox.Text = keyPair.Item1;
            PublicKeyTextBox.Text = keyPair.Item2;
        }

        private void KeySize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)KeySize.SelectedValue;
            string keySize = (string)item.Content;

            // Remove all, except numbers
            Regex rgx = new Regex(@"[^\d]");
            keySize = rgx.Replace(keySize, "");

            RsaEncryption.KeyValue = int.Parse(keySize);
        }

        private async void CopyPrivateKey(object sender, MouseButtonEventArgs e)
        {
            string privateKey = PrivateKeyTextBox.Text;
            Clipboard.SetText(privateKey);

            // Show toast notification
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Private key was copied to clipboard")
                .AddText("Clipboard will automaticaly clear in 15 seconds!")
                .Show();

            if (true)
            {
                await Task.Delay(15000);
                if (Clipboard.GetText() == privateKey)
                {
                    Clipboard.Clear();
                    privateKey = string.Empty;
                }
            }
        }

        private async void CopyPublicKey(object sender, MouseButtonEventArgs e)
        {
            string publicKey = PublicKeyTextBox.Text;
            Clipboard.SetText(publicKey);

            // Show toast notification
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText("Public key was copied to clipboard")
                .AddText("Clipboard will automaticaly clear in 15 seconds!")
                .Show();

            if (true)
            {
                await Task.Delay(15000);
                if (Clipboard.GetText() == publicKey)
                {
                    Clipboard.Clear();
                    publicKey = string.Empty;
                }
            }
        }
    }
}
