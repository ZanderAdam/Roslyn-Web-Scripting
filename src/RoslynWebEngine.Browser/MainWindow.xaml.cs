using System;
using System.IO;
using System.Windows;

namespace RoslynWebEngine.Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var curDir = Directory.GetCurrentDirectory();
            WebBrowser.Navigate(new Uri(String.Format("file:///{0}/SampleWebApp/index.html", curDir)));
        }
    }
}
