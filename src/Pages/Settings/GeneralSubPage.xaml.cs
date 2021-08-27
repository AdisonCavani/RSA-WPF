using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Theme;
using Update;

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
            CheckTimeUpdate();
            CheckTheme();
            CheckClipboard();
            CheckKeyLenght();
            SetLastUpdate();
        }

        private void CheckTimeUpdate()
        {
            if (Properties.Settings.Default.CheckUpdateEvery == 3)
            {
                UpdatePeriod.SelectedIndex = 0; // Set 3 days
            }
            else if (Properties.Settings.Default.CheckUpdateEvery == 7)
            {
                UpdatePeriod.SelectedIndex = 1; // Set 7 days
            }
            else if (Properties.Settings.Default.CheckUpdateEvery == 30)
            {
                UpdatePeriod.SelectedIndex = 2; // Set 30 days
            }

            else if (Properties.Settings.Default.CheckUpdateEvery == 0)
            {
                UpdatePeriod.SelectedIndex = 3; // Set never
            }
        }

        private void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == 0)
            {
                Theme.IsChecked = false; // Set light theme
                ThemeName.Text = "Light";
            }
            else if (Properties.Settings.Default.Theme == 1)
            {
                Theme.IsChecked = true; // Set dark themes
                ThemeName.Text = "Dark";
            }
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
                Clipboard.SelectedIndex = 2; // Set 30 sec
            }

            else if (Properties.Settings.Default.ClearClipboardTime == 60)
            {
                Clipboard.SelectedIndex = 3; // Set 1 min
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

        private void SetLastUpdate()
        {
            if (Properties.Settings.Default.Update == 0)
            {
                UpdateIcon.Data = Application.Current.Resources["UpToDate"] as Geometry;
                UpdateStatus.Text = "Up to date";
            }
            else if (Properties.Settings.Default.Update == 1)
            {
                UpdateIcon.Data = Application.Current.Resources["NeedUpdate"] as Geometry;
                UpdateStatus.Text = "Need update to: " + Properties.Settings.Default.LatestRelease;
            }
            else if (Properties.Settings.Default.Update == 2)
            {
                UpdateIcon.Data = Application.Current.Resources["NeedDowngrade"] as Geometry;
                UpdateStatus.Text = "Need downgrade to: " + Properties.Settings.Default.LatestRelease;
            }
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            if (Theme.IsChecked == false)
            {
                ThemeName.Text = "Light";
                Properties.Settings.Default.Theme = 0;
                Properties.Settings.Default.Save();
                GetTheme.SwitchTheme();
            }

            else if (Theme.IsChecked == true)
            {
                ThemeName.Text = "Dark";
                Properties.Settings.Default.Theme = 1;
                Properties.Settings.Default.Save();
                GetTheme.SwitchTheme();
            }
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region Settings

            if (UpdatePeriod.SelectedIndex == 0)
            {
                Properties.Settings.Default.CheckUpdateEvery = 3;
                Properties.Settings.Default.Save();
            }

            else if (UpdatePeriod.SelectedIndex == 1)
            {
                Properties.Settings.Default.CheckUpdateEvery = 7;
                Properties.Settings.Default.Save();
            }

            else if (UpdatePeriod.SelectedIndex == 2)
            {
                Properties.Settings.Default.CheckUpdateEvery = 30;
                Properties.Settings.Default.Save();
            }

            else if (UpdatePeriod.SelectedIndex == 3)
            {
                Properties.Settings.Default.CheckUpdateEvery = 0;
                Properties.Settings.Default.Save();
            }

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

            #region Update
            if (ThreeDays.IsSelected == true)
            {
                ThreeDays.Visibility = Visibility.Collapsed;
            }
            else
            {
                ThreeDays.Visibility = Visibility.Visible;
            }
            if (OneWeek.IsSelected == true)
            {
                OneWeek.Visibility = Visibility.Collapsed;
            }
            else
            {
                OneWeek.Visibility = Visibility.Visible;
            }
            if (OneMonth.IsSelected == true)
            {
                OneMonth.Visibility = Visibility.Collapsed;
            }
            else
            {
                OneMonth.Visibility = Visibility.Visible;
            }
            if (NeverUpdate.IsSelected == true)
            {
                NeverUpdate.Visibility = Visibility.Collapsed;
            }
            else
            {
                NeverUpdate.Visibility = Visibility.Visible;
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

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://github.com/AdisonCavani/RSA-WPF/releases";
            myProcess.Start();
        }
    }
}
