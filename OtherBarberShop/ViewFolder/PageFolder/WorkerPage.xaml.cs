using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using OtherBarberShop.ViewFolder.WindowFolder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new OtherBarberShopDataBaseEntities();
            ListWorkerListBox.ItemsSource = AppConnectModelClass.DataBase.WorkerTable.ToList();
            ListWorkerListBox.Items.SortDescriptions.Add(new SortDescription("SurnameWorker", ListSortDirection.Ascending));
            RoleComboBox.ItemsSource = AppConnectModelClass.DataBase.RoleTable.ToList();
            PaulComboBox.ItemsSource = AppConnectModelClass.DataBase.PaulTable.ToList();
        }

        private void ListWorkerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StackPanelButtonControl.Visibility = Visibility.Visible;
            FilterBorder.Visibility = Visibility.Visible;
            InformationsBorder.Visibility = Visibility.Collapsed;
        }

        private void EdditWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            WorkerTable workerTable = (WorkerTable)ListWorkerListBox.SelectedItem;
            FilterBorder.Visibility=Visibility.Collapsed;
            InformationsBorder.Visibility=Visibility.Visible;
            StackPanelButtonControl.Visibility = Visibility.Collapsed;
            InformationFrame.Navigate(new InformationWorkerPage(workerTable));
        }

        private void FeliteWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            StackPanelButtonControl.Visibility = Visibility.Collapsed;
            if (MessageBox.Show(
                "Вы действительно хотите удалить данного сотрудника?",
                "Удаление",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var DaliteWorker = ListWorkerListBox.SelectedItem as WorkerTable;
                AppConnectModelClass.DataBase.WorkerTable.Remove(DaliteWorker);
                AppConnectModelClass.DataBase.SaveChanges();
                ListWorkerListBox.ItemsSource = AppConnectModelClass.DataBase.WorkerTable.ToList();
            }
        }
    }
}
