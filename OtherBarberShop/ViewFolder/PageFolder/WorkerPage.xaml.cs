using OtherBarberShop.ClassFolder;
using OtherBarberShop.ModelFolder;
using OtherBarberShop.ViewFolder.WindowFolder;
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
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            AppConnectModelClass.DataBase = new ModelFolder.OtherBarberShopDataBaseEntities();
            RoleComboBox.ItemsSource = AppConnectModelClass.DataBase.RoleTable.ToList();
        }

        private void ListWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            ListWorkerWindow listWorkerWindow = new ListWorkerWindow();
            listWorkerWindow.Show();
        }

        private void NewWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            if(AppConnectModelClass.DataBase.WorkerTable.Count(data => data.SurnameWorker == SurnameWorkerTextBox.Text && data.NameWorker == NameWorkerTextBox.Text)>0)
            {
                MessageBox.Show("Данный сотрудник уже сушествует");
                return;
            }
            else
            {
                try
                {
                    WorkerTable workerTable = new WorkerTable()
                    { 
                        SurnameWorker = SurnameWorkerTextBox.Text,
                        NameWorker = NameWorkerTextBox.Text,
                        MiddlenameWorker = MiddlenameWorkerTextBox.Text,
                        RoleWorker = RoleComboBox.Text,
                        LoginWorker = LoginWorkerTextBox.Text,
                        PasswordWorker = PasswordWorkerTextBox.Text,
                        ImageWorker = null
                    };
                    AppConnectModelClass.DataBase.WorkerTable.Add(workerTable);
                    AppConnectModelClass.DataBase.SaveChanges();
                    MessageBox.Show("Данные успешно добавленны");
                    Clear();
                }
                catch
                {
                    MessageBox.Show("Ошибка добавления");
                }
            }
        }
        private void Clear()
        {
            SurnameWorkerTextBox.Text = null;
            NameWorkerTextBox.Text = null;
            MiddlenameWorkerTextBox.Text = null;
            RoleComboBox.Text = null;
            LoginWorkerTextBox.Text = null;
            PasswordWorkerTextBox.Text = null;
        }
    }
}
