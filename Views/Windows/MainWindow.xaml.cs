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

namespace MasterClassCRM.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StatusCmb.ItemsSource = App.context.Status.ToList();
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            Button userBtn = (Button)sender;
            int userTag = int.Parse(userBtn.Tag.ToString());
            var currentUser = App.context.Users.Where(u => u.id == userTag).FirstOrDefault();
            MessageBox.Show($"{currentUser.name} {currentUser.surname} {currentUser.patronymic}");
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clientBtn = (Button)sender;
            int clientTag = int.Parse(clientBtn.Tag.ToString());
            var currentClient = App.context.Client.Where(c => c.id == clientTag).FirstOrDefault();
            MessageBox.Show($"{currentClient.name} {currentClient.surname} {currentClient.patronymic} \n" +
                $"Возраст: {currentClient.age} \n" +
                $"Номер телефона: {currentClient.phone_number} \n" +
                $"Email: {currentClient.email} \n" +
                $"Компания: {currentClient.company}");
        }

        private void DealsLv_Loaded(object sender, RoutedEventArgs e)
        {
            DealsLv.ItemsSource = App.context.Deal.ToList();
        }

        private void AddDealBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditDealBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteDealBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameRdbtn.IsChecked == true)
            {
                DealsLv.ItemsSource = App.context.Deal.Where(d => d.name.Contains(SearchTb.Text)).ToList();
            }
            else if (ClientRdbtn.IsChecked == true)
            {

            }
        }
    }
}
