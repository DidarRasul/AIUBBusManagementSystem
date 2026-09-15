namespace AIUBBusManagementSystem.Forms
{
    partial class ChangePasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            lblNewPassword = new Label();
            lblConfirmPassword = new Label();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            btnChangePassword = new Button();
            panel1 = new Panel();
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(26, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(248, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Change Password 🔓";
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentPassword.Location = new Point(36, 68);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(159, 20);
            lblCurrentPassword.TabIndex = 1;
            lblCurrentPassword.Text = "🔒Current Password:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Location = new Point(36, 91);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(207, 23);
            txtCurrentPassword.TabIndex = 2;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNewPassword.Location = new Point(36, 127);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(148, 23);
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "🔒New Password:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.Location = new Point(36, 191);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(167, 23);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "🔒Confirm Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(36, 153);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(207, 23);
            txtNewPassword.TabIndex = 5;
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.TextChanged += txtNewPassword_TextChanged;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(36, 217);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(207, 23);
            txtConfirmPassword.TabIndex = 6;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.LimeGreen;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePassword.Location = new Point(57, 260);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(173, 32);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "ꄗ Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.TitleBar;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(lblCurrentPassword);
            panel1.Controls.Add(txtCurrentPassword);
            panel1.Controls.Add(btnChangePassword);
            panel1.Controls.Add(lblNewPassword);
            panel1.Controls.Add(txtNewPassword);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(lblConfirmPassword);
            panel1.Controls.Add(lblTitle);
            panel1.Location = new Point(510, 95);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 362);
            panel1.TabIndex = 8;
            panel1.Paint += panel1_Paint;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.CornflowerBlue;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(57, 298);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(173, 32);
            btnBack.TabIndex = 8;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.change_pass_bus;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(161, 154);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 156);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.LightSkyBlue;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(106, 313);
            label1.Name = "label1";
            label1.Size = new Size(261, 32);
            label1.TabIndex = 10;
            label1.Text = "Smart • Safe • Connected";
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(884, 561);
            Size = new Size(900, 600);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "ChangePasswordForm";
            Text = "ChangePasswordForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Button btnChangePassword;
        private Panel panel1;
        private Button btnBack;
        private PictureBox pictureBox1;
        private Label label1;
    }
}