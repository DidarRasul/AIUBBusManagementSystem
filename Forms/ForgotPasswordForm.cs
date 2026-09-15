using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIUBBusManagementSystem.Services;
using System.Drawing.Drawing2D;

namespace AIUBBusManagementSystem.Forms
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();

            MakeRoundedPanel(panel1, 25);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Forgot Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Forgot Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            AuthService authService = new AuthService();

            bool result = authService.ResetPassword(username, newPassword);

            if (result)
            {
                MessageBox.Show(
                    "Password reset successful!",
                    "Forgot Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Username not found.",
                    "Forgot Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Rounded Panel
        private void MakeRoundedPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);

            path.AddArc(
                panel.Width - radius,
                panel.Height - radius,
                radius,
                radius,
                0,
                90);

            path.AddArc(
                0,
                panel.Height - radius,
                radius,
                radius,
                90,
                90);

            path.CloseFigure();

            panel.Region = new Region(path);
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            this.Resize += ForgotPasswordForm_Resize;

            CenterControls();
        }

        private void CenterControls()
        {
            int centerX = this.ClientSize.Width / 2;

            panel1.Left = centerX + 10;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;

            pictureBox1.Left = centerX - 324;
            pictureBox1.Top = panel1.Top + 186;

            label1.Left = centerX - 377;
            label1.Top = panel1.Top + 335;
        }

        private void ForgotPasswordForm_Resize(object sender, EventArgs e)
        {
            CenterControls();
        }
    }
}