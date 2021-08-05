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
            CheckSettings();
        }

        public void CheckSettings()
        {
            CheckClipboard();
            CheckKeyLenght();
        }

        private void CheckClipboard()
        {
            if (Properties.Settings.Default.ClearClipboardTime == 0)
            {
                Clipboard.SelectedIndex = 0; // Set never
            }
            else if (Properties.Settings.Default.ClearClipboardTime == 15)
            {
                Clipboard.SelectedIndex = 1; // Set 15 sec
            }
            else if (Properties.Settings.Default.ClearClipboardTime == 30)
            {
                Clipboard.SelectedIndex = 2;// Set 30 sec
            }

            else if (Properties.Settings.Default.ClearClipboardTime == 60)
            {
                Clipboard.SelectedIndex = 3;// Set 1 min
            }
        }

        private void CheckKeyLenght()
        {
            if (Properties.Settings.Default.KeyLenght == 512)
            {
                KeyLenght.SelectedIndex = 0; // Set 512 bit key
            }
            else if (Properties.Settings.Default.KeyLenght == 1024)
            {
                KeyLenght.SelectedIndex = 1; // Set 1024 bit key
            }
            else if (Properties.Settings.Default.KeyLenght == 2048)
            {
                KeyLenght.SelectedIndex = 2; // Set 2048 bit key
            }

            else if (Properties.Settings.Default.KeyLenght == 3072)
            {
                KeyLenght.SelectedIndex = 3; // Set 3072 bit key
            }

            else if (Properties.Settings.Default.KeyLenght == 4096)
            {
                KeyLenght.SelectedIndex = 4; // Set 4096 bit key
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Settings

            if (Clipboard.SelectedIndex == 0)
            {
                Properties.Settings.Default.ClearClipboardTime = 0;
                Properties.Settings.Default.Save();
            }

            else if (Clipboard.SelectedIndex == 1)
            {
                Properties.Settings.Default.ClearClipboardTime = 15;
                Properties.Settings.Default.Save();
            }

            else if (Clipboard.SelectedIndex == 2)
            {
                Properties.Settings.Default.ClearClipboardTime = 30;
                Properties.Settings.Default.Save();
            }

            else if (Clipboard.SelectedIndex == 3)
            {
                Properties.Settings.Default.ClearClipboardTime = 60;
                Properties.Settings.Default.Save();
            }

            if (KeyLenght.SelectedIndex == 0)
            {
                Properties.Settings.Default.KeyLenght = 512;
                Properties.Settings.Default.Save();
            }

            else if (KeyLenght.SelectedIndex == 1)
            {
                Properties.Settings.Default.KeyLenght = 1024;
                Properties.Settings.Default.Save();
            }

            else if (KeyLenght.SelectedIndex == 2)
            {
                Properties.Settings.Default.KeyLenght = 2048;
                Properties.Settings.Default.Save();
            }

            else if (KeyLenght.SelectedIndex == 3)
            {
                Properties.Settings.Default.KeyLenght = 3072;
                Properties.Settings.Default.Save();
            }

            else if (KeyLenght.SelectedIndex == 4)
            {
                Properties.Settings.Default.KeyLenght = 4096;
                Properties.Settings.Default.Save();
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
