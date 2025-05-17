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
    public partial class AddRoleWindow : Window
    {
        private readonly TRIZBD_Lab4.Roles _entity = new TRIZBD_Lab4.Roles();
        public AddRoleWindow()
        {
            InitializeComponent();
            DataContext = _entity;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_entity.role_name))
            {
                MessageBox.Show("Введите role_name");
                return;
            }
            var ctx = UniversityDBEntities.GetContext();
            ctx.Roles.Add(_entity);
            ctx.SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
