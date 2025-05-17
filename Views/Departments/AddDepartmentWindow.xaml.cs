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

namespace TRIZBD_Lab4.Views.Departments
{
    public partial class AddDepartmentWindow : Window
    {
        private readonly TRIZBD_Lab4.Departments _entity = new TRIZBD_Lab4.Departments();
        public AddDepartmentWindow()
        {
            InitializeComponent();
            DataContext = _entity;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_entity.department_name))
            {
                MessageBox.Show("Введите department_name");
                return;
            }
            var ctx = UniversityDBEntities.GetContext();
            ctx.Departments.Add(_entity);
            ctx.SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
