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

namespace TRIZBD_Lab4.Views.Skills
{
    public partial class EditSkillWindow : Window
    {
        private readonly TRIZBD_Lab4.Skills _entity;
        public EditSkillWindow(TRIZBD_Lab4.Skills entity)
        {
            InitializeComponent();
            _entity = entity;
            DataContext = _entity;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_entity.skill_name))
            {
                MessageBox.Show("Введите skill_name");
                return;
            }
            UniversityDBEntities.GetContext().SaveChanges();
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Close();
    }
}
