using AIUBBusManagementSystem.UserControls.Admin;
using AIUBBusManagementSystem.UserControls.Driver;
using AIUBBusManagementSystem.UserControls.Student;
using AIUBBusManagementSystem.Utils;

namespace AIUBBusManagementSystem.Forms
{
    public partial class MainDashboardForm : Form
    {
        public MainDashboardForm()
        {
            InitializeComponent();

            LoadRoleDashboard();
            panelDashboardHost.Resize += panelDashboardHost_Resize;
        }

        private void LoadRoleDashboard()
        {
            if (!SessionManager.IsLoggedIn())
            {
                MessageBox.Show(
                    "Session expired. Please login again.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                Application.Restart();
                return;
            }

            string role = SessionManager.CurrentUser.Role?.Trim() ?? "";

            UserControl dashboard = role.ToUpper() switch
            {
                "ADMIN" => new AdminDashboardControl(),
                "DRIVER" => new DriverDashboardControl(),
                "STUDENT" => new StudentDashboardControl(),
                _ => null
            };

            if (dashboard == null)
            {
                MessageBox.Show(
                    $"Unauthorized role: {role}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            panelDashboardHost.Controls.Clear();

            dashboard.Dock = DockStyle.None;
            dashboard.Size = new Size(900, 600);

            panelDashboardHost.Controls.Add(dashboard);

            dashboard.Location = new Point(
                (panelDashboardHost.ClientSize.Width - dashboard.Width) / 2,
                (panelDashboardHost.ClientSize.Height - dashboard.Height) / 2
            );
        }

        private void panelDashboardHost_Resize(object sender, EventArgs e)
        {
            if (panelDashboardHost.Controls.Count > 0)
            {
                Control dashboard = panelDashboardHost.Controls[0];

                dashboard.Location = new Point(
                    (panelDashboardHost.ClientSize.Width - dashboard.Width) / 2,
                    (panelDashboardHost.ClientSize.Height - dashboard.Height) / 2
                );
            }
        }

        private void panelDashboardHost_Paint(
            object sender,
            PaintEventArgs e)
        {
        }
    }
} 