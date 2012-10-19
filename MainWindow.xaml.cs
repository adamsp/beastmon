using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Beastmon2;

namespace BeastmonDisplay
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
    }
}
