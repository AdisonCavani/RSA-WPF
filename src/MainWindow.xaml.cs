﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            // Loading default page
            Main.Content = new EncryptPage();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            this.Close();
        }


        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void EncryptButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new EncryptPage();
        }

        private void DecryptButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new DecryptPage();
        }

        private void GenerateButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new GeneratePage();
        }

        private void SettingsButton_Click(object sender, MouseButtonEventArgs e)
        {
            Main.Content = new SettingsPage();
        }
    }
}
