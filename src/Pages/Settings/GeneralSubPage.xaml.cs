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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSA_WPF.Pages.Settings
{
    /// <summary>
    /// Interaction logic for GeneralSubPage.xaml
    /// </summary>
    public partial class GeneralSubPage : Page
    {
        public GeneralSubPage()
        {
            InitializeComponent();
            Theme.SelectedIndex = 2;
            Clipboard.SelectedIndex = 2;
            KeyLenght.SelectedIndex = 2;
        }

        private void Theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Theme
            if (SystemTheme.IsSelected == true)
            {
                SystemTheme.Visibility = Visibility.Collapsed;
            }
            else
            {
                SystemTheme.Visibility = Visibility.Visible;
            }

            if (LightTheme.IsSelected == true)
            {
                LightTheme.Visibility = Visibility.Collapsed;
            }
            else
            {
                LightTheme.Visibility = Visibility.Visible;
            }

            if (DarkTheme.IsSelected == true)
            {
                DarkTheme.Visibility = Visibility.Collapsed;
            }
            else
            {
                DarkTheme.Visibility = Visibility.Visible;
            }
            #endregion

            #region Clipboard
            if (Never.IsSelected == true)
            {
                Never.Visibility = Visibility.Collapsed;
            }
            else
            {
                Never.Visibility = Visibility.Visible;
            }

            if (Fifteen.IsSelected == true)
            {
                Fifteen.Visibility = Visibility.Collapsed;
            }
            else
            {
                Fifteen.Visibility = Visibility.Visible;
            }

            if (Thirty.IsSelected == true)
            {
                Thirty.Visibility = Visibility.Collapsed;
            }
            else
            {
                Thirty.Visibility = Visibility.Visible;
            }

            if (Minute.IsSelected == true)
            {
                Minute.Visibility = Visibility.Collapsed;
            }
            else
            {
                Minute.Visibility = Visibility.Visible;
            }
            #endregion

            #region KeyLenght
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
            #endregion
        }
    }
}
