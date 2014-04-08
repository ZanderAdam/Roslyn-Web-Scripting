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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace RoslynWebEngine.Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebEngine engine;

        public MainWindow()
        {
            InitializeComponent();

            var curDir = Directory.GetCurrentDirectory();
            WebBrowser.Navigate(new Uri(String.Format("file:///{0}/SampleWebApp/index.html", curDir)));

            SetupBrowserEvents();
        }

        private void SetupBrowserEvents()
        {
            WebBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        void WebBrowser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            string webRoot = Path.Combine(Directory.GetCurrentDirectory(),"SampleWebApp");
            engine = new WebEngine(WebBrowser.Document, webRoot);
        }
    }
}
