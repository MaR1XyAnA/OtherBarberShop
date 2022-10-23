using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class NewWorkerPage : Page
    {
        public NewWorkerPage()
        {
            InitializeComponent();
            RoleNewComboBox.ItemsSource = AppConnectModelClass.DataBase.RoleTable.ToList();
            PaulNewComboBox.ItemsSource = AppConnectModelClass.DataBase.PaulTable.ToList();
        }

        private void ClearText()
        {
            SurnameNewTextBox.Text = "";
            MiddlenameNewTextBox.Text = "";
            NameNewTextBox.Text = "";
            RoleNewComboBox.Text = "";
            LoginNewTextBox.Text = "";
            PasswordNewTextBox.Text = "";
            PaulNewComboBox.Text = "";
        }

        private void NewSaveWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            if(
                SurnameNewTextBox.Text != "" &&
                MiddlenameNewTextBox.Text != "" &&
                NameNewTextBox.Text != "" &&
                RoleNewComboBox.Text != "" &&
                LoginNewTextBox.Text != "" &&
                PasswordNewTextBox.Text != "" &&
                PaulNewComboBox.Text != "")
            {
                if (AppConnectModelClass.DataBase.WorkerTable.Count(
                    data => data.SurnameWorker == SurnameNewTextBox.Text && 
                            data.NameWorker == NameNewTextBox.Text) > 0)
                {
                    MessageBox.Show(
                        "Данный сотрудник уже существует",
                        "Ошибка добавления",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }
                else
                {
                    WorkerTable workerTable = new WorkerTable()
                    {
                        SurnameWorker = SurnameNewTextBox.Text,
                        NameWorker = NameNewTextBox.Text,
                        MiddlenameWorker = MiddlenameNewTextBox.Text,
                        RoleWorker = RoleNewComboBox.Text,
                        LoginWorker = LoginNewTextBox.Text,
                        PasswordWorker = PasswordNewTextBox.Text,
                        PaulWorker = PaulNewComboBox.Text
                    };
                    AppConnectModelClass.DataBase.WorkerTable.Add(workerTable);
                    AppConnectModelClass.DataBase.SaveChanges();
                    MessageBox.Show(
                        "Новый сотрудник успешно добавлен",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    ClearText();
                }
            }
            else
            {
                MessageBox.Show(
                    "Все поля должны быть заполнены", 
                    "Ошибка добавления", 
                    MessageBoxButton.OK, 
                    MessageBoxImage.Information);
            }
        }
    }
}
