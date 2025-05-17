using System.Linq;
using System.Windows;
using TRIZBD_Lab4;
using TRIZBD_Lab4.Views.Awards;
using TRIZBD_Lab4.Views.Departments;
using TRIZBD_Lab4.Views.DiplomaWorks;
using TRIZBD_Lab4.Views.Graduates;
using TRIZBD_Lab4.Views.Roles;
using TRIZBD_Lab4.Views.ScientificAdvisors;
using TRIZBD_Lab4.Views.Skills;
using TRIZBD_Lab4.Views.Users;

namespace TRIZBD_Lab4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            var ctx = UniversityDBEntities.GetContext();

            UsersGrid.ItemsSource = ctx.Users.OrderBy(u => u.user_id).ToList();
            RolesGrid.ItemsSource = ctx.Roles.OrderBy(r => r.role_id).ToList();
            DepartmentsGrid.ItemsSource = ctx.Departments.OrderBy(d => d.department_id).ToList();
            GraduatesGrid.ItemsSource = ctx.Graduates.OrderBy(g => g.graduate_id).ToList();
            AdvisorsGrid.ItemsSource = ctx.ScientificAdvisors.OrderBy(a => a.advisor_id).ToList();
            SkillsGrid.ItemsSource = ctx.Skills.OrderBy(s => s.skill_id).ToList();
            DiplomasGrid.ItemsSource = ctx.DiplomaWorks.OrderBy(d => d.diploma_id).ToList();
            AwardsGrid.ItemsSource = ctx.Awards.OrderBy(a => a.award_id).ToList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            UniversityDBEntities.GetContext().Dispose();
            typeof(UniversityDBEntities)
                .GetField("_context",
                          System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic)
                .SetValue(null, null);
            LoadAll();
        }

        // Users
        private void AddUser_Click(object s, RoutedEventArgs e)
        { new AddUserWindow().ShowDialog(); LoadAll(); }
        private void EditUser_Click(object s, RoutedEventArgs e)
        { if (UsersGrid.SelectedItem is Users u) new EditUserWindow(u).ShowDialog(); LoadAll(); }
        private void DeleteUser_Click(object s, RoutedEventArgs e)
        {
            var list = UsersGrid.SelectedItems.Cast<Users>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.Users.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // Roles
        private void AddRole_Click(object s, RoutedEventArgs e)
        { new AddRoleWindow().ShowDialog(); LoadAll(); }
        private void EditRole_Click(object s, RoutedEventArgs e)
        { if (RolesGrid.SelectedItem is Roles r) new EditRoleWindow(r).ShowDialog(); LoadAll(); }
        private void DeleteRole_Click(object s, RoutedEventArgs e)
        {
            var list = RolesGrid.SelectedItems.Cast<Roles>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.Roles.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // Departments
        private void AddDepartment_Click(object s, RoutedEventArgs e)
        { new AddDepartmentWindow().ShowDialog(); LoadAll(); }
        private void EditDepartment_Click(object s, RoutedEventArgs e)
        { if (DepartmentsGrid.SelectedItem is Departments d) new EditDepartmentWindow(d).ShowDialog(); LoadAll(); }
        private void DeleteDepartment_Click(object s, RoutedEventArgs e)
        {
            var list = DepartmentsGrid.SelectedItems.Cast<Departments>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.Departments.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // Graduates
        private void AddGraduate_Click(object s, RoutedEventArgs e)
        { new AddGraduateWindow().ShowDialog(); LoadAll(); }
        private void EditGraduate_Click(object s, RoutedEventArgs e)
        { if (GraduatesGrid.SelectedItem is Graduates g) new EditGraduateWindow(g).ShowDialog(); LoadAll(); }
        private void DeleteGraduate_Click(object s, RoutedEventArgs e)
        {
            var list = GraduatesGrid.SelectedItems.Cast<Graduates>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.Graduates.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // ScientificAdvisors
        private void AddAdvisor_Click(object s, RoutedEventArgs e)
        { new AddAdvisorWindow().ShowDialog(); LoadAll(); }
        private void EditAdvisor_Click(object s, RoutedEventArgs e)
        { if (AdvisorsGrid.SelectedItem is ScientificAdvisors sa) new EditAdvisorWindow(sa).ShowDialog(); LoadAll(); }
        private void DeleteAdvisor_Click(object s, RoutedEventArgs e)
        {
            var list = AdvisorsGrid.SelectedItems.Cast<ScientificAdvisors>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.ScientificAdvisors.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // Skills
        private void AddSkill_Click(object s, RoutedEventArgs e)
        { new AddSkillWindow().ShowDialog(); LoadAll(); }
        private void EditSkill_Click(object s, RoutedEventArgs e)
        { if (SkillsGrid.SelectedItem is Skills sk) new EditSkillWindow(sk).ShowDialog(); LoadAll(); }
        private void DeleteSkill_Click(object s, RoutedEventArgs e)
        {
            var list = SkillsGrid.SelectedItems.Cast<Skills>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.Skills.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // DiplomaWorks
        private void AddDiploma_Click(object s, RoutedEventArgs e)
        { new AddDiplomaWindow().ShowDialog(); LoadAll(); }
        private void EditDiploma_Click(object s, RoutedEventArgs e)
        { if (DiplomasGrid.SelectedItem is DiplomaWorks d) new EditDiplomaWindow(d).ShowDialog(); LoadAll(); }
        private void DeleteDiploma_Click(object s, RoutedEventArgs e)
        {
            var list = DiplomasGrid.SelectedItems.Cast<DiplomaWorks>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.DiplomaWorks.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }

        // Awards
        private void AddAward_Click(object s, RoutedEventArgs e)
        { new AddAwardWindow().ShowDialog(); LoadAll(); }
        private void EditAward_Click(object s, RoutedEventArgs e)
        { if (AwardsGrid.SelectedItem is Awards aw) new EditAwardWindow(aw).ShowDialog(); LoadAll(); }
        private void DeleteAward_Click(object s, RoutedEventArgs e)
        {
            var list = AwardsGrid.SelectedItems.Cast<Awards>().ToList();
            if (list.Any() && MessageBox.Show("Confirm?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var ctx = UniversityDBEntities.GetContext();
                ctx.Awards.RemoveRange(list);
                ctx.SaveChanges();
                LoadAll();
            }
        }
    }
}
