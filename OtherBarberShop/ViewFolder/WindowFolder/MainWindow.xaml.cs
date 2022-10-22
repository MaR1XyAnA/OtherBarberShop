using OtherBarberShop.ViewFolder.PageFolder;
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
using System.Windows.Shapes;

namespace OtherBarberShop.ViewFolder.WindowFolder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServeseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RecordPage());
        }

        private void WorkerButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPage());
        }
    }
}
