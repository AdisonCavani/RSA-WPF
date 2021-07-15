using RSA;
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
            string cypherText = CypherTextBox.Text;
            string privateKey = PrivateKey.Text;

            if (!string.IsNullOrEmpty(cypherText) && !string.IsNullOrEmpty(privateKey))
            {
                var output = RsaEncryption.Decrypt(cypherText, privateKey);

                PlainTextBox.Text = output;
            }
        }
    }
}
