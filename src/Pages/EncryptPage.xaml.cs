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
using RSA;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

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

                CypherTextBox.Text = output;
            }
        }
    }
}
