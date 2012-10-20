using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Beastmon2.Properties;
using System.ComponentModel;

namespace Beastmon2
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Beastmon.Start();
            InitializeComponent();
            browser.Navigate("http://localhost:5300");
            Closed += new EventHandler(MainWindow_Closed);
        }

        void MainWindow_Closed(object sender, EventArgs e)
        {
            Beastmon.Stop();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            Settings.Default.MainWindowPlacement = this.GetPlacement();
            Settings.Default.Save();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            this.SetPlacement(Settings.Default.MainWindowPlacement);
        }
    }
}
