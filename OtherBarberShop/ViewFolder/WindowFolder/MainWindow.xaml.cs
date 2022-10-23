using OtherBarberShop.ViewFolder.PageFolder;
using System.Windows;
using System.Windows.Input;

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

        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы окно перетаскивать
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно
        {
            Application.Current.Shutdown();
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e) // Для того, чтобы свернуть окно
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion
        private void ServeseButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListShopButtonPage());
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
