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

namespace TRIZBD_Lab4.Views.ScientificAdvisors
{
    public partial class EditAdvisorWindow : Window
    {
        private readonly TRIZBD_Lab4.ScientificAdvisors _entity;
        public EditAdvisorWindow(TRIZBD_Lab4.ScientificAdvisors entity)
        {
            InitializeComponent();
            _entity = entity;
            DataContext = _entity;
            var ctx = UniversityDBEntities.GetContext();
            UserCombo.ItemsSource = ctx.Users.ToList();
            DeptCombo.ItemsSource = ctx.Departments.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (UserCombo.SelectedValue == null || DeptCombo.SelectedValue == null)
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
