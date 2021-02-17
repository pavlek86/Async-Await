using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace Async_Await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = Stopwatch.StartNew();
            
            RunDownloadSync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: { elapsedMs }";
            
        }

        private void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            throw new Exception("Not implemented");
        }

        private List<string> GetWebsites()
        {
            List<string> output = new List<string>();

            resultWindow.Text = "";

            output.Add("https://www.google.com");
            output.Add("https://www.microsoft.com");
            output.Add("https://www.ubuntu.com");
            output.Add("https://www.github.com");
            output.Add("https://stackoverflow.com");

            return output;
        }

        private void RunDownloadSync()
        {
            List<string> websites = GetWebsites();

            foreach (string site in websites)
            {
                WebsiteDataModel results = DownloadWebsite(site);
                ReportWebsiteInfo(results);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteURL)
        {
            WebsiteDataModel output = new WebsiteDataModel();
            WebClient client = new WebClient();
            
            output.WebsiteUrl = websiteURL;
            output.WebsiteData = client.DownloadString(websiteURL);

            return output;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            resultWindow.Text += $"{ data.WebsiteUrl } downloaded: { data.WebsiteData.Length } characters long. { Environment.NewLine }";
        }
    }
}
