using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class ListShopButtonPage : Page
    {
        public ListShopButtonPage()
        {
            InitializeComponent();
            List();
        }

        private void List()
        {
            ListShopButtonListBox.ItemsSource = AppConnectModelClass.DataBase.HaircutTable.ToList();
        }

        private void HaircutButton_Click(object sender, RoutedEventArgs e)
        {
            HaircutFrame.Navigate(new AddHaircutPage());
            ListShopButtonListBox.Visibility = Visibility.Collapsed;
            HaircutStackPanel.Visibility = Visibility.Visible;
            NewHaircutButton.Visibility = Visibility.Collapsed;
        }

        private void ListShopButtonListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HaircutTable haircutTable = (HaircutTable)ListShopButtonListBox.SelectedItem;
            HaircutFrame.Navigate(new EdditHaircutPage(haircutTable));
            ListShopButtonListBox.Visibility = Visibility.Collapsed;
            HaircutStackPanel.Visibility = Visibility.Visible;
            NewHaircutButton.Visibility = Visibility.Collapsed;
            DeliteHaircutButton.Visibility = Visibility.Collapsed;
        }

        private void DeliteHaircutButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "Вы действительно хотите удалить данную причёску?",
                "Удаление",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var DaliteHaircut = ListShopButtonListBox.SelectedItem as HaircutTable;
                AppConnectModelClass.DataBase.HaircutTable.Remove(DaliteHaircut);
                AppConnectModelClass.DataBase.SaveChanges();
                ListShopButtonListBox.ItemsSource = AppConnectModelClass.DataBase.HaircutTable.ToList();
                DeliteHaircutButton.Visibility = Visibility.Collapsed;
            }
        }

        private void ListShopButtonListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeliteHaircutButton.Visibility = Visibility.Visible;
        }
    }
}
