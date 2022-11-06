using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System;
using System.Linq;
using System.Text;
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
            SurnameNewTextBox.Text = ""; MiddlenameNewTextBox.Text = ""; NameNewTextBox.Text = ""; RoleNewComboBox.Text = ""; 
            LoginNewTextBox.Text = ""; PasswordNewTextBox.Text = ""; PaulNewComboBox.Text = "";
        }

        private void NewSaveWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(SurnameNewTextBox.Text)) Error.AppendLine("УКАЖИТЕ ФАМИЛИЮ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(NameNewTextBox.Text)) Error.AppendLine("УКАЖИТЕ ИМЯ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(MiddlenameNewTextBox.Text)) Error.AppendLine("УКАЖИТЕ ОТЧЕСТВО СОТРУДНИКА");
            if (RoleNewComboBox.Text == "") Error.AppendLine("УКАЖИТЕ РОЛЬ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(LoginNewTextBox.Text)) Error.AppendLine("УКАЖИТЕ ЛОГИН СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(PasswordNewTextBox.Text)) Error.AppendLine("УКАЖИТЕ ПАРОЛЬ СОТРУДНИКА");
            if (PaulNewComboBox.Text == "") Error.AppendLine("УКАЖИТЕ ПОЛ СОТРУДНИКА");
            if (Error.Length > 0)
            {
                MessageBox.Show(Error.ToString(), "ПУСТЫЕ ПОЛЯ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (AppConnectModelClass.DataBase.WorkerTable.Count(data => data.SurnameWorker == SurnameNewTextBox.Text && data.NameWorker == NameNewTextBox.Text) > 0)
                {
                    MessageBox.Show("Данный сотрудник уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    try
                    {
                        WorkerTable workerTable = new WorkerTable()
                        {
                            SurnameWorker = SurnameNewTextBox.Text,
                            NameWorker = NameNewTextBox.Text,
                            MiddlenameWorker = MiddlenameNewTextBox.Text,
                            RoleTable = RoleNewComboBox.SelectedItem as RoleTable,
                            LoginWorker = LoginNewTextBox.Text,
                            PasswordWorker = PasswordNewTextBox.Text,
                            PaulTable = PaulNewComboBox.SelectedItem as PaulTable,
                            PNImageWorker = 1
                        };
                        AppConnectModelClass.DataBase.WorkerTable.Add(workerTable);
                        AppConnectModelClass.DataBase.SaveChanges();
                        MessageBox.Show("Новый сотрудник успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearText();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "ERROR EX");
                    }
                }
            }
        }
    }
}
