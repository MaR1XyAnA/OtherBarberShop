using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class InformationWorkerPage : Page
    {
        WorkerTable workerTable = new WorkerTable();
        public InformationWorkerPage(WorkerTable workerTable)
        {
            InitializeComponent();
            PaulInformationsComboBox.ItemsSource = AppConnectModelClass.DataBase.PaulTable.ToList(); // Загружаем в PaulInformationsComboBox таблицу PaulTable
            RoleInformationsComboBox.ItemsSource = AppConnectModelClass.DataBase.RoleTable.ToList(); // Загружаем в RoleInformationsComboBox таблицу RoleTable
            if (workerTable != null)
            {
                workerTable = workerTable;
                DataContext = workerTable;
            }
        }

        private void SaveWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Вносить сохранённые данные в БД
        }
    }
}
