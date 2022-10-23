using OtherBarberShop.ClassFolder;
using System.Linq;
using System.Windows.Controls;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class RecordPage : Page
    {
        public RecordPage()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
            ListSessionsListBox.ItemsSource = AppConnectModelClass.DataBase.RecordTable.ToList();
            HaircutComboBox.ItemsSource = AppConnectModelClass.DataBase.HaircutTable.ToList();
            HairdresserComboBox.ItemsSource = AppConnectModelClass.DataBase.FilterHairdresser.ToList();
            DayComboBox.ItemsSource = AppConnectModelClass.DataBase.FilterDate.ToList();
            TimrComboBox.ItemsSource = AppConnectModelClass.DataBase.FilterTime.ToList();
        }
    }
}
