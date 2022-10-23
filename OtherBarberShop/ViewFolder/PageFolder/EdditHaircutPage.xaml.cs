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
    public partial class EdditHaircutPage : Page
    {
        HaircutTable haircutTable = new HaircutTable();
        public EdditHaircutPage(HaircutTable haircutTable)
        {
            InitializeComponent();
            if (haircutTable != null)
            {
                haircutTable = haircutTable;
                DataContext = haircutTable;
            }
        }

        private void EdditHaircutButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
