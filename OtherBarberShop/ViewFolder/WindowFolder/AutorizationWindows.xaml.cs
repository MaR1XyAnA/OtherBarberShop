using OtherBarberShop.ClassFolder;
using System;
using System.Linq;
using System.Windows;

namespace OtherBarberShop.ViewFolder.WindowFolder
{
    public partial class AutorizationWindows : Window
    {
        public AutorizationWindows()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
        }

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
