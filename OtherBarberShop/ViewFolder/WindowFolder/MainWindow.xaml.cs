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
            WorkerButton.IsChecked = true; // Делаем кнопку "WorkerButton" активной
        }

        #region Управление окном
        private void SpaseBarGrid_MouseDown(object sender, MouseButtonEventArgs e) // Для того, что бы окно перетаскивать
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void RollUpButton_Click(object sender, RoutedEventArgs e) // Для того, чтобы свернуть окно
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) // Для того, что бы закрыть окно
        {
            AutorizationWindows autorizationWindows = new AutorizationWindows();
            autorizationWindows.Show();
            this.Close();
        }
        #endregion
        private void ServeseButton_Click(object sender, RoutedEventArgs e)
        {
            ServeseButton.IsChecked = true;
            MainFrame.Navigate(new ListShopButtonPage()); // Отурываем в окне страницу "ListShopButtonPage"
            WorkerButton.IsChecked = false; // Деактивируем кнопку "WorkerButton" при нажатии кнопки "ServeseButton"
            RecordButton.IsChecked = false; // Деактивируем кнопку "RecordButton" при нажатии кнопки "ServeseButton"
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordButton.IsChecked = true;
            MainFrame.Navigate(new RecordPage()); // Отурываем в окне страницу "RecordPage"
            WorkerButton.IsChecked = false; // Деактивируем кнопку "WorkerButton" при нажатии кнопки "RecordButton"
            ServeseButton.IsChecked = false; // Деактивируем кнопку "ServeseButton" при нажатии кнопки "RecordButton"
        }

        private void WorkerButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerButton.IsChecked = true;
            MainFrame.Navigate(new WorkerPage()); // Отурываем в окне страницу "WorkerPage"
            RecordButton.IsChecked = false; // Деактивируем кнопку "RecordButton" при нажатии кнопки "WorkerButton"
            ServeseButton.IsChecked = false; // Деактивируем кнопку "ServeseButton" при нажатии кнопки "WorkerButton"
        }
    }
}
