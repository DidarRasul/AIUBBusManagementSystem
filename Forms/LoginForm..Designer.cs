namespace AIUBBusManagementSystem
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
        /// Required method for Designer support -
        /// do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtPassword = new TextBox();
            textBox2 = new TextBox();
            lblPassword = new Label();
            btnLogin = new Button();
            btnRegister = new Button();
            lblTitle = new Label();
            chkShowPassword = new CheckBox();
            btnClear = new Button();
            btnExit = new Button();
            linkForgotPassword = new LinkLabel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(28, 102);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(118, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "👤 Username:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(28, 195);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 27);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(28, 127);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(280, 27);
            textBox2.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(28, 170);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(113, 21);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "🔒 Password:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LimeGreen;
            btnLogin.BackgroundImageLayout = ImageLayout.Center;
            btnLogin.FlatAppearance.BorderColor = Color.Black;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = Color.Black;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(28, 284);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(137, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "→ Log In";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += button1_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.CornflowerBlue;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(28, 321);
            btnRegister.Margin = new Padding(3, 4, 3, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(280, 30);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "👤+ Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 49);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(404, 106);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "AIUB BUS\n MANAGEMENT SYSTEM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkShowPassword.Location = new Point(28, 230);
            chkShowPassword.Margin = new Padding(3, 4, 3, 4);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(108, 19);
            chkShowPassword.TabIndex = 7;
            chkShowPassword.Text = "Show Password";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(171, 285);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 30);
            btnClear.TabIndex = 8;
            btnClear.Text = "\U0001f9f9 Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(193, 359);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(115, 33);
            btnExit.TabIndex = 9;
            btnExit.Text = "✕ Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // linkForgotPassword
            // 
            linkForgotPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkForgotPassword.Location = new Point(201, 225);
            linkForgotPassword.Name = "linkForgotPassword";
            linkForgotPassword.Size = new Size(127, 27);
            linkForgotPassword.TabIndex = 10;
            linkForgotPassword.TabStop = true;
            linkForgotPassword.Text = "Forgot Password";
            linkForgotPassword.TextAlign = ContentAlignment.MiddleCenter;
            linkForgotPassword.LinkClicked += linkForgotPassword_LinkClicked;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblUsername);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnRegister);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(lblPassword);
            panel1.Controls.Add(linkForgotPassword);
            panel1.Controls.Add(chkShowPassword);
            panel1.Location = new Point(513, 74);
            panel1.Name = "panel1";
            panel1.Size = new Size(329, 423);
            panel1.TabIndex = 11;
            panel1.Paint += panel1_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.bus_logo_2;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(28, 17);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 50);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(95, 37);
            label1.Name = "label1";
            label1.Size = new Size(165, 30);
            label1.TabIndex = 11;
            label1.Text = "Welcome Back!";
            // 
            // LoginForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.back_pic;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(884, 561);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIUB Bus Management System - Login";
            Load += LoginForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblUsername;
        private TextBox txtPassword;
        private TextBox textBox2;
        private Label lblPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblTitle;
        private CheckBox chkShowPassword;
        private Button btnClear;
        private Button btnExit;
        private LinkLabel linkForgotPassword;
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}