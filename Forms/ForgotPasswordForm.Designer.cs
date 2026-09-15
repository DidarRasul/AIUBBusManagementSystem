namespace AIUBBusManagementSystem.Forms
{
    partial class ForgotPasswordForm
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
            labelUsername = new Label();
            txtUsername = new TextBox();
            labelNewPassword = new Label();
            txtNewPassword = new TextBox();
            labelConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnResetPassword = new Button();
            panel1 = new Panel();
            lblForgotPassword2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btnCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelUsername
            // 
            labelUsername.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUsername.Location = new Point(65, 120);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(109, 26);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "👤Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(67, 149);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(189, 23);
            txtUsername.TabIndex = 1;
            // 
            // labelNewPassword
            // 
            labelNewPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelNewPassword.Location = new Point(65, 186);
            labelNewPassword.Name = "labelNewPassword";
            labelNewPassword.Size = new Size(142, 23);
            labelNewPassword.TabIndex = 2;
            labelNewPassword.Text = "🔒New Password:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(65, 212);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(191, 23);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // labelConfirmPassword
            // 
            labelConfirmPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelConfirmPassword.Location = new Point(65, 249);
            labelConfirmPassword.Name = "labelConfirmPassword";
            labelConfirmPassword.Size = new Size(163, 23);
            labelConfirmPassword.TabIndex = 4;
            labelConfirmPassword.Text = "🔒Confirm Password:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(65, 275);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(191, 23);
            txtConfirmPassword.TabIndex = 5;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.LimeGreen;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetPassword.Location = new Point(47, 331);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(127, 34);
            btnResetPassword.TabIndex = 6;
            btnResetPassword.Text = "🔑 Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(lblForgotPassword2);
            panel1.Controls.Add(labelUsername);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(labelNewPassword);
            panel1.Controls.Add(txtNewPassword);
            panel1.Controls.Add(labelConfirmPassword);
            panel1.Controls.Add(txtConfirmPassword);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnResetPassword);
            panel1.Location = new Point(452, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(374, 430);
            panel1.TabIndex = 8;
            // 
            // lblForgotPassword2
            // 
            lblForgotPassword2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblForgotPassword2.Location = new Point(67, 24);
            lblForgotPassword2.Name = "lblForgotPassword2";
            lblForgotPassword2.Size = new Size(255, 41);
            lblForgotPassword2.TabIndex = 8;
            lblForgotPassword2.Text = "Forgot Password";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.bus_logo_1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(118, 252);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(133, 141);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(55, 401);
            label1.Name = "label1";
            label1.Size = new Size(258, 30);
            label1.TabIndex = 10;
            label1.Text = "Smart • Safe • Connected";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.CornflowerBlue;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(195, 331);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSkyBlue;
            ClientSize = new Size(884, 561);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "ForgotPasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Forgot Password";
            Load += ForgotPasswordForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUsername;
        private TextBox txtUsername;
        private Label labelNewPassword;
        private TextBox txtNewPassword;
        private Label labelConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnResetPassword;
        private Panel panel1;
        private Label lblForgotPassword2;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnCancel;
    }
}