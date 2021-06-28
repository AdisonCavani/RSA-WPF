using System;
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

            // Loading bindings
            ProfileName = Environment.UserName;
            GetProfileImage();
        }

        private string profileName;
        public string ProfileName
        {
            get { return profileName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    profileName = value;
                }
            }
        }

        private string profileImage;

        public string ProfileImage
        {
            get { return profileImage; }
            set { profileImage = value; }
        }

        private void GetProfileImage()
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\" + Environment.UserName + ".bmp"))
            {
                ProfileImage = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\" + Environment.UserName + ".bmp";
            }
            else
            {
                ProfileImage = "\\assets\\profile1.jpg";
            }
        }

        private string closeButton_OnHover;

        public string CloseButton_OnHover
        {
            get { return closeButton_OnHover; }
            set { closeButton_OnHover = value; }
        }

        public void CloseButton_Hover()
        {
            CloseButton_OnHover = "Visible";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string minimizeButton_OnHover;

        public string MinimizeButton_OnHover
        {
            get { return minimizeButton_OnHover; }
            set { minimizeButton_OnHover = value; }
        }

        public void MinimizeButton_Hover()
        {
            MinimizeButton_OnHover = "Visible";
        }


        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
