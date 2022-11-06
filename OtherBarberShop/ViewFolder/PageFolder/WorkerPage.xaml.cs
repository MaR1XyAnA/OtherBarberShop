using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            ListWorkerListBox.Items.SortDescriptions.Add(new SortDescription("SurnameWorker", ListSortDirection.Ascending));
            ListWorkerListBox.ItemsSource = AppConnectModelClass.DataBase.WorkerTable.ToList();
        }

        private void ListWorkerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanelButtonControl.Visibility = Visibility.Visible;
            FilterBorder.Visibility = Visibility.Visible;
            InformationsBorder.Visibility = Visibility.Collapsed;
            NewWorkerButton.Visibility = Visibility.Visible;
        }

        private void EdditWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerTable workerTable = (WorkerTable)ListWorkerListBox.SelectedItem;
            FilterBorder.Visibility=Visibility.Collapsed;
            NewWorkerButton.Visibility=Visibility.Collapsed;
            InformationsBorder.Visibility=Visibility.Visible;
            StackPanelButtonControl.Visibility = Visibility.Collapsed;
            InformationFrame.Navigate(new EditWorkerPage(workerTable));
        }

        private void FeliteWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanelButtonControl.Visibility = Visibility.Collapsed;
            if (MessageBox.Show("Вы действительно хотите удалить данного сотрудника?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var DaliteWorker = ListWorkerListBox.SelectedItem as WorkerTable;
                AppConnectModelClass.DataBase.WorkerTable.Remove(DaliteWorker);
                AppConnectModelClass.DataBase.SaveChanges();
                ListWorkerListBox.ItemsSource = AppConnectModelClass.DataBase.WorkerTable.ToList();
            }
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            FilterBorder.Visibility = Visibility.Collapsed;
            NewWorkerButton.Visibility = Visibility.Collapsed;
            InformationsBorder.Visibility = Visibility.Visible;
            StackPanelButtonControl.Visibility = Visibility.Collapsed;
            InformationFrame.Navigate(new AddWorkerPage());
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetSearch(); // Выполняем метод поиска
        }

        private void GetSearch() // Метод для поиска
        {
            var Sweep = AppConnectModelClass.DataBase.WorkerTable.ToList(); // Получаем данные по WorkerTable 

            Sweep = Sweep.Where(Cookie => 
            Cookie.SurnameWorker.ToLower().Contains(SearchTextBox.Text.ToLower()) || // Ищем по SurnameWorker
            Cookie.NameWorker.ToLower().Contains(SearchTextBox.Text.ToLower()) || // Ищем по NameWorker
            Cookie.MiddlenameWorker.ToLower().Contains(SearchTextBox.Text.ToLower()) || // Ищем по MiddlenameWorker
            Cookie.PasswordWorker.ToLower().Contains(SearchTextBox.Text.ToLower()) || // Ищем по PasswordWorker
            Cookie.LoginWorker.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList(); // Ищем по LoginWorker и получаем список

            ListWorkerListBox.ItemsSource = Sweep.OrderBy(Cookie => Cookie.PersonalNumberWorker).ToList(); // В ListWorkerListBox выводим найденную SurnameWorker списком 
        }
    }
}

