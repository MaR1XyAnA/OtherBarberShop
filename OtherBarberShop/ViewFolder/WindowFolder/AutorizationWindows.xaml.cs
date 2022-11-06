using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
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
            AppConnectModelClass.DataBase = new OtherBarberShopDataBaseEntities();  
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
            WindowState = WindowState.Minimized;
        }
        #endregion

        private void OpenWindow() // Метод для открытия окна
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
                PasswordPasswordBox.Password == null) // проверка полей на пустоту в 2-х вариациях
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
                                data.PasswordWorker == PasswordPasswordBox.Password); // Получение данных для работы
                    if (user == null) // Если пользователя нет в БД
                    {
                        MessageBox.Show(
                            "Неправельный ЛОГИН или ПАРОЛЬ", 
                            "Ошибка авторизации", 
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        switch (user.PNRoleWorker)
                        {
                            case 3: // Если "Роль = 3" 
                                OpenWindow(); // Метод для открытия окна
                                break;

                            default: // Всем остальным говорим, что нельзя
                                MessageBox.Show(
                                    "Отказано в доступе", 
                                    "Ошибка доступа", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Error);
                                break;
                        }
                    }
                }
                catch (Exception ex) // Метод, который проверяет на наличае ошибок в приложении с которыми пользователь может сталкнуться при входе
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
