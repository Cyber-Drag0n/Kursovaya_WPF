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
    public partial class EditUserWindow : Window
    {
        private readonly TRIZBD_Lab4.Users _entity;

        public EditUserWindow(TRIZBD_Lab4.Users entity)
        {
            InitializeComponent();
            _entity = entity;
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
            UniversityDBEntities.GetContext().SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
