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
using demosed_465734.view.pages;

namespace demosed_465734.view.widow
{
    /// <summary>
    /// Логика взаимодействия для testWindow.xaml
    /// </summary>
    public partial class testWindow : Window
    {
        public testWindow(string fullName)
        {
            InitializeComponent();

            MainFrame.Navigate(new testPage());
            Manager.MainFrame = MainFrame;

            FullNameBlock.Text = fullName;
            nameuser.Text = fullName;
        }
    }
}
