using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using demosed_465734.view.widow;

namespace demosed_465734
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public dbEntities dBEntities = dbEntities.GetContet();
        public ObservableCollection<string> list = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            list.Add("Модератор");
            list.Add("Жюри");
            TypeBox.ItemsSource = list;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void enterLogin_Click(object sender, RoutedEventArgs e)
        {
            Auth(Convert.ToInt32(loginBox.Text), passBox.Password, TypeBox.SelectedItem.ToString());
        }

        private void Auth(int login, string password, string type)
        {
            string fullName;

            Moder user = null;
            gyri guri = null;

            if (login < 0 || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин или пароль");
                return;
            }

            using (var db = new dbEntities())
            {
                switch (type)
                {
                    case "Модератор":
                        {
                            user = db.Moder.FirstOrDefault(u => u.ID == login && u.Password == password);
                            if (user == null)
                                return;

                            MessageBox.Show("Пользователь успешно найден");
                            testWindow window = new testWindow(user.FullName);
                            window.Show();

                        }
                        break;
                    case "Жюри":
                        {
                            guri = db.gyri.FirstOrDefault(u => u.ID == Convert.ToInt32(login) && u.Password == password);
                            if (guri == null) return;

                            MessageBox.Show("Пользователь успешно найден");
                            testWindow window = new testWindow(guri.FullName);
                            window.Show();
                        }
                        break;
                    default:
                        MessageBox.Show("Роль не выбрана");
                        break;
                }
            }
        }
    }
}
