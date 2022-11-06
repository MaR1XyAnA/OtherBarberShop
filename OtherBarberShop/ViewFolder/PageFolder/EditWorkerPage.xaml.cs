using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OtherBarberShop.ViewFolder.PageFolder
{
    public partial class EditWorkerPage : Page
    {
        WorkerTable workerTable = new WorkerTable(); 
        public EditWorkerPage(WorkerTable workerTable)
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new OtherBarberShopDataBaseEntities();
        }

        private void SaveWorkerButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
