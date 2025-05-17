using System;
using System.Collections.Generic;
using System.Data;
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

namespace TRIZBD_Lab4.Views.Roles
{
    public partial class EditRoleWindow : Window
    {
        private readonly TRIZBD_Lab4.Roles _entity;
        public EditRoleWindow(TRIZBD_Lab4.Roles entity)
        {
            InitializeComponent();
            _entity = entity;
            DataContext = _entity;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_entity.role_name))
            {
                MessageBox.Show("Введите role_name");
                return;
            }
            UniversityDBEntities.GetContext().SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
