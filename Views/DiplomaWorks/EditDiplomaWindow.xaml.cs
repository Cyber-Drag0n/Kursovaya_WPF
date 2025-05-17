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

namespace TRIZBD_Lab4.Views.DiplomaWorks
{
    public partial class EditDiplomaWindow : Window
    {
        private readonly TRIZBD_Lab4.DiplomaWorks _entity;
        public EditDiplomaWindow(TRIZBD_Lab4.DiplomaWorks entity)
        {
            InitializeComponent();
            _entity = entity;
            DataContext = _entity;
            var ctx = UniversityDBEntities.GetContext();
            GraduateCombo.ItemsSource = ctx.Graduates.ToList();
            AdvisorCombo.ItemsSource = ctx.ScientificAdvisors.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (GraduateCombo.SelectedValue == null ||
                AdvisorCombo.SelectedValue == null ||
                string.IsNullOrWhiteSpace(_entity.title) ||
                _entity.year == 0)
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
