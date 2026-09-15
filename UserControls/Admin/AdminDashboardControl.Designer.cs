namespace AIUBBusManagementSystem.UserControls.Admin
{
    partial class AdminDashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================================
        // HEADER
        // =====================================================

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAdmin;
        private System.Windows.Forms.Button buttonLogout;

        // =====================================================
        // MENU
        // =====================================================

        private System.Windows.Forms.Panel panelMenu;

        private System.Windows.Forms.Button buttonManageRoutes;
        private System.Windows.Forms.Button buttonManageStudent;
        private System.Windows.Forms.Button buttonManageDriver;
        private System.Windows.Forms.Button buttonAssignBus;
        private System.Windows.Forms.Button buttonManageAdmin;
        private System.Windows.Forms.Button buttonReports;

        // =====================================================
        // MAIN PANELS
        // =====================================================

        private System.Windows.Forms.Panel panelManageRoutes;
        private System.Windows.Forms.Panel panelManageStudents;
        private System.Windows.Forms.Panel panelManageDriver;
        private System.Windows.Forms.Panel panelAssignBus;
        private System.Windows.Forms.Panel panelManageAdmin;
        private System.Windows.Forms.Panel panelReports;

        // =====================================================
        // STUDENTS
        // =====================================================

        private System.Windows.Forms.Label labelMSSearch;
        private System.Windows.Forms.TextBox textBoxMSUsername;
        private System.Windows.Forms.Button buttonMSSearch;
        private System.Windows.Forms.Button buttonMSActive;
        private System.Windows.Forms.Button buttonMSBlock;
        private System.Windows.Forms.DataGridView dgvManageStudents;

        // =====================================================
        // DRIVERS
        // =====================================================

        private System.Windows.Forms.Label labelMDSearch;
        private System.Windows.Forms.TextBox textBoxMDSearch;
        private System.Windows.Forms.Button buttonMDSearch;
        private System.Windows.Forms.Button buttonMDActive;
        private System.Windows.Forms.Button buttonMDBlock;
        private System.Windows.Forms.Button buttonMDRemove;
        private System.Windows.Forms.DataGridView dgvManageDriver;

        // =====================================================
        // ROUTES
        // =====================================================

        private System.Windows.Forms.Label labelMRRouteName;
        private System.Windows.Forms.TextBox textBoxMRRouteName;
        private System.Windows.Forms.Label labelMRDirection;
        private System.Windows.Forms.ComboBox comboBoxMRDirection;
        private System.Windows.Forms.Button buttonMRCreateRoute;

        private System.Windows.Forms.Label labelMRLocationName;
        private System.Windows.Forms.TextBox textBoxMRLocationName;
        private System.Windows.Forms.Button buttonMRAddLocation;

        private System.Windows.Forms.DataGridView dgvMRRoutes;
        private System.Windows.Forms.DataGridView dgvMRLocations;

        // =====================================================
        // ASSIGN BUS
        // =====================================================

        private System.Windows.Forms.Label labelABRoute;
        private System.Windows.Forms.ComboBox comboBoxABRoute;
        private System.Windows.Forms.Label labelABDriver;
        private System.Windows.Forms.ComboBox comboBoxABDriver;
        private System.Windows.Forms.Label labelABTimeSlot;
        private System.Windows.Forms.ComboBox comboBoxABTimeSlot;
        private System.Windows.Forms.Label labelABDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerAssignBus;
        private System.Windows.Forms.Button buttonABAssign;
        private System.Windows.Forms.DataGridView dgvAssignBus;

        // =====================================================
        // ADMIN
        // =====================================================

        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.Button btnApproveAdmin;
        private System.Windows.Forms.Button btnBlockAdmin;

        // =====================================================
        // REPORT
        // =====================================================

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label labelRTotalCollectedAmount;
        private System.Windows.Forms.Button buttonRRefresh;

        // =====================================================
        // DISPOSE
        // =====================================================

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // =====================================================
        // INITIALIZE COMPONENT
        // =====================================================

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnChangePassword = new Button();
            labelTitle = new Label();
            labelAdmin = new Label();
            buttonLogout = new Button();
            panelMenu = new Panel();
            buttonManageDriver = new Button();
            buttonManageStudent = new Button();
            buttonManageRoutes = new Button();
            buttonAssignBus = new Button();
            buttonManageAdmin = new Button();
            buttonReports = new Button();
            panelManageRoutes = new Panel();
            labelMRRouteName = new Label();
            textBoxMRRouteName = new TextBox();
            labelMRDirection = new Label();
            comboBoxMRDirection = new ComboBox();
            buttonMRCreateRoute = new Button();
            dgvMRRoutes = new DataGridView();
            labelMRLocationName = new Label();
            textBoxMRLocationName = new TextBox();
            buttonMRAddLocation = new Button();
            dgvMRLocations = new DataGridView();
            panelManageStudents = new Panel();
            dgvManageStudents = new DataGridView();
            labelMSSearch = new Label();
            textBoxMSUsername = new TextBox();
            buttonMSSearch = new Button();
            buttonMSActive = new Button();
            buttonMSBlock = new Button();
            panelManageDriver = new Panel();
            labelMDSearch = new Label();
            textBoxMDSearch = new TextBox();
            buttonMDSearch = new Button();
            buttonMDActive = new Button();
            buttonMDBlock = new Button();
            buttonMDRemove = new Button();
            dgvManageDriver = new DataGridView();
            panelAssignBus = new Panel();
            labelABBus = new Label();
            comboBoxABBus = new ComboBox();
            labelABRoute = new Label();
            comboBoxABRoute = new ComboBox();
            labelABDriver = new Label();
            comboBoxABDriver = new ComboBox();
            labelABTimeSlot = new Label();
            comboBoxABTimeSlot = new ComboBox();
            labelABDate = new Label();
            dateTimePickerAssignBus = new DateTimePicker();
            buttonABAssign = new Button();
            dgvAssignBus = new DataGridView();
            panelManageAdmin = new Panel();
            dgvAdmin = new DataGridView();
            btnApproveAdmin = new Button();
            btnBlockAdmin = new Button();
            panelReports = new Panel();
            labelRTotalCollectedAmount = new Label();
            buttonRRefresh = new Button();
            dgvReport = new DataGridView();
            abelMRFare = new Label();
            textBoxMRFare = new TextBox();
            panelHeader.SuspendLayout();
            panelMenu.SuspendLayout();
            panelManageRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMRRoutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMRLocations).BeginInit();
            panelManageStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManageStudents).BeginInit();
            panelManageDriver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManageDriver).BeginInit();
            panelAssignBus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignBus).BeginInit();
            panelManageAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdmin).BeginInit();
            panelReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.SteelBlue;
            panelHeader.Controls.Add(btnChangePassword);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelAdmin);
            panelHeader.Controls.Add(buttonLogout);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 60);
            panelHeader.TabIndex = 0;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.DodgerBlue;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(605, 13);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(145, 39);
            btnChangePassword.TabIndex = 3;
            btnChangePassword.Text = "Change password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.Black;
            labelTitle.Location = new Point(5, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(348, 37);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "AIUB Bus Management System";
            // 
            // labelAdmin
            // 
            labelAdmin.AutoSize = true;
            labelAdmin.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelAdmin.ForeColor = Color.White;
            labelAdmin.Location = new Point(380, 14);
            labelAdmin.Name = "labelAdmin";
            labelAdmin.Size = new Size(105, 38);
            labelAdmin.TabIndex = 1;
            labelAdmin.Text = "Admin";
            // 
            // buttonLogout
            // 
            buttonLogout.BackColor = Color.LimeGreen;
            buttonLogout.FlatAppearance.BorderColor = Color.White;
            buttonLogout.FlatStyle = FlatStyle.Flat;
            buttonLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonLogout.ForeColor = Color.White;
            buttonLogout.Location = new Point(772, 13);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(114, 39);
            buttonLogout.TabIndex = 2;
            buttonLogout.Text = "Logout";
            buttonLogout.UseVisualStyleBackColor = false;
            buttonLogout.Click += buttonLogout_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.DodgerBlue;
            panelMenu.Controls.Add(buttonManageDriver);
            panelMenu.Controls.Add(buttonManageStudent);
            panelMenu.Controls.Add(buttonManageRoutes);
            panelMenu.Controls.Add(buttonAssignBus);
            panelMenu.Controls.Add(buttonManageAdmin);
            panelMenu.Controls.Add(buttonReports);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.Location = new Point(0, 60);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(900, 55);
            panelMenu.TabIndex = 1;
            // 
            // buttonManageDriver
            // 
            buttonManageDriver.BackColor = Color.SteelBlue;
            buttonManageDriver.FlatAppearance.BorderColor = Color.White;
            buttonManageDriver.FlatAppearance.BorderSize = 2;
            buttonManageDriver.FlatStyle = FlatStyle.Flat;
            buttonManageDriver.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonManageDriver.ForeColor = Color.White;
            buttonManageDriver.Location = new Point(305, 7);
            buttonManageDriver.Name = "buttonManageDriver";
            buttonManageDriver.Size = new Size(145, 40);
            buttonManageDriver.TabIndex = 2;
            buttonManageDriver.Text = "Manage Driver";
            buttonManageDriver.UseVisualStyleBackColor = false;
            buttonManageDriver.Click += buttonManageDriver_Click;
            // 
            // buttonManageStudent
            // 
            buttonManageStudent.BackColor = Color.SteelBlue;
            buttonManageStudent.FlatAppearance.BorderColor = Color.White;
            buttonManageStudent.FlatAppearance.BorderSize = 2;
            buttonManageStudent.FlatStyle = FlatStyle.Flat;
            buttonManageStudent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonManageStudent.ForeColor = Color.White;
            buttonManageStudent.Location = new Point(155, 7);
            buttonManageStudent.Name = "buttonManageStudent";
            buttonManageStudent.Size = new Size(145, 40);
            buttonManageStudent.TabIndex = 1;
            buttonManageStudent.Text = "Manage Students";
            buttonManageStudent.UseVisualStyleBackColor = false;
            buttonManageStudent.Click += buttonManageStudent_Click;
            // 
            // buttonManageRoutes
            // 
            buttonManageRoutes.BackColor = Color.SteelBlue;
            buttonManageRoutes.FlatAppearance.BorderColor = Color.White;
            buttonManageRoutes.FlatAppearance.BorderSize = 2;
            buttonManageRoutes.FlatStyle = FlatStyle.Flat;
            buttonManageRoutes.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonManageRoutes.ForeColor = Color.White;
            buttonManageRoutes.Location = new Point(5, 7);
            buttonManageRoutes.Name = "buttonManageRoutes";
            buttonManageRoutes.Size = new Size(145, 40);
            buttonManageRoutes.TabIndex = 0;
            buttonManageRoutes.Text = "Manage Routes";
            buttonManageRoutes.UseVisualStyleBackColor = false;
            buttonManageRoutes.Click += buttonManageRoutes_Click;
            // 
            // buttonAssignBus
            // 
            buttonAssignBus.BackColor = Color.SteelBlue;
            buttonAssignBus.FlatAppearance.BorderColor = Color.White;
            buttonAssignBus.FlatAppearance.BorderSize = 2;
            buttonAssignBus.FlatStyle = FlatStyle.Flat;
            buttonAssignBus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonAssignBus.ForeColor = Color.White;
            buttonAssignBus.Location = new Point(455, 7);
            buttonAssignBus.Name = "buttonAssignBus";
            buttonAssignBus.Size = new Size(145, 40);
            buttonAssignBus.TabIndex = 3;
            buttonAssignBus.Text = "Assign Bus";
            buttonAssignBus.UseVisualStyleBackColor = false;
            buttonAssignBus.Click += buttonAssignBus_Click;
            // 
            // buttonManageAdmin
            // 
            buttonManageAdmin.BackColor = Color.SteelBlue;
            buttonManageAdmin.FlatAppearance.BorderColor = Color.White;
            buttonManageAdmin.FlatAppearance.BorderSize = 2;
            buttonManageAdmin.FlatStyle = FlatStyle.Flat;
            buttonManageAdmin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonManageAdmin.ForeColor = Color.White;
            buttonManageAdmin.Location = new Point(605, 7);
            buttonManageAdmin.Name = "buttonManageAdmin";
            buttonManageAdmin.Size = new Size(145, 40);
            buttonManageAdmin.TabIndex = 4;
            buttonManageAdmin.Text = "Manage Admin";
            buttonManageAdmin.UseVisualStyleBackColor = false;
            buttonManageAdmin.Click += buttonManageAdmin_Click;
            // 
            // buttonReports
            // 
            buttonReports.BackColor = Color.SteelBlue;
            buttonReports.FlatAppearance.BorderColor = Color.White;
            buttonReports.FlatAppearance.BorderSize = 2;
            buttonReports.FlatStyle = FlatStyle.Flat;
            buttonReports.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            buttonReports.ForeColor = Color.White;
            buttonReports.Location = new Point(755, 7);
            buttonReports.Name = "buttonReports";
            buttonReports.Size = new Size(140, 40);
            buttonReports.TabIndex = 5;
            buttonReports.Text = "Reports";
            buttonReports.UseVisualStyleBackColor = false;
            buttonReports.Click += buttonReports_Click;
            // 
            // panelManageRoutes
            // 
            panelManageRoutes.BackColor = Color.WhiteSmoke;
            panelManageRoutes.Controls.Add(textBoxMRFare);
            panelManageRoutes.Controls.Add(abelMRFare);
            panelManageRoutes.Controls.Add(labelMRRouteName);
            panelManageRoutes.Controls.Add(textBoxMRRouteName);
            panelManageRoutes.Controls.Add(labelMRDirection);
            panelManageRoutes.Controls.Add(comboBoxMRDirection);
            panelManageRoutes.Controls.Add(buttonMRCreateRoute);
            panelManageRoutes.Controls.Add(dgvMRRoutes);
            panelManageRoutes.Controls.Add(labelMRLocationName);
            panelManageRoutes.Controls.Add(textBoxMRLocationName);
            panelManageRoutes.Controls.Add(buttonMRAddLocation);
            panelManageRoutes.Controls.Add(dgvMRLocations);
            panelManageRoutes.Dock = DockStyle.Fill;
            panelManageRoutes.Location = new Point(0, 115);
            panelManageRoutes.Name = "panelManageRoutes";
            panelManageRoutes.Size = new Size(900, 500);
            panelManageRoutes.TabIndex = 2;
            // 
            // labelMRRouteName
            // 
            labelMRRouteName.AutoSize = true;
            labelMRRouteName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMRRouteName.Location = new Point(25, 18);
            labelMRRouteName.Name = "labelMRRouteName";
            labelMRRouteName.Size = new Size(92, 19);
            labelMRRouteName.TabIndex = 0;
            labelMRRouteName.Text = "Route Name";
            // 
            // textBoxMRRouteName
            // 
            textBoxMRRouteName.Location = new Point(115, 14);
            textBoxMRRouteName.Name = "textBoxMRRouteName";
            textBoxMRRouteName.Size = new Size(180, 23);
            textBoxMRRouteName.TabIndex = 1;
            // 
            // labelMRDirection
            // 
            labelMRDirection.AutoSize = true;
            labelMRDirection.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMRDirection.Location = new Point(320, 18);
            labelMRDirection.Name = "labelMRDirection";
            labelMRDirection.Size = new Size(70, 19);
            labelMRDirection.TabIndex = 2;
            labelMRDirection.Text = "Direction";
            labelMRDirection.Click += labelMRDirection_Click;
            // 
            // comboBoxMRDirection
            // 
            comboBoxMRDirection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMRDirection.Items.AddRange(new object[] { "AIUB to Dhaka", "Dhaka to AIUB" });
            comboBoxMRDirection.Location = new Point(390, 14);
            comboBoxMRDirection.Name = "comboBoxMRDirection";
            comboBoxMRDirection.Size = new Size(150, 23);
            comboBoxMRDirection.TabIndex = 2;
            comboBoxMRDirection.SelectedIndexChanged += comboBoxMRDirection_SelectedIndexChanged;
            // 
            // buttonMRCreateRoute
            // 
            buttonMRCreateRoute.BackColor = Color.SteelBlue;
            buttonMRCreateRoute.FlatStyle = FlatStyle.Flat;
            buttonMRCreateRoute.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonMRCreateRoute.ForeColor = Color.White;
            buttonMRCreateRoute.Location = new Point(560, 12);
            buttonMRCreateRoute.Name = "buttonMRCreateRoute";
            buttonMRCreateRoute.Size = new Size(125, 30);
            buttonMRCreateRoute.TabIndex = 3;
            buttonMRCreateRoute.Text = "Create Route";
            buttonMRCreateRoute.UseVisualStyleBackColor = false;
            buttonMRCreateRoute.Click += buttonMRCreateRoute_Click;
            // 
            // dgvMRRoutes
            // 
            dgvMRRoutes.AllowUserToAddRows = false;
            dgvMRRoutes.AllowUserToDeleteRows = false;
            dgvMRRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMRRoutes.BackgroundColor = Color.White;
            dgvMRRoutes.Location = new Point(20, 65);
            dgvMRRoutes.MultiSelect = false;
            dgvMRRoutes.Name = "dgvMRRoutes";
            dgvMRRoutes.ReadOnly = true;
            dgvMRRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMRRoutes.Size = new Size(395, 145);
            dgvMRRoutes.TabIndex = 3;
            dgvMRRoutes.SelectionChanged += dgvMRRoutes_SelectionChanged;
            // 
            // labelMRLocationName
            // 
            labelMRLocationName.AutoSize = true;
            labelMRLocationName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMRLocationName.Location = new Point(440, 260);
            labelMRLocationName.Name = "labelMRLocationName";
            labelMRLocationName.Size = new Size(110, 19);
            labelMRLocationName.TabIndex = 4;
            labelMRLocationName.Text = "Location Name";
            // 
            // textBoxMRLocationName
            // 
            textBoxMRLocationName.Location = new Point(440, 282);
            textBoxMRLocationName.Name = "textBoxMRLocationName";
            textBoxMRLocationName.Size = new Size(230, 23);
            textBoxMRLocationName.TabIndex = 5;
            // 
            // buttonMRAddLocation
            // 
            buttonMRAddLocation.BackColor = Color.SteelBlue;
            buttonMRAddLocation.FlatStyle = FlatStyle.Flat;
            buttonMRAddLocation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonMRAddLocation.ForeColor = Color.White;
            buttonMRAddLocation.Location = new Point(545, 385);
            buttonMRAddLocation.Name = "buttonMRAddLocation";
            buttonMRAddLocation.Size = new Size(125, 35);
            buttonMRAddLocation.TabIndex = 6;
            buttonMRAddLocation.Text = "Add Location";
            buttonMRAddLocation.UseVisualStyleBackColor = false;
            buttonMRAddLocation.Click += buttonMRAddLocation_Click;
            // 
            // dgvMRLocations
            // 
            dgvMRLocations.AllowUserToAddRows = false;
            dgvMRLocations.AllowUserToDeleteRows = false;
            dgvMRLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMRLocations.BackgroundColor = Color.White;
            dgvMRLocations.Location = new Point(440, 65);
            dgvMRLocations.MultiSelect = false;
            dgvMRLocations.Name = "dgvMRLocations";
            dgvMRLocations.ReadOnly = true;
            dgvMRLocations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMRLocations.Size = new Size(380, 145);
            dgvMRLocations.TabIndex = 4;
            // 
            // panelManageStudents
            // 
            panelManageStudents.BackColor = Color.WhiteSmoke;
            panelManageStudents.Controls.Add(dgvManageStudents);
            panelManageStudents.Controls.Add(labelMSSearch);
            panelManageStudents.Controls.Add(textBoxMSUsername);
            panelManageStudents.Controls.Add(buttonMSSearch);
            panelManageStudents.Controls.Add(buttonMSActive);
            panelManageStudents.Controls.Add(buttonMSBlock);
            panelManageStudents.Dock = DockStyle.Fill;
            panelManageStudents.Location = new Point(0, 115);
            panelManageStudents.Name = "panelManageStudents";
            panelManageStudents.Size = new Size(900, 500);
            panelManageStudents.TabIndex = 3;
            panelManageStudents.Visible = false;
            // 
            // dgvManageStudents
            // 
            dgvManageStudents.AllowUserToAddRows = false;
            dgvManageStudents.AllowUserToDeleteRows = false;
            dgvManageStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManageStudents.BackgroundColor = Color.White;
            dgvManageStudents.Location = new Point(25, 60);
            dgvManageStudents.MultiSelect = false;
            dgvManageStudents.Name = "dgvManageStudents";
            dgvManageStudents.ReadOnly = true;
            dgvManageStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManageStudents.Size = new Size(840, 380);
            dgvManageStudents.TabIndex = 5;
            // 
            // labelMSSearch
            // 
            labelMSSearch.AutoSize = true;
            labelMSSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMSSearch.Location = new Point(25, 18);
            labelMSSearch.Name = "labelMSSearch";
            labelMSSearch.Size = new Size(115, 19);
            labelMSSearch.TabIndex = 0;
            labelMSSearch.Text = "Search Students";
            // 
            // textBoxMSUsername
            // 
            textBoxMSUsername.Location = new Point(150, 14);
            textBoxMSUsername.Name = "textBoxMSUsername";
            textBoxMSUsername.Size = new Size(230, 23);
            textBoxMSUsername.TabIndex = 1;
            // 
            // buttonMSSearch
            // 
            buttonMSSearch.BackColor = Color.SteelBlue;
            buttonMSSearch.FlatStyle = FlatStyle.Flat;
            buttonMSSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMSSearch.ForeColor = Color.White;
            buttonMSSearch.Location = new Point(395, 11);
            buttonMSSearch.Name = "buttonMSSearch";
            buttonMSSearch.Size = new Size(90, 30);
            buttonMSSearch.TabIndex = 2;
            buttonMSSearch.Text = "Search";
            buttonMSSearch.UseVisualStyleBackColor = false;
            buttonMSSearch.Click += buttonMSSearch_Click;
            // 
            // buttonMSActive
            // 
            buttonMSActive.BackColor = Color.SteelBlue;
            buttonMSActive.FlatStyle = FlatStyle.Flat;
            buttonMSActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMSActive.ForeColor = Color.White;
            buttonMSActive.Location = new Point(500, 11);
            buttonMSActive.Name = "buttonMSActive";
            buttonMSActive.Size = new Size(90, 30);
            buttonMSActive.TabIndex = 3;
            buttonMSActive.Text = "Active";
            buttonMSActive.UseVisualStyleBackColor = false;
            buttonMSActive.Click += buttonMSActive_Click;
            // 
            // buttonMSBlock
            // 
            buttonMSBlock.BackColor = Color.SteelBlue;
            buttonMSBlock.FlatStyle = FlatStyle.Flat;
            buttonMSBlock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMSBlock.ForeColor = Color.White;
            buttonMSBlock.Location = new Point(605, 11);
            buttonMSBlock.Name = "buttonMSBlock";
            buttonMSBlock.Size = new Size(90, 30);
            buttonMSBlock.TabIndex = 4;
            buttonMSBlock.Text = "Block";
            buttonMSBlock.UseVisualStyleBackColor = false;
            buttonMSBlock.Click += buttonMSBlock_Click;
            // 
            // panelManageDriver
            // 
            panelManageDriver.BackColor = Color.WhiteSmoke;
            panelManageDriver.Controls.Add(labelMDSearch);
            panelManageDriver.Controls.Add(textBoxMDSearch);
            panelManageDriver.Controls.Add(buttonMDSearch);
            panelManageDriver.Controls.Add(buttonMDActive);
            panelManageDriver.Controls.Add(buttonMDBlock);
            panelManageDriver.Controls.Add(buttonMDRemove);
            panelManageDriver.Controls.Add(dgvManageDriver);
            panelManageDriver.Dock = DockStyle.Fill;
            panelManageDriver.Location = new Point(0, 115);
            panelManageDriver.Name = "panelManageDriver";
            panelManageDriver.Size = new Size(900, 500);
            panelManageDriver.TabIndex = 4;
            panelManageDriver.Visible = false;
            // 
            // labelMDSearch
            // 
            labelMDSearch.AutoSize = true;
            labelMDSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMDSearch.Location = new Point(25, 18);
            labelMDSearch.Name = "labelMDSearch";
            labelMDSearch.Size = new Size(100, 19);
            labelMDSearch.TabIndex = 0;
            labelMDSearch.Text = "Search Driver";
            // 
            // textBoxMDSearch
            // 
            textBoxMDSearch.Location = new Point(150, 14);
            textBoxMDSearch.Name = "textBoxMDSearch";
            textBoxMDSearch.Size = new Size(230, 23);
            textBoxMDSearch.TabIndex = 1;
            // 
            // buttonMDSearch
            // 
            buttonMDSearch.BackColor = Color.SteelBlue;
            buttonMDSearch.FlatStyle = FlatStyle.Flat;
            buttonMDSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMDSearch.ForeColor = Color.White;
            buttonMDSearch.Location = new Point(395, 11);
            buttonMDSearch.Name = "buttonMDSearch";
            buttonMDSearch.Size = new Size(85, 30);
            buttonMDSearch.TabIndex = 2;
            buttonMDSearch.Text = "Search";
            buttonMDSearch.UseVisualStyleBackColor = false;
            buttonMDSearch.Click += buttonMDSearch_Click;
            // 
            // buttonMDActive
            // 
            buttonMDActive.BackColor = Color.SteelBlue;
            buttonMDActive.FlatStyle = FlatStyle.Flat;
            buttonMDActive.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMDActive.ForeColor = Color.White;
            buttonMDActive.Location = new Point(490, 11);
            buttonMDActive.Name = "buttonMDActive";
            buttonMDActive.Size = new Size(85, 30);
            buttonMDActive.TabIndex = 3;
            buttonMDActive.Text = "Active";
            buttonMDActive.UseVisualStyleBackColor = false;
            buttonMDActive.Click += buttonMDActive_Click;
            // 
            // buttonMDBlock
            // 
            buttonMDBlock.BackColor = Color.SteelBlue;
            buttonMDBlock.FlatStyle = FlatStyle.Flat;
            buttonMDBlock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMDBlock.ForeColor = Color.White;
            buttonMDBlock.Location = new Point(585, 11);
            buttonMDBlock.Name = "buttonMDBlock";
            buttonMDBlock.Size = new Size(85, 30);
            buttonMDBlock.TabIndex = 4;
            buttonMDBlock.Text = "Block";
            buttonMDBlock.UseVisualStyleBackColor = false;
            buttonMDBlock.Click += buttonMDBlock_Click;
            // 
            // buttonMDRemove
            // 
            buttonMDRemove.BackColor = Color.SteelBlue;
            buttonMDRemove.FlatStyle = FlatStyle.Flat;
            buttonMDRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonMDRemove.ForeColor = Color.White;
            buttonMDRemove.Location = new Point(680, 11);
            buttonMDRemove.Name = "buttonMDRemove";
            buttonMDRemove.Size = new Size(85, 30);
            buttonMDRemove.TabIndex = 5;
            buttonMDRemove.Text = "Remove";
            buttonMDRemove.UseVisualStyleBackColor = false;
            buttonMDRemove.Click += buttonMDRemove_Click;
            // 
            // dgvManageDriver
            // 
            dgvManageDriver.AllowUserToAddRows = false;
            dgvManageDriver.AllowUserToDeleteRows = false;
            dgvManageDriver.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManageDriver.BackgroundColor = Color.White;
            dgvManageDriver.Location = new Point(25, 60);
            dgvManageDriver.MultiSelect = false;
            dgvManageDriver.Name = "dgvManageDriver";
            dgvManageDriver.ReadOnly = true;
            dgvManageDriver.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManageDriver.Size = new Size(840, 380);
            dgvManageDriver.TabIndex = 6;
            // 
            // panelAssignBus
            // 
            panelAssignBus.BackColor = Color.WhiteSmoke;
            panelAssignBus.Controls.Add(labelABBus);
            panelAssignBus.Controls.Add(comboBoxABBus);
            panelAssignBus.Controls.Add(labelABRoute);
            panelAssignBus.Controls.Add(comboBoxABRoute);
            panelAssignBus.Controls.Add(labelABDriver);
            panelAssignBus.Controls.Add(comboBoxABDriver);
            panelAssignBus.Controls.Add(labelABTimeSlot);
            panelAssignBus.Controls.Add(comboBoxABTimeSlot);
            panelAssignBus.Controls.Add(labelABDate);
            panelAssignBus.Controls.Add(dateTimePickerAssignBus);
            panelAssignBus.Controls.Add(buttonABAssign);
            panelAssignBus.Controls.Add(dgvAssignBus);
            panelAssignBus.Dock = DockStyle.Fill;
            panelAssignBus.Location = new Point(0, 115);
            panelAssignBus.Name = "panelAssignBus";
            panelAssignBus.Size = new Size(900, 500);
            panelAssignBus.TabIndex = 5;
            panelAssignBus.Visible = false;
            // 
            // labelABBus
            // 
            labelABBus.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelABBus.Location = new Point(300, 63);
            labelABBus.Name = "labelABBus";
            labelABBus.Size = new Size(46, 23);
            labelABBus.TabIndex = 11;
            labelABBus.Text = "Bus";
            // 
            // comboBoxABBus
            // 
            comboBoxABBus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxABBus.FormattingEnabled = true;
            comboBoxABBus.Location = new Point(360, 61);
            comboBoxABBus.Name = "comboBoxABBus";
            comboBoxABBus.Size = new Size(176, 23);
            comboBoxABBus.TabIndex = 10;
            // 
            // labelABRoute
            // 
            labelABRoute.AutoSize = true;
            labelABRoute.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelABRoute.Location = new Point(25, 20);
            labelABRoute.Name = "labelABRoute";
            labelABRoute.Size = new Size(48, 19);
            labelABRoute.TabIndex = 0;
            labelABRoute.Text = "Route";
            // 
            // comboBoxABRoute
            // 
            comboBoxABRoute.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxABRoute.Location = new Point(90, 16);
            comboBoxABRoute.Name = "comboBoxABRoute";
            comboBoxABRoute.Size = new Size(180, 23);
            comboBoxABRoute.TabIndex = 1;
            // 
            // labelABDriver
            // 
            labelABDriver.AutoSize = true;
            labelABDriver.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelABDriver.Location = new Point(300, 20);
            labelABDriver.Name = "labelABDriver";
            labelABDriver.Size = new Size(51, 19);
            labelABDriver.TabIndex = 2;
            labelABDriver.Text = "Driver";
            // 
            // comboBoxABDriver
            // 
            comboBoxABDriver.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxABDriver.Location = new Point(360, 16);
            comboBoxABDriver.Name = "comboBoxABDriver";
            comboBoxABDriver.Size = new Size(180, 23);
            comboBoxABDriver.TabIndex = 3;
            // 
            // labelABTimeSlot
            // 
            labelABTimeSlot.AutoSize = true;
            labelABTimeSlot.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelABTimeSlot.Location = new Point(570, 20);
            labelABTimeSlot.Name = "labelABTimeSlot";
            labelABTimeSlot.Size = new Size(72, 19);
            labelABTimeSlot.TabIndex = 4;
            labelABTimeSlot.Text = "Time Slot";
            // 
            // comboBoxABTimeSlot
            // 
            comboBoxABTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxABTimeSlot.Location = new Point(640, 16);
            comboBoxABTimeSlot.FormattingEnabled = true;
            comboBoxABTimeSlot.Name = "comboBoxABTimeSlot";
            comboBoxABTimeSlot.Size = new Size(150, 23);
            comboBoxABTimeSlot.TabIndex = 5;
            // 
            // labelABDate
            // 
            labelABDate.AutoSize = true;
            labelABDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelABDate.Location = new Point(25, 65);
            labelABDate.Name = "labelABDate";
            labelABDate.Size = new Size(40, 19);
            labelABDate.TabIndex = 6;
            labelABDate.Text = "Date";
            // 
            // dateTimePickerAssignBus
            // 
            dateTimePickerAssignBus.Format = DateTimePickerFormat.Short;
            dateTimePickerAssignBus.Location = new Point(90, 61);
            dateTimePickerAssignBus.Name = "dateTimePickerAssignBus";
            dateTimePickerAssignBus.Size = new Size(180, 23);
            dateTimePickerAssignBus.TabIndex = 7;
            // 
            // buttonABAssign
            // 
            buttonABAssign.BackColor = Color.SteelBlue;
            buttonABAssign.FlatStyle = FlatStyle.Flat;
            buttonABAssign.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonABAssign.ForeColor = Color.White;
            buttonABAssign.Location = new Point(670, 58);
            buttonABAssign.Name = "buttonABAssign";
            buttonABAssign.Size = new Size(120, 30);
            buttonABAssign.TabIndex = 8;
            buttonABAssign.Text = "Assign Bus";
            buttonABAssign.UseVisualStyleBackColor = false;
            buttonABAssign.Click += buttonABAssign_Click;
            // 
            // dgvAssignBus
            // 
            dgvAssignBus.AllowUserToAddRows = false;
            dgvAssignBus.AllowUserToDeleteRows = false;
            dgvAssignBus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssignBus.BackgroundColor = Color.White;
            dgvAssignBus.Location = new Point(25, 110);
            dgvAssignBus.MultiSelect = false;
            dgvAssignBus.Name = "dgvAssignBus";
            dgvAssignBus.ReadOnly = true;
            dgvAssignBus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssignBus.Size = new Size(840, 330);
            dgvAssignBus.TabIndex = 9;
            // 
            // panelManageAdmin
            // 
            panelManageAdmin.BackColor = Color.WhiteSmoke;
            panelManageAdmin.Controls.Add(dgvAdmin);
            panelManageAdmin.Controls.Add(btnApproveAdmin);
            panelManageAdmin.Controls.Add(btnBlockAdmin);
            panelManageAdmin.Dock = DockStyle.Fill;
            panelManageAdmin.Location = new Point(0, 115);
            panelManageAdmin.Name = "panelManageAdmin";
            panelManageAdmin.Size = new Size(900, 500);
            panelManageAdmin.TabIndex = 6;
            panelManageAdmin.Visible = false;
            // 
            // dgvAdmin
            // 
            dgvAdmin.AllowUserToAddRows = false;
            dgvAdmin.AllowUserToDeleteRows = false;
            dgvAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAdmin.BackgroundColor = Color.White;
            dgvAdmin.Location = new Point(25, 46);
            dgvAdmin.MultiSelect = false;
            dgvAdmin.Name = "dgvAdmin";
            dgvAdmin.ReadOnly = true;
            dgvAdmin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmin.Size = new Size(840, 350);
            dgvAdmin.TabIndex = 0;
            // 
            // btnApproveAdmin
            // 
            btnApproveAdmin.BackColor = Color.SteelBlue;
            btnApproveAdmin.FlatStyle = FlatStyle.Flat;
            btnApproveAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnApproveAdmin.ForeColor = Color.White;
            btnApproveAdmin.Location = new Point(25, 405);
            btnApproveAdmin.Name = "btnApproveAdmin";
            btnApproveAdmin.Size = new Size(130, 35);
            btnApproveAdmin.TabIndex = 1;
            btnApproveAdmin.Text = "Approve Admin";
            btnApproveAdmin.UseVisualStyleBackColor = false;
            btnApproveAdmin.Click += btnApproveAdmin_Click;
            // 
            // btnBlockAdmin
            // 
            btnBlockAdmin.BackColor = Color.SteelBlue;
            btnBlockAdmin.FlatStyle = FlatStyle.Flat;
            btnBlockAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBlockAdmin.ForeColor = Color.White;
            btnBlockAdmin.Location = new Point(170, 405);
            btnBlockAdmin.Name = "btnBlockAdmin";
            btnBlockAdmin.Size = new Size(130, 35);
            btnBlockAdmin.TabIndex = 2;
            btnBlockAdmin.Text = "Block Admin";
            btnBlockAdmin.UseVisualStyleBackColor = false;
            btnBlockAdmin.Click += btnBlockAdmin_Click;
            // 
            // panelReports
            // 
            panelReports.BackColor = Color.WhiteSmoke;
            panelReports.Controls.Add(labelRTotalCollectedAmount);
            panelReports.Controls.Add(buttonRRefresh);
            panelReports.Controls.Add(dgvReport);
            panelReports.Dock = DockStyle.Fill;
            panelReports.Location = new Point(0, 115);
            panelReports.Name = "panelReports";
            panelReports.Size = new Size(900, 500);
            panelReports.TabIndex = 7;
            panelReports.Visible = false;
            // 
            // labelRTotalCollectedAmount
            // 
            labelRTotalCollectedAmount.AutoSize = true;
            labelRTotalCollectedAmount.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            labelRTotalCollectedAmount.Location = new Point(38, 29);
            labelRTotalCollectedAmount.Name = "labelRTotalCollectedAmount";
            labelRTotalCollectedAmount.Size = new Size(257, 25);
            labelRTotalCollectedAmount.TabIndex = 0;
            labelRTotalCollectedAmount.Text = "Total Collected Amount: 0.00";
            // 
            // buttonRRefresh
            // 
            buttonRRefresh.BackColor = Color.SteelBlue;
            buttonRRefresh.FlatStyle = FlatStyle.Flat;
            buttonRRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            buttonRRefresh.ForeColor = Color.White;
            buttonRRefresh.Location = new Point(710, 22);
            buttonRRefresh.Name = "buttonRRefresh";
            buttonRRefresh.Size = new Size(120, 32);
            buttonRRefresh.TabIndex = 1;
            buttonRRefresh.Text = "Refresh";
            buttonRRefresh.UseVisualStyleBackColor = false;
            buttonRRefresh.Click += buttonRRefresh_Click;
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.Location = new Point(35, 68);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(840, 380);
            dgvReport.TabIndex = 2;
            dgvReport.CellContentClick += dgvReport_CellContentClick;
            // 
            // abelMRFare
            // 
            abelMRFare.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            abelMRFare.Location = new Point(440, 319);
            abelMRFare.Name = "abelMRFare";
            abelMRFare.Size = new Size(58, 23);
            abelMRFare.TabIndex = 7;
            abelMRFare.Text = "Fare";
            // 
            // textBoxMRFare
            // 
            textBoxMRFare.Location = new Point(440, 345);
            textBoxMRFare.Name = "textBoxMRFare";
            textBoxMRFare.Size = new Size(230, 23);
            textBoxMRFare.TabIndex = 8;
            // 
            // AdminDashboardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelManageRoutes);
            Controls.Add(panelManageStudents);
            Controls.Add(panelManageDriver);
            Controls.Add(panelAssignBus);
            Controls.Add(panelManageAdmin);
            Controls.Add(panelReports);
            Controls.Add(panelMenu);
            Controls.Add(panelHeader);
            Name = "AdminDashboardControl";
            Size = new Size(900, 615);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelManageRoutes.ResumeLayout(false);
            panelManageRoutes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMRRoutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMRLocations).EndInit();
            panelManageStudents.ResumeLayout(false);
            panelManageStudents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManageStudents).EndInit();
            panelManageDriver.ResumeLayout(false);
            panelManageDriver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvManageDriver).EndInit();
            panelAssignBus.ResumeLayout(false);
            panelAssignBus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignBus).EndInit();
            panelManageAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdmin).EndInit();
            panelReports.ResumeLayout(false);
            panelReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        private Button btnChangePassword;
        private Label labelABBus;
        private ComboBox comboBoxABBus;
        private TextBox textBoxMRFare;
        private Label abelMRFare;
    }
}