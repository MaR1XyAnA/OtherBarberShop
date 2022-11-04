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
            ListSessionsListBox.ItemsSource = AppConnectModelClass.DataBase().RecordTable.ToList();
            HaircutComboBox.ItemsSource = AppConnectModelClass.DataBase().HaircutTable.ToList();
            HairdresserComboBox.ItemsSource = AppConnectModelClass.DataBase().FilterHairdresser.ToList();
            DayComboBox.ItemsSource = AppConnectModelClass.DataBase().FilterDate.ToList();
            TimrComboBox.ItemsSource = AppConnectModelClass.DataBase().FilterTime.ToList();
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
                var DaliteClient = ListSessionsListBox.SelectedItem as ClientTabel;
                AppConnectModelClass.DataBase().RecordTable.Remove(DaliteRecord);
                AppConnectModelClass.DataBase().ClientTabel.Remove(DaliteClient);
                AppConnectModelClass.DataBase().SaveChanges();
                ListSessionsListBox.ItemsSource = AppConnectModelClass.DataBase().RecordTable.ToList();
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
