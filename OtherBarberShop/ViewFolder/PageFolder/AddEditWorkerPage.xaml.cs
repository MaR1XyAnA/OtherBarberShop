using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class AddEditWorkerPage : Page
    {
        private WorkerTable _workerTable = new WorkerTable();
        StringBuilder Error = new StringBuilder();
        public AddEditWorkerPage(WorkerTable SelectedWorker)
        {
            InitializeComponent();
            if (SelectedWorker != null)
            {
                _workerTable = SelectedWorker;
            }
            DataContext = _workerTable;
            RoleInformationsComboBox.ItemsSource = AppConnectModelClass.DataBase().RoleTable.ToList();
            PaulInformationsComboBox.ItemsSource = AppConnectModelClass.DataBase().PaulTable.ToList();
        }

        private void ClearText()
        {
            SurnameInformationsTextBox.Text = ""; MiddlenameInformationsTextBox.Text = ""; NameInformationsTextBox.Text = ""; RoleInformationsComboBox.Text = "";
            LoginInformationsTextBox.Text = ""; PasswordInformationsTextBox.Text = ""; PaulInformationsComboBox.Text = "";
        }

        private void GetWorker()
        {
            GetError();
            if (Error.Length > 0)
            {
                MessageBox.Show(Error.ToString(), "ПУСТЫЕ ПОЛЯ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (AppConnectModelClass.DataBase().WorkerTable.Count(data => data.SurnameWorker == SurnameInformationsTextBox.Text && data.NameWorker == NameInformationsTextBox.Text && data.MiddlenameWorker == MiddlenameInformationsTextBox.Text) > 0)
            {
                MessageBox.Show("Данный сотрудник уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    AppConnectModelClass.DataBase().SaveChanges();
                    MessageBox.Show("Новый сотрудник успешно добавлен", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearText();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "ERROR EX");
                }
            }
        }

        public void GetError()
        {
            if (string.IsNullOrWhiteSpace(NameInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ФАМИЛИЮ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(NameInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ИМЯ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(MiddlenameInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ОТЧЕСТВО СОТРУДНИКА");
            if (RoleInformationsComboBox.Text == "") Error.AppendLine("УКАЖИТЕ РОЛЬ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(LoginInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ЛОГИН СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(PasswordInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ПАРОЛЬ СОТРУДНИКА");
            if (PaulInformationsComboBox.Text == "") Error.AppendLine("УКАЖИТЕ ПОЛ СОТРУДНИКА");
        }

        public void SaveTable()
        {
            WorkerTable workerTable = new WorkerTable()
            {
                SurnameWorker = SurnameInformationsTextBox.Text,
                NameWorker = NameInformationsTextBox.Text,
                MiddlenameWorker = MiddlenameInformationsTextBox.Text,
                RoleTable = RoleInformationsComboBox.SelectedItem as RoleTable,
                LoginWorker = LoginInformationsTextBox.Text,
                PasswordWorker = PasswordInformationsTextBox.Text,
                PaulTable = PaulInformationsComboBox.SelectedItem as PaulTable,
                PNImageWorker = 1
            };
            AppConnectModelClass.DataBase().WorkerTable.Add(workerTable);
        }

        private void SaveWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            GetWorker();
        }
    }
}
