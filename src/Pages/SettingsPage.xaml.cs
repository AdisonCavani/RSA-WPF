﻿using RSA_WPF.Pages.Settings;
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

namespace RSA_WPF
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void GeneralButton_Click(object sender, MouseButtonEventArgs e)
        {
            SettingFrame.Content = new GeneralSubPage();
        }

        private void AboutButton_Click(object sender, MouseButtonEventArgs e)
        {
            SettingFrame.Content = new AboutSubPage();
        }

        private void HelpButton_Click(object sender, MouseButtonEventArgs e)
        {
            SettingFrame.Content = new HelpSubPage();
        }
    }
}
