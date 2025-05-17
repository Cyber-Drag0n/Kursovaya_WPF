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
    public partial class AddDiplomaWindow : Window
    {
        private readonly TRIZBD_Lab4.DiplomaWorks _entity = new TRIZBD_Lab4.DiplomaWorks();
        public AddDiplomaWindow()
        {
            InitializeComponent();
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
            _entity.graduate_id = (int)GraduateCombo.SelectedValue;
            _entity.advisor_id = (int)AdvisorCombo.SelectedValue;
            var ctx = UniversityDBEntities.GetContext();
            ctx.DiplomaWorks.Add(_entity);
            ctx.SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
