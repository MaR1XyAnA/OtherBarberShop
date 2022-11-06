using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class AddHaircutPage : Page
    {
        public AddHaircutPage()
        {
            InitializeComponent();
        }

        private void ClearText() // Метод для очистки текстовых полей
        {
            NameHaircutTextBox.Text = "";
            PriceHaircutTextBox.Text = "";
        }

        private void AddHaircutButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                NameHaircutTextBox.Text != "" &&
                PriceHaircutTextBox.Text != "") // Проверка текстовых полей на пустоту
            {
                if (AppConnectModelClass.DataBase.HaircutTable.Count(
                    data => data.NameHaircut == NameHaircutTextBox.Text) > 0) // Проверка на уже существующие такие данные в БД
                {
                    MessageBox.Show(
                        "Данная причёска уже существует",
                        "Ошибка добавления",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    return;
                }
                else
                {
                    decimal Price = Convert.ToDecimal(PriceHaircutTextBox.Text); // Конверт из типа string в тип decimal
                    HaircutTable haircutTable = new HaircutTable()
                    {
                        NameHaircut = NameHaircutTextBox.Text,
                        PriceHaircut = Price
                    };
                    AppConnectModelClass.DataBase.HaircutTable.Add(haircutTable); // Запись в БД
                    AppConnectModelClass.DataBase.SaveChanges(); // Сохранение изменений в БД
                    MessageBox.Show(
                        "Новая причёска успешно добавленна",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    ClearText(); // Вызываем метод очистки полей
                    AddHaircutButton.Visibility = Visibility.Visible; // Делаем кнопку "AddHaircutButton" активной
                }
            }
        }
    }
}
