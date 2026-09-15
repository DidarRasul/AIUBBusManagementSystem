using AIUBBusManagementSystem.Forms;
using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Services;
using AIUBBusManagementSystem.Utils;
using System.Drawing.Drawing2D;

namespace AIUBBusManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            MakeRoundedPanel(panel1, 25);

            this.Resize += LoginForm_Resize;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoginForm_Resize(this, EventArgs.Empty);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter username and password.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            AuthService authService = new AuthService();

            User user = authService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show(
                    "Invalid username or password, or your account is not active.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            SessionManager.StartSession(user);

            MainDashboardForm dashboard = new MainDashboardForm();

            dashboard.Show();

            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void chkShowPassword_CheckedChanged(
            object sender,
            EventArgs e)
        {
            txtPassword.UseSystemPasswordChar =
                !chkShowPassword.Checked;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            txtPassword.Clear();

            chkShowPassword.Checked = false;

            textBox2.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //forgot Password link
        private void linkForgotPassword_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasswordForm forgotPasswordForm =
                new ForgotPasswordForm();

            forgotPasswordForm.ShowDialog();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            // Original design size
            const int designWidth = 900;
            const int designHeight = 600;

            // Original control positions
            const int titleX = 12;
            const int titleY = 29;

            const int panelX = 513;
            const int panelY = 74;

            // Keep the original control sizes.
            // Only move the controls when the form is resized.

            int offsetX = (ClientSize.Width - designWidth) / 2;
            int offsetY = (ClientSize.Height - designHeight) / 2;

            // If the window becomes smaller than the original design,
            // don't use negative offsets.
            if (offsetX < 0)
                offsetX = 0;

            if (offsetY < 0)
                offsetY = 0;

            lblTitle.Location = new Point(
                titleX + offsetX,
                titleY + offsetY
            );

            panel1.Location = new Point(
                panelX + offsetX,
                panelY + offsetY
            );

            MakeRoundedPanel(panel1, 25);
        }

        // Rounded Panel
        private void MakeRoundedPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90
            );

            path.AddArc(
                panel.Width - radius,
                0,
                radius,
                radius,
                270,
                90
            );

            path.AddArc(
                panel.Width - radius,
                panel.Height - radius,
                radius,
                radius,
                0,
                90
            );

            path.AddArc(
                0,
                panel.Height - radius,
                radius,
                radius,
                90,
                90
            );

            path.CloseFigure();

            panel.Region = new Region(path);
        }
    }
}