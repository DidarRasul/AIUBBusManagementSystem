namespace AIUBBusManagementSystem.UserControls.Driver
{
    partial class DriverDashboardControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelDriverName = new Label();
            dgvAssignments = new DataGridView();
            dgvStudents = new DataGridView();
            buttonMarkPicked = new Button();
            dgvPickupLocations = new DataGridView();
            lblAssignments = new Label();
            lblPickupLocations = new Label();
            lblStudents = new Label();
            lblDriver = new Label();
            btnChangePassword = new Button();
            btnLogOut = new Button();
            lblAIUBBUSMANAGEMENTSYSTEM = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPickupLocations).BeginInit();
            SuspendLayout();
            // 
            // labelDriverName
            // 
            labelDriverName.AutoSize = true;
            labelDriverName.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDriverName.Location = new Point(53, 52);
            labelDriverName.Name = "labelDriverName";
            labelDriverName.Size = new Size(57, 20);
            labelDriverName.TabIndex = 0;
            labelDriverName.Text = "Driver:";
            // 
            // dgvAssignments
            // 
            dgvAssignments.BackgroundColor = Color.LightGray;
            dgvAssignments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssignments.Location = new Point(53, 108);
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.Size = new Size(791, 132);
            dgvAssignments.TabIndex = 1;
            // 
            // dgvStudents
            // 
            dgvStudents.BackgroundColor = Color.LightGray;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(373, 301);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.Size = new Size(524, 238);
            dgvStudents.TabIndex = 2;
            // 
            // buttonMarkPicked
            // 
            buttonMarkPicked.BackColor = Color.PaleVioletRed;
            buttonMarkPicked.FlatStyle = FlatStyle.Flat;
            buttonMarkPicked.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonMarkPicked.Location = new Point(309, 545);
            buttonMarkPicked.Name = "buttonMarkPicked";
            buttonMarkPicked.Size = new Size(124, 37);
            buttonMarkPicked.TabIndex = 3;
            buttonMarkPicked.Text = "Mark Picked";
            buttonMarkPicked.UseVisualStyleBackColor = false;
            // 
            // dgvPickupLocations
            // 
            dgvPickupLocations.BackgroundColor = Color.LightGray;
            dgvPickupLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPickupLocations.Location = new Point(3, 299);
            dgvPickupLocations.Name = "dgvPickupLocations";
            dgvPickupLocations.Size = new Size(364, 240);
            dgvPickupLocations.TabIndex = 4;
            // 
            // lblAssignments
            // 
            lblAssignments.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAssignments.Location = new Point(53, 82);
            lblAssignments.Name = "lblAssignments";
            lblAssignments.Size = new Size(100, 23);
            lblAssignments.TabIndex = 5;
            lblAssignments.Text = "Assignments";
            // 
            // lblPickupLocations
            // 
            lblPickupLocations.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPickupLocations.Location = new Point(3, 271);
            lblPickupLocations.Name = "lblPickupLocations";
            lblPickupLocations.Size = new Size(127, 25);
            lblPickupLocations.TabIndex = 6;
            lblPickupLocations.Text = "Pickup Locations";
            // 
            // lblStudents
            // 
            lblStudents.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStudents.Location = new Point(373, 271);
            lblStudents.Name = "lblStudents";
            lblStudents.Size = new Size(76, 25);
            lblStudents.TabIndex = 7;
            lblStudents.Text = "Students";
            // 
            // lblDriver
            // 
            lblDriver.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDriver.Location = new Point(387, 11);
            lblDriver.Name = "lblDriver";
            lblDriver.Size = new Size(105, 42);
            lblDriver.TabIndex = 8;
            lblDriver.Text = "Driver";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.DodgerBlue;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePassword.Location = new Point(589, 21);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(154, 37);
            btnChangePassword.TabIndex = 9;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.BackColor = Color.LimeGreen;
            btnLogOut.FlatStyle = FlatStyle.Flat;
            btnLogOut.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogOut.Location = new Point(767, 21);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(106, 37);
            btnLogOut.TabIndex = 10;
            btnLogOut.Text = "Log Out";
            btnLogOut.UseVisualStyleBackColor = false;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // lblAIUBBUSMANAGEMENTSYSTEM
            // 
            lblAIUBBUSMANAGEMENTSYSTEM.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAIUBBUSMANAGEMENTSYSTEM.Location = new Point(15, 11);
            lblAIUBBUSMANAGEMENTSYSTEM.Name = "lblAIUBBUSMANAGEMENTSYSTEM";
            lblAIUBBUSMANAGEMENTSYSTEM.Size = new Size(329, 31);
            lblAIUBBUSMANAGEMENTSYSTEM.TabIndex = 11;
            lblAIUBBUSMANAGEMENTSYSTEM.Text = "AIUB BUS MANAGEMENT SYSTEM";
            // 
            // DriverDashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(lblAIUBBUSMANAGEMENTSYSTEM);
            Controls.Add(btnLogOut);
            Controls.Add(btnChangePassword);
            Controls.Add(lblDriver);
            Controls.Add(lblStudents);
            Controls.Add(lblPickupLocations);
            Controls.Add(lblAssignments);
            Controls.Add(dgvPickupLocations);
            Controls.Add(buttonMarkPicked);
            Controls.Add(dgvStudents);
            Controls.Add(dgvAssignments);
            Controls.Add(labelDriverName);
            Name = "DriverDashboardControl";
            Size = new Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPickupLocations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDriverName;
        private DataGridView dgvAssignments;
        private DataGridView dgvStudents;
        private Button buttonMarkPicked;
        private DataGridView dgvPickupLocations;
        private Label lblAssignments;
        private Label lblPickupLocations;
        private Label lblStudents;
        private Label lblDriver;
        private Button btnChangePassword;
        private Button btnLogOut;
        private Label lblAIUBBUSMANAGEMENTSYSTEM;
    }
}
