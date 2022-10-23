using OtherBarberShop.ClassFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OtherBarberShop.ViewFolder.WindowFolder
{
    public partial class AutorizationWindows : Window
    {
        public AutorizationWindows()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
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

        private void OpenWondow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Entrance(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "" && 
                PasswordPasswordBox.Password == "" || 
                LoginTextBox.Text == null && 
                PasswordPasswordBox.Password == null)
            {
                MessageBox.Show(
                    "Поле ЛОГИН или поле ПАРОЛЬ пустое", 
                    "Пустота", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
            else
            {
                try
                {
                    var user = AppConnectModelClass.DataBase.WorkerTable.FirstOrDefault(
                        data => data.LoginWorker == LoginTextBox.Text &&
                                data.PasswordWorker == PasswordPasswordBox.Password);
                    if (user == null)
                    {
                        MessageBox.Show(
                            "Неправельный ЛОГИН или ПАРОЛЬ", 
                            "Ошибка авторизации", 
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        switch (user.RoleWorker)
                        {
                            case "СА":
                                OpenWondow();
                                break;

                            default:
                                MessageBox.Show(
                                    "Отказано в доступе", 
                                    "Ошибка доступа", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Error);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex + "", 
                        "Ошибка Exception", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error);
                }
            }
        }
    }
}
