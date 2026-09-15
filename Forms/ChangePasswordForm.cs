using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Services;
using AIUBBusManagementSystem.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AIUBBusManagementSystem.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly AuthService authService = new AuthService();

        public ChangePasswordForm()
        {
            InitializeComponent();

            MakeRoundedPanel(panel1, 25);

            Resize += (sender, e) =>
            {
                int x = (ClientSize.Width - 884) / 2;
                int y = (ClientSize.Height - 561) / 2;

                panel1.Location = new Point(510 + x, 95 + y);
                pictureBox1.Location = new Point(161 + x, 154 + y);
                label1.Location = new Point(106 + x, 313 + y);
            };
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please fill all password fields.",
                    "Change Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show(
                    "New passwords do not match.",
                    "Change Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string username =
                    SessionManager.CurrentUser.Username;

                User user = authService.Login(
                    username,
                    currentPassword);

                if (user == null)
                {
                    MessageBox.Show(
                        "Current password is incorrect.",
                        "Change Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                bool success = authService.ResetPassword(
                    username,
                    newPassword);

                if (success)
                {
                    MessageBox.Show(
                        "Password changed successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Password could not be changed.",
                        "Change Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Change Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

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