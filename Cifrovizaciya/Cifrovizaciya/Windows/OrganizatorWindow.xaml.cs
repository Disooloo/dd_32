using Cifrovizaciya.Models;
using System.Windows;

namespace Cifrovizaciya.Windows
{
    public partial class OrganizatorWindow : Window
    {
        private Organizatory _selected;
        private IgishevDemo2022Entities _context;

        public OrganizatorWindow(int PeopleID)
        {
            InitializeComponent();

            _context = new IgishevDemo2022Entities();
            _selected = _context.Organizatory.Find(PeopleID);

            this.DataContext = _selected;
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
