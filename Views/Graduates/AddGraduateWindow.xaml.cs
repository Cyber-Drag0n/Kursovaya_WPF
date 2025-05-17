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

namespace TRIZBD_Lab4.Views.Graduates
{
    public partial class AddGraduateWindow : Window
    {
        private readonly TRIZBD_Lab4.Graduates _entity = new TRIZBD_Lab4.Graduates();
        public AddGraduateWindow()
        {
            InitializeComponent();
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
            _entity.user_id = (int)UserCombo.SelectedValue;
            _entity.department_id = (int)DeptCombo.SelectedValue;
            var ctx = UniversityDBEntities.GetContext();
            ctx.Graduates.Add(_entity);
            ctx.SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
