using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using System.Linq;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class EdditRecordPage : Page
    {
        RecordTable recordTable = new RecordTable();
        public EdditRecordPage(RecordTable recordTable)
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new OtherBarberShopDataBaseEntities();
            HairdresserComboBox.ItemsSource = AppConnectModelClass.DataBase.FilterHairdresser.ToList();
            if (recordTable != null)
            {
                recordTable = recordTable;
                DataContext = recordTable;
            }
            HaircutComboBox.ItemsSource = AppConnectModelClass.DataBase.HaircutTable.ToList();
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //TODO: Сделать алгоритм изменения информации в БД
        }
    }
}
