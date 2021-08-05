using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Toolkit.Uwp.Notifications;
using RSA;
using RSA_WPF.Properties;

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
            CheckKeyLenght(); // Default key lenght
            GenerateButton_Click(new object(), new RoutedEventArgs()); // Generate key pair
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var keyPair = await Task.Run(() => RsaEncryption.GenerateKeyPair());
            PrivateKeyTextBox.Text = keyPair.Item1;
            PublicKeyTextBox.Text = keyPair.Item2;
        }

        private void KeySize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollapseSelectedItem();

            var item = (ComboBoxItem)KeySize.SelectedValue;
            string keySize = (string)item.Content;

            // Remove all, except numbers
            Regex rgx = new Regex(@"[^\d]");
            keySize = rgx.Replace(keySize, "");

            RsaEncryption.KeyValue = int.Parse(keySize);
        }

        private async void CopyPrivateKey(object sender, RoutedEventArgs e)
        {
            string privateKey = PrivateKeyTextBox.Text;

            if (!string.IsNullOrEmpty(privateKey))
            {
                Clipboard.SetText(privateKey);

                if (Settings.Default.ClearClipboardTime != 0)
                {
                    // Show toast notification
                    new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddText("Private key was copied to clipboard")
                        .AddText($"Clipboard will automaticaly clear in {(byte)Settings.Default["ClearClipboardTime"]} seconds!")
                        .Show();

                    await Task.Delay((byte)Settings.Default["ClearClipboardTime"] * 1000); // Convert sec to ms
                    if (Clipboard.GetText() == privateKey)
                    {
                        Clipboard.Clear();
                        privateKey = string.Empty;
                    }
                }
            }
        }

        private async void CopyPublicKey(object sender, RoutedEventArgs e)
        {
            string publicKey = PublicKeyTextBox.Text;

            if (!string.IsNullOrEmpty(publicKey))
            {
                Clipboard.SetText(publicKey);

                if (Settings.Default.ClearClipboardTime != 0)
                {
                    // Show toast notification
                    new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddText("Public key was copied to clipboard")
                        .AddText($"Clipboard will automaticaly clear in {(byte)Settings.Default["ClearClipboardTime"]} seconds!")
                        .Show();

                    await Task.Delay((byte)Settings.Default["ClearClipboardTime"] * 1000); // Convert sec to ms
                    if (Clipboard.GetText() == publicKey)
                    {
                        Clipboard.Clear();
                        publicKey = string.Empty;
                    }
                }
            }
        }

        private void ClearPrivateKey(object sender, RoutedEventArgs e)
        {
            string privateKey = PrivateKeyTextBox.Text;
            PrivateKeyTextBox.Text = string.Empty;

            if (Clipboard.GetText() == privateKey)
            {
                Clipboard.Clear();
                privateKey = string.Empty;
            }
        }

        private void ClearPublicKey(object sender, RoutedEventArgs e)
        {
            string publicKey = PublicKeyTextBox.Text;
            PublicKeyTextBox.Text = string.Empty;

            if (Clipboard.GetText() == publicKey)
            {
                Clipboard.Clear();
                publicKey = string.Empty;
            }
        }

        private void CheckKeyLenght()
        {
            if (Properties.Settings.Default.KeyLenght == 512)
            {
                KeySize.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.KeyLenght == 1024)
            {
                KeySize.SelectedIndex = 1;
            }
            else if (Properties.Settings.Default.KeyLenght == 2048)
            {
                KeySize.SelectedIndex = 2;
            }

            else if (Properties.Settings.Default.KeyLenght == 3072)
            {
                KeySize.SelectedIndex = 3;
            }

            else if (Properties.Settings.Default.KeyLenght == 4096)
            {
                KeySize.SelectedIndex = 4;
            }
        }

        private void CollapseSelectedItem()
        {
            if (A.IsSelected == true)
            {
                A.Visibility = Visibility.Collapsed;
            }
            else
            {
                A.Visibility = Visibility.Visible;
            }

            if (B.IsSelected == true)
            {
                B.Visibility = Visibility.Collapsed;
            }
            else
            {
                B.Visibility = Visibility.Visible;
            }

            if (C.IsSelected == true)
            {
                C.Visibility = Visibility.Collapsed;
            }
            else
            {
                C.Visibility = Visibility.Visible;
            }

            if (D.IsSelected == true)
            {
                D.Visibility = Visibility.Collapsed;
            }
            else
            {
                D.Visibility = Visibility.Visible;
            }

            if (E.IsSelected == true)
            {
                E.Visibility = Visibility.Collapsed;
            }
            else
            {
                E.Visibility = Visibility.Visible;
            }
        }
    }
}
