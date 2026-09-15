namespace AIUBBusManagementSystem.UserControls.Student
{
    partial class StudentDashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Panel panelMenu;
        private Panel panelContent;

        private Panel panelPickupSelection;
        private Panel panelFeePayment;
        private Panel panelProfileUpdate;

        private Label labelTitle;
        private Label labelStudent;

        private Button buttonPickupSelection;
        private Button buttonFeePayment;
        private Button buttonProfileUpdate;
        private Button buttonLogout;

        private Label labelPickupTitle;
        private Label labelSlot;
        private Label labelRoute;

        private ComboBox comboBoxPSTimeSlot;
        private ComboBox comboBoxPSRoute;
        private GroupBox grpLocations;
        private Button buttonPSSavePickup;

        private Label labelFeeTitle;
        private Label labelFPTotalDue;
        private Label labelPayAmount;
        private TextBox textBoxFPAmount;
        private Button buttonFPPay;
        private DataGridView dgvFees;

        private Label labelProfileTitle;
        private Label labelStudentID;
        private Label labelDepartment;
        private Label labelEmail;
        private TextBox textBoxPUStudentID;
        private TextBox textBoxPUDepartment;
        private TextBox textBoxPUEmail;
        private Button buttonPUProfileUpdate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            labelTitle = new Label();
            labelStudent = new Label();
            buttonLogout = new Button();
            panelMenu = new Panel();
            buttonProfileUpdate = new Button();
            buttonFeePayment = new Button();
            buttonPickupSelection = new Button();
            panelContent = new Panel();
            panelPickupSelection = new Panel();
            labelPickupTitle = new Label();
            labelSlot = new Label();
            comboBoxPSTimeSlot = new ComboBox();
            labelRoute = new Label();
            comboBoxPSRoute = new ComboBox();
            grpLocations = new GroupBox();
            buttonPSSavePickup = new Button();
            panelFeePayment = new Panel();
            labelFeeTitle = new Label();
            labelFPTotalDue = new Label();
            labelPayAmount = new Label();
            textBoxFPAmount = new TextBox();
            buttonFPPay = new Button();
            dgvFees = new DataGridView();
            panelProfileUpdate = new Panel();
            labelProfileTitle = new Label();
            labelStudentID = new Label();
            textBoxPUStudentID = new TextBox();
            labelDepartment = new Label();
            textBoxPUDepartment = new TextBox();
            labelEmail = new Label();
            textBoxPUEmail = new TextBox();
            buttonPUProfileUpdate = new Button();
            panelHeader.SuspendLayout();
            panelMenu.SuspendLayout();
            panelContent.SuspendLayout();
            panelPickupSelection.SuspendLayout();
            panelFeePayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFees).BeginInit();
            panelProfileUpdate.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SteelBlue;
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelStudent);
            panelHeader.Controls.Add(buttonLogout);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 60);
            panelHeader.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(15, 14);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(364, 32);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "AIUB Bus Management System";
            // 
            // labelStudent
            // 
            labelStudent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelStudent.AutoSize = true;
            labelStudent.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelStudent.ForeColor = Color.White;
            labelStudent.Location = new Point(497, 22);
            labelStudent.Name = "labelStudent";
            labelStudent.Size = new Size(83, 25);
            labelStudent.TabIndex = 1;
            labelStudent.Text = "Student";
            // 
            // buttonLogout
            // 
            buttonLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLogout.BackColor = Color.DodgerBlue;
            buttonLogout.FlatStyle = FlatStyle.Popup;
            buttonLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(789, 19);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(90, 35);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DodgerBlue;
            panelMenu.Controls.Add(buttonProfileUpdate);
            panelMenu.Controls.Add(buttonFeePayment);
            panelMenu.Controls.Add(buttonPickupSelection);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 60);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(900, 55);
            panelMenu.TabIndex = 1;
            // 
            // buttonProfileUpdate
            // 
            buttonProfileUpdate.BackColor = Color.SteelBlue;
            buttonProfileUpdate.FlatAppearance.BorderSize = 0;
            buttonProfileUpdate.FlatStyle = FlatStyle.Flat;
            buttonProfileUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonProfileUpdate.ForeColor = Color.White;
            buttonProfileUpdate.Location = new Point(585, 5);
            buttonProfileUpdate.Name = "buttonProfileUpdate";
            buttonProfileUpdate.Size = new Size(285, 45);
            buttonProfileUpdate.TabIndex = 2;
            buttonProfileUpdate.Text = "Profile Update";
            buttonProfileUpdate.UseVisualStyleBackColor = false;
            buttonProfileUpdate.Click += buttonProfileUpdate_Click;
            // 
            // buttonFeePayment
            // 
            buttonFeePayment.BackColor = Color.SteelBlue;
            buttonFeePayment.FlatAppearance.BorderSize = 0;
            buttonFeePayment.FlatStyle = FlatStyle.Flat;
            buttonFeePayment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonFeePayment.ForeColor = Color.White;
            buttonFeePayment.Location = new Point(295, 5);
            buttonFeePayment.Name = "buttonFeePayment";
            buttonFeePayment.Size = new Size(285, 45);
            buttonFeePayment.TabIndex = 1;
            buttonFeePayment.Text = "Fee Payment";
            buttonFeePayment.UseVisualStyleBackColor = false;
            buttonFeePayment.Click += buttonFeePayment_Click;
            // 
            // buttonPickupSelection
            // 
            buttonPickupSelection.BackColor = Color.DodgerBlue;
            buttonPickupSelection.FlatAppearance.BorderSize = 0;
            buttonPickupSelection.FlatStyle = FlatStyle.Flat;
            buttonPickupSelection.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonPickupSelection.ForeColor = Color.White;
            buttonPickupSelection.Location = new Point(5, 5);
            buttonPickupSelection.Name = "buttonPickupSelection";
            buttonPickupSelection.Size = new Size(285, 45);
            buttonPickupSelection.TabIndex = 0;
            buttonPickupSelection.Text = "Pickup Selection";
            buttonPickupSelection.UseVisualStyleBackColor = false;
            buttonPickupSelection.Click += buttonPickupSelection_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.Controls.Add(panelPickupSelection);
            panelContent.Controls.Add(panelFeePayment);
            panelContent.Controls.Add(panelProfileUpdate);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 115);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(900, 485);
            panelContent.TabIndex = 2;
            // 
            // panelPickupSelection
            // 
            panelPickupSelection.BackColor = Color.WhiteSmoke;
            panelPickupSelection.Controls.Add(labelPickupTitle);
            panelPickupSelection.Controls.Add(labelSlot);
            panelPickupSelection.Controls.Add(comboBoxPSTimeSlot);
            panelPickupSelection.Controls.Add(labelRoute);
            panelPickupSelection.Controls.Add(comboBoxPSRoute);
            panelPickupSelection.Controls.Add(grpLocations);
            panelPickupSelection.Controls.Add(buttonPSSavePickup);
            panelPickupSelection.Dock = DockStyle.Fill;
            panelPickupSelection.Location = new Point(0, 0);
            panelPickupSelection.Name = "panelPickupSelection";
            panelPickupSelection.Size = new Size(900, 485);
            panelPickupSelection.TabIndex = 0;
            // 
            // labelPickupTitle
            // 
            labelPickupTitle.AutoSize = true;
            labelPickupTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelPickupTitle.Location = new Point(30, 25);
            labelPickupTitle.Name = "labelPickupTitle";
            labelPickupTitle.Size = new Size(202, 32);
            labelPickupTitle.TabIndex = 0;
            labelPickupTitle.Text = "Pickup Selection";
            // 
            // labelSlot
            // 
            labelSlot.AutoSize = true;
            labelSlot.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelSlot.Location = new Point(70, 90);
            labelSlot.Name = "labelSlot";
            labelSlot.Size = new Size(79, 20);
            labelSlot.TabIndex = 1;
            labelSlot.Text = "Time Slot:";
            // 
            // comboBoxPSTimeSlot
            // 
            comboBoxPSTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPSTimeSlot.Font = new Font("Segoe UI", 11F);
            comboBoxPSTimeSlot.Location = new Point(155, 85);
            comboBoxPSTimeSlot.Name = "comboBoxPSTimeSlot";
            comboBoxPSTimeSlot.Size = new Size(220, 28);
            comboBoxPSTimeSlot.TabIndex = 2;
            comboBoxPSTimeSlot.SelectedIndexChanged += comboBoxPSTimeSlot_SelectedIndexChanged;
            // 
            // labelRoute
            // 
            labelRoute.AutoSize = true;
            labelRoute.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelRoute.Location = new Point(420, 90);
            labelRoute.Name = "labelRoute";
            labelRoute.Size = new Size(55, 20);
            labelRoute.TabIndex = 3;
            labelRoute.Text = "Route:";
            // 
            // comboBoxPSRoute
            // 
            comboBoxPSRoute.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPSRoute.Font = new Font("Segoe UI", 11F);
            comboBoxPSRoute.Location = new Point(480, 85);
            comboBoxPSRoute.Name = "comboBoxPSRoute";
            comboBoxPSRoute.Size = new Size(220, 28);
            comboBoxPSRoute.TabIndex = 4;
            comboBoxPSRoute.SelectedIndexChanged += comboBoxPSRoute_SelectedIndexChanged;
            // 
            // grpLocations
            // 
            grpLocations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpLocations.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpLocations.Location = new Point(70, 145);
            grpLocations.Name = "grpLocations";
            grpLocations.Size = new Size(630, 210);
            grpLocations.TabIndex = 5;
            grpLocations.TabStop = false;
            grpLocations.Text = "Pickup Locations";
            // 
            // buttonPSSavePickup
            // 
            buttonPSSavePickup.BackColor = Color.SteelBlue;
            buttonPSSavePickup.FlatAppearance.BorderSize = 0;
            buttonPSSavePickup.FlatStyle = FlatStyle.Flat;
            buttonPSSavePickup.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonPSSavePickup.ForeColor = Color.White;
            buttonPSSavePickup.Location = new Point(300, 370);
            buttonPSSavePickup.Name = "buttonPSSavePickup";
            buttonPSSavePickup.Size = new Size(150, 40);
            buttonPSSavePickup.TabIndex = 6;
            buttonPSSavePickup.Text = "Save Pickup";
            buttonPSSavePickup.UseVisualStyleBackColor = false;
            buttonPSSavePickup.Click += buttonPSSavePickup_Click;
            // 
            // panelFeePayment
            // 
            panelFeePayment.BackColor = Color.White;
            panelFeePayment.Controls.Add(labelFeeTitle);
            panelFeePayment.Controls.Add(labelFPTotalDue);
            panelFeePayment.Controls.Add(labelPayAmount);
            panelFeePayment.Controls.Add(textBoxFPAmount);
            panelFeePayment.Controls.Add(buttonFPPay);
            panelFeePayment.Controls.Add(dgvFees);
            panelFeePayment.Dock = DockStyle.Fill;
            panelFeePayment.Location = new Point(0, 0);
            panelFeePayment.Name = "panelFeePayment";
            panelFeePayment.Size = new Size(900, 485);
            panelFeePayment.TabIndex = 1;
            panelFeePayment.Visible = false;
            // 
            // labelFeeTitle
            // 
            labelFeeTitle.AutoSize = true;
            labelFeeTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelFeeTitle.Location = new Point(30, 25);
            labelFeeTitle.Name = "labelFeeTitle";
            labelFeeTitle.Size = new Size(158, 32);
            labelFeeTitle.TabIndex = 0;
            labelFeeTitle.Text = "Fee Payment";
            // 
            // labelFPTotalDue
            // 
            labelFPTotalDue.AutoSize = true;
            labelFPTotalDue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelFPTotalDue.Location = new Point(60, 85);
            labelFPTotalDue.Name = "labelFPTotalDue";
            labelFPTotalDue.Size = new Size(122, 21);
            labelFPTotalDue.TabIndex = 1;
            labelFPTotalDue.Text = "Total Due: 0.00";
            // 
            // labelPayAmount
            // 
            labelPayAmount.AutoSize = true;
            labelPayAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelPayAmount.Location = new Point(270, 85);
            labelPayAmount.Name = "labelPayAmount";
            labelPayAmount.Size = new Size(100, 20);
            labelPayAmount.TabIndex = 2;
            labelPayAmount.Text = "Pay Amount:";
            // 
            // textBoxFPAmount
            // 
            textBoxFPAmount.Font = new Font("Segoe UI", 11F);
            textBoxFPAmount.Location = new Point(365, 80);
            textBoxFPAmount.Name = "textBoxFPAmount";
            textBoxFPAmount.Size = new Size(150, 27);
            textBoxFPAmount.TabIndex = 3;
            // 
            // buttonFPPay
            // 
            buttonFPPay.BackColor = Color.SteelBlue;
            buttonFPPay.FlatAppearance.BorderSize = 0;
            buttonFPPay.FlatStyle = FlatStyle.Flat;
            buttonFPPay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonFPPay.ForeColor = Color.White;
            buttonFPPay.Location = new Point(530, 78);
            buttonFPPay.Name = "buttonFPPay";
            buttonFPPay.Size = new Size(100, 35);
            buttonFPPay.TabIndex = 4;
            buttonFPPay.Text = "Pay";
            buttonFPPay.UseVisualStyleBackColor = false;
            buttonFPPay.Click += buttonFPPay_Click;
            // 
            // dgvFees
            // 
            dgvFees.AllowUserToAddRows = false;
            dgvFees.AllowUserToDeleteRows = false;
            dgvFees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFees.Location = new Point(30, 140);
            dgvFees.MultiSelect = false;
            dgvFees.Name = "dgvFees";
            dgvFees.ReadOnly = true;
            dgvFees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFees.Size = new Size(750, 300);
            dgvFees.TabIndex = 5;
            // 
            // panelProfileUpdate
            // 
            panelProfileUpdate.BackColor = Color.White;
            panelProfileUpdate.Controls.Add(labelProfileTitle);
            panelProfileUpdate.Controls.Add(labelStudentID);
            panelProfileUpdate.Controls.Add(textBoxPUStudentID);
            panelProfileUpdate.Controls.Add(labelDepartment);
            panelProfileUpdate.Controls.Add(textBoxPUDepartment);
            panelProfileUpdate.Controls.Add(labelEmail);
            panelProfileUpdate.Controls.Add(textBoxPUEmail);
            panelProfileUpdate.Controls.Add(buttonPUProfileUpdate);
            panelProfileUpdate.Dock = DockStyle.Fill;
            panelProfileUpdate.Location = new Point(0, 0);
            panelProfileUpdate.Name = "panelProfileUpdate";
            panelProfileUpdate.Size = new Size(900, 485);
            panelProfileUpdate.TabIndex = 2;
            panelProfileUpdate.Visible = false;
            // 
            // labelProfileTitle
            // 
            labelProfileTitle.AutoSize = true;
            labelProfileTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelProfileTitle.Location = new Point(30, 25);
            labelProfileTitle.Name = "labelProfileTitle";
            labelProfileTitle.Size = new Size(185, 32);
            labelProfileTitle.TabIndex = 0;
            labelProfileTitle.Text = "Student Profile";
            // 
            // labelStudentID
            // 
            labelStudentID.AutoSize = true;
            labelStudentID.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelStudentID.Location = new Point(70, 100);
            labelStudentID.Name = "labelStudentID";
            labelStudentID.Size = new Size(88, 20);
            labelStudentID.TabIndex = 1;
            labelStudentID.Text = "Student ID:";
            // 
            // textBoxPUStudentID
            // 
            textBoxPUStudentID.Font = new Font("Segoe UI", 11F);
            textBoxPUStudentID.Location = new Point(190, 95);
            textBoxPUStudentID.Name = "textBoxPUStudentID";
            textBoxPUStudentID.Size = new Size(300, 27);
            textBoxPUStudentID.TabIndex = 2;
            // 
            // labelDepartment
            // 
            labelDepartment.AutoSize = true;
            labelDepartment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelDepartment.Location = new Point(70, 155);
            labelDepartment.Name = "labelDepartment";
            labelDepartment.Size = new Size(98, 20);
            labelDepartment.TabIndex = 3;
            labelDepartment.Text = "Department:";
            // 
            // textBoxPUDepartment
            // 
            textBoxPUDepartment.Font = new Font("Segoe UI", 11F);
            textBoxPUDepartment.Location = new Point(190, 150);
            textBoxPUDepartment.Name = "textBoxPUDepartment";
            textBoxPUDepartment.Size = new Size(300, 27);
            textBoxPUDepartment.TabIndex = 4;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelEmail.Location = new Point(70, 210);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(51, 20);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Email:";
            // 
            // textBoxPUEmail
            // 
            textBoxPUEmail.Font = new Font("Segoe UI", 11F);
            textBoxPUEmail.Location = new Point(190, 205);
            textBoxPUEmail.Name = "textBoxPUEmail";
            textBoxPUEmail.Size = new Size(300, 27);
            textBoxPUEmail.TabIndex = 6;
            // 
            // buttonPUProfileUpdate
            // 
            buttonPUProfileUpdate.BackColor = Color.SteelBlue;
            buttonPUProfileUpdate.FlatAppearance.BorderSize = 0;
            buttonPUProfileUpdate.FlatStyle = FlatStyle.Flat;
            buttonPUProfileUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonPUProfileUpdate.ForeColor = Color.White;
            buttonPUProfileUpdate.Location = new Point(190, 270);
            buttonPUProfileUpdate.Name = "buttonPUProfileUpdate";
            buttonPUProfileUpdate.Size = new Size(160, 40);
            buttonPUProfileUpdate.TabIndex = 7;
            buttonPUProfileUpdate.Text = "Update Profile";
            buttonPUProfileUpdate.UseVisualStyleBackColor = false;
            buttonPUProfileUpdate.Click += buttonPUProfileUpdate_Click;
            // 
            // StudentDashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelHeader);
            Name = "StudentDashboardControl";
            Size = new Size(900, 600);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelPickupSelection.ResumeLayout(false);
            panelPickupSelection.PerformLayout();
            panelFeePayment.ResumeLayout(false);
            panelFeePayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFees).EndInit();
            panelProfileUpdate.ResumeLayout(false);
            panelProfileUpdate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}