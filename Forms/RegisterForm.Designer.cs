namespace AIUBBusManagementSystem.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            cmbRole = new ComboBox();
            btnRegister = new Button();
            btnBack = new Button();
            label5 = new Label();
            txtEmail = new TextBox();
            lblTitle = new Label();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblDepartment = new Label();
            cmbDepartment = new ComboBox();
            lblLicenseNo = new Label();
            txtLicenseNo = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAdminId = new Label();
            txtAdminId = new TextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.Location = new Point(30, 75);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 20;
            label1.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(126, 76);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(200, 23);
            txtFullName.TabIndex = 19;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(126, 106);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(30, 105);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 17;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(30, 137);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 16;
            label3.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(126, 138);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 15;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label4.Location = new Point(31, 211);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 14;
            label4.Text = "Role:";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "Student", "Driver" });
            cmbRole.Location = new Point(126, 212);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(150, 23);
            cmbRole.TabIndex = 13;
            cmbRole.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.LimeGreen;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(226, 419);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 40);
            btnRegister.TabIndex = 12;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.CornflowerBlue;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(64, 419);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label5.Location = new Point(31, 171);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 10;
            label5.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(126, 172);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 9;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(5, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(343, 40);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Enter Your Informations\r\n";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblStudentId.Location = new Point(30, 244);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(88, 20);
            lblStudentId.TabIndex = 7;
            lblStudentId.Text = "Student ID:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(126, 245);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(200, 23);
            txtStudentId.TabIndex = 6;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblDepartment.Location = new Point(30, 277);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(98, 20);
            lblDepartment.TabIndex = 5;
            lblDepartment.Text = "Department:";
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Items.AddRange(new object[] { "CSE", "CS", "EEE", "BBA", "MBA" });
            cmbDepartment.Location = new Point(126, 277);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(150, 23);
            cmbDepartment.TabIndex = 4;
            cmbDepartment.SelectedIndexChanged += cmbDepartment_SelectedIndexChanged;
            // 
            // lblLicenseNo
            // 
            lblLicenseNo.AutoSize = true;
            lblLicenseNo.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblLicenseNo.Location = new Point(31, 339);
            lblLicenseNo.Name = "lblLicenseNo";
            lblLicenseNo.Size = new Size(89, 20);
            lblLicenseNo.TabIndex = 3;
            lblLicenseNo.Text = "License No:";
            // 
            // txtLicenseNo
            // 
            txtLicenseNo.Location = new Point(126, 340);
            txtLicenseNo.Name = "txtLicenseNo";
            txtLicenseNo.Size = new Size(200, 23);
            txtLicenseNo.TabIndex = 2;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            lblPhone.Location = new Point(30, 369);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(82, 20);
            lblPhone.TabIndex = 1;
            lblPhone.Text = "Phone No:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(125, 370);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 0;
            txtPhone.TextChanged += txtPhone_TextChanged;
            // 
            // lblAdminId
            // 
            lblAdminId.AutoSize = true;
            lblAdminId.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAdminId.Location = new Point(30, 307);
            lblAdminId.Name = "lblAdminId";
            lblAdminId.Size = new Size(80, 20);
            lblAdminId.TabIndex = 21;
            lblAdminId.Text = "Admin ID:";
            // 
            // txtAdminId
            // 
            txtAdminId.Location = new Point(125, 308);
            txtAdminId.Name = "txtAdminId";
            txtAdminId.Size = new Size(200, 23);
            txtAdminId.TabIndex = 22;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(lblPhone);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lblAdminId);
            panel1.Controls.Add(lblLicenseNo);
            panel1.Controls.Add(txtAdminId);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(lblDepartment);
            panel1.Controls.Add(cmbDepartment);
            panel1.Controls.Add(lblStudentId);
            panel1.Controls.Add(txtStudentId);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtPhone);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtLicenseNo);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(467, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 475);
            panel1.TabIndex = 23;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            BackgroundImage = Properties.Resources._1stpic;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
            Controls.Add(panel1);
            DoubleBuffered = true;
            MinimumSize = new Size(900, 600);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIUB Bus Management System - Registration";
            Load += RegisterForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtFullName;
        private TextBox txtUsername;
        private Label label2;
        private Label label3;
        private TextBox txtPassword;
        private Label label4;
        private ComboBox cmbRole;
        private Button btnRegister;
        private Button btnBack;
        private Label label5;
        private TextBox txtEmail;
        private Label lblTitle;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblDepartment;
        private ComboBox cmbDepartment;
        private Label lblLicenseNo;
        private TextBox txtLicenseNo;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAdminId;
        private TextBox txtAdminId;
        private Panel panel1;
    }
}