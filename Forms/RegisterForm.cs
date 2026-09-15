using AIUBBusManagementSystem.Models;
using AIUBBusManagementSystem.Repositories;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace AIUBBusManagementSystem.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            MakeRoundedPanel(panel1, 25);

            txtPassword.UseSystemPasswordChar = true;

            lblStudentId.Visible = false;
            txtStudentId.Visible = false;

            lblDepartment.Visible = false;
            cmbDepartment.Visible = false;

            lblAdminId.Visible = false;
            txtAdminId.Visible = false;

            lblLicenseNo.Visible = false;
            txtLicenseNo.Visible = false;

            lblPhone.Visible = false;
            txtPhone.Visible = false;

            cmbRole.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;

            this.Resize += RegisterForm_Resize;
            RegisterForm_Resize(this, EventArgs.Empty);
        }

        private void RegisterForm_Load(
            object sender,
            EventArgs e)
        {
            RegisterForm_Resize(this, EventArgs.Empty);
        }

        private void RegisterForm_Resize(
            object sender,
            EventArgs e)
        {
            int centerX = ClientSize.Width / 2;
            int centerY = ClientSize.Height / 2;

            panel1.Location = new System.Drawing.Point(
                centerX + 25,
                centerY - panel1.Height / 2);
        }

        private void comboBox1_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            string role =
                cmbRole.SelectedItem?
                    .ToString() ?? "";

            if (role == "Student")
            {
                lblStudentId.Visible = true;
                txtStudentId.Visible = true;

                lblDepartment.Visible = true;
                cmbDepartment.Visible = true;

                lblAdminId.Visible = false;
                txtAdminId.Visible = false;

                lblLicenseNo.Visible = false;
                txtLicenseNo.Visible = false;

                lblPhone.Visible = false;
                txtPhone.Visible = false;

                txtAdminId.Clear();

                txtLicenseNo.Clear();
                txtPhone.Clear();
            }

            else if (role == "Driver")
            {
                lblStudentId.Visible = false;
                txtStudentId.Visible = false;

                lblDepartment.Visible = false;
                cmbDepartment.Visible = false;

                lblAdminId.Visible = false;
                txtAdminId.Visible = false;

                lblLicenseNo.Visible = true;
                txtLicenseNo.Visible = true;

                lblPhone.Visible = true;
                txtPhone.Visible = true;

                txtStudentId.Clear();

                cmbDepartment.SelectedIndex = -1;

                txtAdminId.Clear();
            }

            else if (role == "Admin")
            {
                lblStudentId.Visible = false;
                txtStudentId.Visible = false;

                lblDepartment.Visible = false;
                cmbDepartment.Visible = false;

                lblAdminId.Visible = true;
                txtAdminId.Visible = true;

                lblLicenseNo.Visible = false;
                txtLicenseNo.Visible = false;

                lblPhone.Visible = false;
                txtPhone.Visible = false;

                txtStudentId.Clear();

                cmbDepartment.SelectedIndex = -1;

                txtLicenseNo.Clear();
                txtPhone.Clear();
            }

            else
            {
                lblStudentId.Visible = false;
                txtStudentId.Visible = false;

                lblDepartment.Visible = false;
                cmbDepartment.Visible = false;

                lblAdminId.Visible = false;
                txtAdminId.Visible = false;

                lblLicenseNo.Visible = false;
                txtLicenseNo.Visible = false;

                lblPhone.Visible = false;
                txtPhone.Visible = false;
            }
        }

        private void btnRegister_Click(
            object sender,
            EventArgs e)
        {
            string name =
                txtFullName.Text.Trim();

            string username =
                txtUsername.Text.Trim();

            string password =
                txtPassword.Text;

            string email =
                txtEmail.Text.Trim();

            string role =
                cmbRole.SelectedItem?
                    .ToString() ?? "";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Registration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Valid email na check
            if (!Regex.IsMatch(
                    email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(
                    "Please enter a valid email address.\n\nExample: example@gmail.com",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (role == "Student")
            {
                if (string.IsNullOrWhiteSpace(
                        txtStudentId.Text) ||
                    cmbDepartment.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Please enter Student ID and select Department.",
                        "Student Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            if (role == "Driver")
            {
                if (string.IsNullOrWhiteSpace(
                        txtLicenseNo.Text) ||
                    string.IsNullOrWhiteSpace(
                        txtPhone.Text))
                {
                    MessageBox.Show(
                        "Please enter License Number and Phone Number.",
                        "Driver Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            if (role == "Admin")
            {
                if (string.IsNullOrWhiteSpace(
                        txtAdminId.Text))
                {
                    MessageBox.Show(
                        "Please enter Admin ID.",
                        "Admin Registration",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            try
            {
                User user =
                    new User
                    {
                        Name = name,
                        Username = username,
                        Password = password,
                        Email = email,
                        Role = role,
                        Status = "Pending"
                    };

                UserRepository userRepository =
                    new UserRepository();

                int userId =
                    userRepository.Create(user);

                if (role == "Student")
                {
                    StudentProfile studentProfile =
                        new StudentProfile
                        {
                            UserId = userId,

                            StudentId =
                                txtStudentId.Text.Trim(),

                            Department =
                                cmbDepartment
                                    .SelectedItem?
                                    .ToString(),

                            Email = email
                        };

                    StudentProfileRepository
                        studentRepository =
                            new StudentProfileRepository();

                    studentRepository.Create(
                        studentProfile);
                }

                else if (role == "Driver")
                {
                    DriverProfile driverProfile =
                        new DriverProfile
                        {
                            UserId = userId,

                            LicenseNo =
                                txtLicenseNo.Text.Trim(),

                            Phone =
                                txtPhone.Text.Trim()
                        };

                    DriverProfileRepository
                        driverRepository =
                            new DriverProfileRepository();

                    driverRepository.Create(
                        driverProfile);
                }

                MessageBox.Show(
                    "Registration successful!\n\n" +
                    "Please wait for admin approval.",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Registration failed.\n\n" +
                    ex.Message,
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtEmail.Clear();

            txtStudentId.Clear();
            cmbDepartment.SelectedIndex = -1;

            txtAdminId.Clear();

            txtLicenseNo.Clear();
            txtPhone.Clear();

            cmbRole.SelectedIndex = -1;

            lblStudentId.Visible = false;
            txtStudentId.Visible = false;

            lblDepartment.Visible = false;
            cmbDepartment.Visible = false;

            lblAdminId.Visible = false;
            txtAdminId.Visible = false;

            lblLicenseNo.Visible = false;
            txtLicenseNo.Visible = false;

            lblPhone.Visible = false;
            txtPhone.Visible = false;
        }

        private void txtPhone_TextChanged(
            object sender,
            EventArgs e)
        {
        }

        private void label8_Click(
            object sender,
            EventArgs e)
        {
        }

        private void cmbDepartment_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            LoginForm loginForm =
                new LoginForm();

            loginForm.Show();

            this.Hide();
        }

        private void lblTitle_Click(
            object sender,
            EventArgs e)
        {
        }

        private void MakeRoundedPanel(
            Panel panel,
            int radius)
        {
            GraphicsPath path =
                new GraphicsPath();

            path.AddArc(
                0,
                0,
                radius,
                radius,
                180,
                90);

            path.AddArc(
                panel.Width - radius,
                0,
                radius,
                radius,
                270,
                90);

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

            panel.Region =
                new System.Drawing.Region(path);
        }

        private void label6_Click(
            object sender,
            EventArgs e)
        {
        }
    }
}