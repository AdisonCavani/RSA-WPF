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

        private void CopyPrivateKey(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(PrivateKeyTextBox.Text);
            //if (true)
            //{
            //    Task.Delay(15000).Wait();
            //    Clipboard.Clear();
            //}
        }

        private void CopyPublicKey(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(PublicKeyTextBox.Text);
            //if (true)
            //{
            //    Task.Delay(15000).Wait();
            //    Clipboard.Clear();
            //}
        }
    }
}
