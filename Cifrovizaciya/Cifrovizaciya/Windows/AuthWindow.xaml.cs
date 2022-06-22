using Cifrovizaciya.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Cifrovizaciya.Windows
{
    public partial class AuthWindow : Window
    {
        public IgishevDemo2022Entities _context = new IgishevDemo2022Entities();
        public ObservableCollection<string> list = new ObservableCollection<string>();

        public AuthWindow()
        {
            InitializeComponent();

            list.Add("Участник");
            list.Add("Модератор");
            list.Add("Организатор");
            list.Add("Жюри");
            CmbPosition.ItemsSource = list;
            
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            Auth(Convert.ToInt32(TbLogin.Text), PbPassword.Password, CmbPosition.SelectedItem.ToString());
        }
    

        private void Auth(int login, string password, string type)
        {
            string fullName;
            int PeopleID;

            Clients client = null;
            Moder user = null;
            Organizatory org = null;
            gyri guri = null;

            if (TbLogin.Text == "" || string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Введите логин или пароль");
                return;
            }

            using (var db = new IgishevDemo2022Entities())
            {
                switch (type)
                {
                    case "Участник":
                        {
                            client = db.Clients.FirstOrDefault(u => u.ID == login && u.Password == password);
                            if (client == null)
                                return;

                            MessageBox.Show("Участник");
                        }
                        break;
                    case "Модератор":
                        {
                            user = db.Moder.FirstOrDefault(u => u.ID == login && u.Password == password);
                            if (user == null)
                                return;

                            MessageBox.Show("Модератор");                            
                        }
                        break;
                    case "Организатор":
                        {
                            org = db.Organizatory.FirstOrDefault(u => u.ID == login && u.Password == password);
                            if (org == null)
                                return;

                            PeopleID = org.ID;

                            OrganizatorWindow organizatorWindow = new OrganizatorWindow(PeopleID);
                            organizatorWindow.Show();
                            this.Close();
                        }
                        break;
                    case "Жюри":
                        {
                            guri = db.gyri.FirstOrDefault(u => u.ID == Convert.ToInt32(login) && u.Password == password);
                            if (guri == null) 
                                return;

                            MessageBox.Show("Жюри");
                        }
                        break;
                    default:
                        MessageBox.Show("Роль не выбрана");
                        break;
                }
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
