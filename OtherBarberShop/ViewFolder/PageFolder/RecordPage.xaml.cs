using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class RecordPage : Page
    {
        public RecordPage()
        {
            InitializeComponent();
            ListSessionsListBox.ItemsSource = AppConnectModelClass.DataBase.RecordTable.ToList();
        }

        private void EdditRecordButton_Click(object sender, RoutedEventArgs e)
        {
            RecordTable recordTable = (RecordTable)ListSessionsListBox.SelectedItem;
            StackPanelButtonControl.Visibility = Visibility.Collapsed;
            FilterBorder.Visibility = Visibility.Collapsed;
            EdditBorder.Visibility = Visibility.Visible;
            EdditRecordFrame.Navigate(new EdditRecordPage(recordTable));
        }

        private void ListSessionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanelButtonControl.Visibility = Visibility.Visible;
            FilterBorder.Visibility = Visibility.Visible;
            EdditBorder.Visibility = Visibility.Collapsed;
        }

        private void DeliteRecordButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(
                "Вы действительно хотите удалить данного сотрудника?",
                "Удаление",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var DaliteRecord = ListSessionsListBox.SelectedItem as RecordTable;
                AppConnectModelClass.DataBase.RecordTable.Remove(DaliteRecord);
                AppConnectModelClass.DataBase.SaveChanges();
                ListSessionsListBox.ItemsSource = AppConnectModelClass.DataBase.RecordTable.ToList();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetSearch(); // Выполняем метод поиска
        }

        private void GetSearch() // Метод для поиска
        {
            var Sweep = AppConnectModelClass.DataBase.RecordTable.ToList(); // Получаем данные по ClientTabel 

            Sweep = Sweep.Where(Cookie =>
            Cookie.NameClient.ToLower().Contains(SearchTextBox.Text.ToLower()) || // Ищем по NameClient
            Cookie.SurnameClient.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();  // Ищем по SurnameClient

            ListSessionsListBox.ItemsSource = Sweep.OrderBy(Cookie => Cookie.PersonalNumberRecord).ToList(); // В ListWorkerListBox выводим найденную SurnameWorker списком 
        }
    }
}
