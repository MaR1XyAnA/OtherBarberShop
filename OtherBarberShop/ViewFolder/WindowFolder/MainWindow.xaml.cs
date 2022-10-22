using OtherBarberShop.ViewFolder.PageFolder;
using System.Windows;

namespace OtherBarberShop.ViewFolder.WindowFolder
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new WorkerPage());
            WorkerButton.IsChecked = true;
        }

        private void ServeseButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerButton.IsChecked = false;
            RecordButton.IsChecked = false;
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RecordPage());
            WorkerButton.IsChecked = false;
            ServeseButton.IsChecked = false;
        }

        private void WorkerButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new WorkerPage());
            RecordButton.IsChecked = false;
            ServeseButton.IsChecked = false;
        }
    }
}
