using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class AddWorkerPage : Page
    {
        StringBuilder Error = new StringBuilder(); // Создаём переменную для подсчёта ошибок
        public AddWorkerPage()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new OtherBarberShopDataBaseEntities();
            RoleInformationsComboBox.ItemsSource = AppConnectModelClass.DataBase.RoleTable.ToList(); // Выгружваем в RoleInformationsComboBox таблицу RoleTable
            PaulInformationsComboBox.ItemsSource = AppConnectModelClass.DataBase.PaulTable.ToList(); // Выгружваем в PaulInformationsComboBox таблицу PaulTable
        }

        private void SaveWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            //Если пустой или имеет пробелы элемент _______, то запоминаем ошибку и её контекст _________;
            if (string.IsNullOrWhiteSpace(SurnameInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ФАМИЛИЮ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(NameInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ИМЯ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(MiddlenameInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ОТЧЕСТВО СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(RoleInformationsComboBox.Text)) Error.AppendLine("УКАЖИТЕ РОЛЬ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(LoginInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ЛОГИН СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(PasswordInformationsTextBox.Text)) Error.AppendLine("УКАЖИТЕ ПАРОЛЬ СОТРУДНИКА");
            if (string.IsNullOrWhiteSpace(PaulInformationsComboBox.Text)) Error.AppendLine("УКАЖИТЕ ПОЛ СОТРУДНИКА");
            if (Error.Length > 0) { MessageBox.Show(Error.ToString(), "Пустые поля"); return; } // Проверяем, нет ли у нас активных действий в Error которые проверяются в методе GetError
            
            try // Если Ok
            {
                if ( // Проверяем по ФИО и Login, существует такой же сотрудник, который пользователб хочет добавить
                    AppConnectModelClass.DataBase.WorkerTable.Count(
                        Sweep =>
                        Sweep.SurnameWorker == SurnameInformationsTextBox.Text &&
                        Sweep.NameWorker == NameInformationsTextBox.Text &&
                        Sweep.MiddlenameWorker == MiddlenameInformationsTextBox.Text &&
                        Sweep.LoginWorker == LoginInformationsTextBox.Text) > 0)
                {// Если да, то предупреждаем его и чистим поля
                    MessageBox.Show("Данный сотрудник уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    GetClaer();
                    return;
                }
                else
                {
                    WorkerTable workerTable = new WorkerTable() // Объявляем таблицу WorkerTable и записываем в его отребуты данные которые ввёл пользователь в соотвнтствующие таблицы
                    {
                        SurnameWorker = SurnameInformationsTextBox.Text,
                        NameWorker = NameInformationsTextBox.Text,
                        MiddlenameWorker = MiddlenameInformationsTextBox.Text,
                        LoginWorker = LoginInformationsTextBox.Text,
                        PasswordWorker = PasswordInformationsTextBox.Text,
                        RoleTable = RoleInformationsComboBox.SelectedItem as RoleTable,
                        PaulTable = PaulInformationsComboBox.SelectedItem as PaulTable,
                        PNImageWorker = 1
                    };
                    AppConnectModelClass.DataBase.WorkerTable.Add(workerTable); // Добавляем данные из workerTable в таблицу WorkerTable
                    AppConnectModelClass.DataBase.SaveChanges(); // Сохраняем внесённые изменения в БД
                    GetClaer();
                    MessageBox.Show("Новый сотрудник успешно добавлен", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception Ex) // Если ошибка Exception
            {
                MessageBox.Show(Ex.Message.ToString() + "Error Exception");
            }
        }

        private void GetClaer() // Метод, который очистит поля
        {
            SurnameInformationsTextBox.Text = null;
            NameInformationsTextBox.Text = null;
            MiddlenameInformationsTextBox.Text = null;
            RoleInformationsComboBox.Text = null;
            LoginInformationsTextBox.Text = null;
            PasswordInformationsTextBox.Text = null;
            PaulInformationsComboBox.Text = null;
        }
    }
}
