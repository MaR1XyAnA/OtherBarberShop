using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using OtherBarberShop.ViewFolder.WindowFolder;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    public partial class RecordPage : Page
    {
        public RecordPage()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
            HaircutComboBox.ItemsSource = AppConnectModelClass.DataBase.HaircutTable.ToList();
        }

        private void VisibilityListButton_Click(object sender, RoutedEventArgs e)
        {
            ListRecordWindow listRecordWindow = new ListRecordWindow();
            listRecordWindow.Show();
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int RanRez = random.Next(4, 5);
            if (AppConnectModelClass.DataBase.ClientTabel.Count(data => data.SurnameClient == SurnameClientTextBox.Text && data.NameClient == NameClientTextBox.Text) > 0)
            {
                MessageBox.Show("Данный клиент уже сушествует в базе данных", "Ошибка записи");
                return;
            }
            else
            {
                try
                {
                    ClientTabel clientTabel = new ClientTabel()
                    {
                        SurnameClient = SurnameClientTextBox.Text,
                        NameClient = NameClientTextBox.Text
                    };
                    AppConnectModelClass.DataBase.ClientTabel.Add(clientTabel);
                    RecordTable recordTable = new RecordTable()
                    {
                        PNClient = SurnameClientTextBox.Text,
                        PNHaircut = HaircutComboBox.Text,
                        PNWorker = RanRez
                    };
                    AppConnectModelClass.DataBase.RecordTable.Add(recordTable);
                    AppConnectModelClass.DataBase.SaveChanges();
                    MessageBox.Show("Данные успешно добавленны");
                    Clear();
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления данных");
                }
            }
        }
        private void Clear()
        {
            SurnameClientTextBox.Text = null;
            NameClientTextBox.Text = null;
            HaircutComboBox.Text = null;
        }
    }
}
