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

namespace TRIZBD_Lab4.Views.Awards
{
    public partial class EditAwardWindow : Window
    {
        private readonly TRIZBD_Lab4.Awards _entity;
        public EditAwardWindow(TRIZBD_Lab4.Awards entity)
        {
            InitializeComponent();
            _entity = entity;
            DataContext = _entity;
            GraduateCombo.ItemsSource = UniversityDBEntities.GetContext().Graduates.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (GraduateCombo.SelectedValue == null ||
                string.IsNullOrWhiteSpace(_entity.award_name) ||
                _entity.award_year == 0)
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
