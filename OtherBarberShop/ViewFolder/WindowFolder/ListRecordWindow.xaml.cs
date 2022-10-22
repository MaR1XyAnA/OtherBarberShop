using OtherBarberShop.ClassFolder;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace OtherBarberShop.ViewFolder.WindowFolder
{
    public partial class ListRecordWindow : Window
    {
        public ListRecordWindow()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
            ListSessionsListBox.ItemsSource = AppConnectModelClass.DataBase.RecordTable.ToList();
        }
    }
}
