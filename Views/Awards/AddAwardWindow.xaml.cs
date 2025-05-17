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
    public partial class AddAwardWindow : Window
    {
        private readonly TRIZBD_Lab4.Awards _entity = new TRIZBD_Lab4.Awards();
        public AddAwardWindow()
        {
            InitializeComponent();
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
            _entity.graduate_id = (int)GraduateCombo.SelectedValue;
            var ctx = UniversityDBEntities.GetContext();
            ctx.Awards.Add(_entity);
            ctx.SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
