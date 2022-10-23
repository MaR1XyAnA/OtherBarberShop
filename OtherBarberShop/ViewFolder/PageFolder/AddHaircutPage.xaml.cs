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

        private void ClearText()
        {
            NameHaircutTextBox.Text = "";
            PriceHaircutTextBox.Text = "";
        }

        private void AddHaircutButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                NameHaircutTextBox.Text != "" &&
                PriceHaircutTextBox.Text != "")
            {
                if (AppConnectModelClass.DataBase.HaircutTable.Count(
                    data => data.NameHaircut == NameHaircutTextBox.Text) > 0)
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
                    decimal Price = Convert.ToDecimal(PriceHaircutTextBox.Text);
                    HaircutTable haircutTable = new HaircutTable()
                    {
                        NameHaircut = NameHaircutTextBox.Text,
                        PriceHaircut = Price
                    };
                    AppConnectModelClass.DataBase.HaircutTable.Add(haircutTable);
                    AppConnectModelClass.DataBase.SaveChanges();
                    MessageBox.Show(
                        "Новая причёска успешно добавленна",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    ClearText();
                    AddHaircutButton.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
