using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class AddEditHaircutPage : Page
    {
        StringBuilder Error = new StringBuilder(); // Создаём переменную для подсчёта ошибок
        HaircutTable haircutTable = new HaircutTable();
        public AddEditHaircutPage(HaircutTable haircutTable)
        {
            InitializeComponent();
            if (haircutTable != null)
            {
                haircutTable = haircutTable;
                DataContext = haircutTable;
            }
        }

        private void AddEdititHaircutButton_Click(object sender, RoutedEventArgs e)
        {
            //Если пустой или имеет пробелы элемент _______, то запоминаем ошибку и её контекст _________;
            if (string.IsNullOrWhiteSpace(NameHaircutTextBox.Text)) Error.AppendLine("УКАЖИТЕ НАЗВАНИЕ УСЛУГИ");
            if (string.IsNullOrWhiteSpace(PriceHaircutTextBox.Text)) Error.AppendLine("УКАЖИТЕ ЦЕНУ УСЛУГИ");
           
            if (Error.Length > 0) { MessageBox.Show(Error.ToString(), "Пустые поля"); return; } // Проверяем, нет ли у нас активных действий в Error которые проверяются в методе GetError

            
            try // Если Ok
            {
                if ( // Проверяем по ФИО и Login, существует такой же сотрудник, который пользователб хочет добавить
                    AppConnectModelClass.DataBase.WorkerTable.Count(
                        Sweep =>
                        Sweep.SurnameWorker == NameHaircutTextBox.Text &&
                        Sweep.NameWorker == PriceHaircutTextBox.Text) > 0)
                {// Если да, то предупреждаем его и чистим поля
                    MessageBox.Show("Данная услуга уже существует", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
                    GetClaer();
                    return;
                }
                else
                {
                    HaircutTable haircutTable = new HaircutTable() // Объявляем таблицу haircutTable и записываем в его отребуты данные которые ввёл пользователь в соотвнтствующие таблицы
                    {
                        NameHaircut = NameHaircutTextBox.Text,
                        PriceHaircut = int.Parse(PriceHaircutTextBox.Text)
                    };
                    AppConnectModelClass.DataBase.HaircutTable.Add(haircutTable); // Добавляем данные из haircutTable в таблицу HaircutTable
                    AppConnectModelClass.DataBase.SaveChanges(); // Сохраняем внесённые изменения в БД
                    GetClaer();
                    MessageBox.Show("Новая услуга успешно добавлен", "Добавление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception Ex) // Если ошибка Exception
            {
                MessageBox.Show(Ex.Message.ToString() + "Error Exception");
            }
        }

        private void GetClaer() // Метод, который очистит поля
        {
            NameHaircutTextBox.Text = null;
            PriceHaircutTextBox.Text = null;
        }
    }
}
