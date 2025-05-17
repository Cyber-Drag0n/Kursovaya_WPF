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

namespace TRIZBD_Lab4.Views.Users
{
    public partial class AddUserWindow : Window
    {
        private readonly TRIZBD_Lab4.Users _entity = new TRIZBD_Lab4.Users();
        public AddUserWindow()
        {
            InitializeComponent();
            DataContext = _entity;
            RoleCombo.ItemsSource = UniversityDBEntities.GetContext().Roles.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (RoleCombo.SelectedValue == null ||
                string.IsNullOrWhiteSpace(_entity.first_name) ||
                string.IsNullOrWhiteSpace(_entity.last_name) ||
                string.IsNullOrWhiteSpace(_entity.email) ||
                string.IsNullOrWhiteSpace(_entity.password_hash))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            _entity.role_id = (int)RoleCombo.SelectedValue;
            var ctx = UniversityDBEntities.GetContext();
            ctx.Users.Add(_entity);
            ctx.SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
