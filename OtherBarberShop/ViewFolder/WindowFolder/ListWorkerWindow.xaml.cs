using OtherBarberShop.ClassFolder;
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
using System.Windows.Shapes;

namespace OtherBarberShop.ViewFolder.WindowFolder
{
    public partial class ListWorkerWindow : Window
    {
        public ListWorkerWindow()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
            ListWorkerListBox.ItemsSource = AppConnectModelClass.DataBase.WorkerTable.ToList();
            ListWorkerListBox.Items.SortDescriptions.Add(new SortDescription("SurnameWorker", ListSortDirection.Ascending));
        }
    }
}
