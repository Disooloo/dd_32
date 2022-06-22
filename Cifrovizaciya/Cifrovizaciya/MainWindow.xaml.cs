using Cifrovizaciya.Models;
using Cifrovizaciya.Windows;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Cifrovizaciya
{
    public partial class MainWindow : Window
    {
        IgishevDemo2022Entities _context = new IgishevDemo2022Entities();

        public MainWindow()
        {
            InitializeComponent();

            RefreshData();

            // Загрузка фотографий в базу данных в виде байтов
            // Команда одноразовая           
            /*foreach (var test in _context.Organizatory)
            {
                string fullpath = test.PhotoPath;
                var bytes = File.ReadAllBytes(fullpath);
                test.Photo = bytes;
            }
            _context.SaveChanges();*/
        }

        private void RefreshData()
        {
            List<Meropriaytie> listMer = _context.Meropriaytie.ToList();

            // Сортировка
            switch (CmbFiltr.SelectedIndex)
            {
                case 0: { listMer = listMer.ToList(); break; }
                case 1: { listMer = listMer.OrderBy(s => s.Date).ToList(); break; }
                case 2: { listMer = listMer.OrderByDescending(s => s.Date).ToList(); break; }
            }

            LViewMer.ItemsSource = listMer;
        }

        private void CmbCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
