using AIUBBusManagementSystem.Forms;
using AIUBBusManagementSystem.Repositories;
using AIUBBusManagementSystem.Services;
using AIUBBusManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AIUBBusManagementSystem.UserControls.Admin
{
    public partial class AdminDashboardControl : UserControl
    {
        // =====================================================
        // MENU COLORS
        // =====================================================

        private Button? activeMenuButton;

        private static readonly Color MenuNormalColor =
            Color.SteelBlue;

        private static readonly Color MenuActiveColor =
            Color.DodgerBlue;

        // =====================================================
        // SERVICES / REPOSITORIES
        // =====================================================

        private readonly AdminService adminService =
            new AdminService();

        private readonly UserRepository userRepository =
            new UserRepository();

        // =====================================================
        // CONSTRUCTOR
        // =====================================================

        public AdminDashboardControl()
        {
            InitializeComponent();

            // -------------------------------------------------
            // ROUTE DIRECTION
            // -------------------------------------------------

            if (comboBoxMRDirection != null)
            {
                comboBoxMRDirection.Items.Clear();

                comboBoxMRDirection.Items.Add(
                    "To University");

                comboBoxMRDirection.Items.Add(
                    "From University");

                comboBoxMRDirection.SelectedIndex = -1;

                comboBoxMRDirection.Text =
                    "Select Direction";
            }

            comboBoxABRoute.SelectedIndexChanged +=
                comboBoxABRoute_SelectedIndexChanged;
        }

        // =====================================================
        // LOAD DASHBOARD
        // =====================================================

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (LicenseManager.UsageMode ==
                LicenseUsageMode.Designtime)
            {
                return;
            }

            InitializeDashboard();
        }

        // =====================================================
        // INITIALIZE DASHBOARD
        // =====================================================

        private void InitializeDashboard()
        {
            HideAllContentPanels();

            SetActiveMenuButton(buttonManageRoutes);

            ShowPanel(panelManageRoutes);

            LoadRoutes();
        }

        // =====================================================
        // PANEL MANAGEMENT
        // =====================================================

        private void HideAllContentPanels()
        {
            if (panelManageRoutes != null)
                panelManageRoutes.Visible = false;

            if (panelManageStudents != null)
                panelManageStudents.Visible = false;

            if (panelManageDriver != null)
                panelManageDriver.Visible = false;

            if (panelAssignBus != null)
                panelAssignBus.Visible = false;

            if (panelManageAdmin != null)
                panelManageAdmin.Visible = false;

            if (panelReports != null)
                panelReports.Visible = false;
        }

        private void ShowPanel(Panel panel)
        {
            if (panel == null)
                return;

            HideAllContentPanels();

            panel.Visible = true;
        }

        // =====================================================
        // MENU BUTTONS
        // =====================================================

        private void buttonManageRoutes_Click(
            object sender,
            EventArgs e)
        {
            SetActiveMenuButton(sender as Button);

            ShowPanel(panelManageRoutes);

            LoadRoutes();
        }

        private void buttonManageStudent_Click(
            object sender,
            EventArgs e)
        {
            SetActiveMenuButton(sender as Button);

            ShowPanel(panelManageStudents);

            LoadStudents();
        }

        private void buttonManageDriver_Click(
            object sender,
            EventArgs e)
        {
            SetActiveMenuButton(sender as Button);

            ShowPanel(panelManageDriver);

            LoadDrivers();
        }

        private void buttonAssignBus_Click(
            object sender,
            EventArgs e)
        {
            SetActiveMenuButton(sender as Button);

            ShowPanel(panelAssignBus);

            InitializeAssignBusPanel();
        }

        private void buttonManageAdmin_Click(
            object sender,
            EventArgs e)
        {
            SetActiveMenuButton(sender as Button);

            ShowPanel(panelManageAdmin);

            LoadAdmins();
        }

        private void buttonReports_Click(
            object sender,
            EventArgs e)
        {
            SetActiveMenuButton(sender as Button);

            ShowPanel(panelReports);

            LoadReports();
        }

        // =====================================================
        // MANAGE STUDENTS
        // =====================================================

        private void LoadStudents()
        {
            try
            {
                dgvManageStudents.AutoGenerateColumns = true;

                dgvManageStudents.DataSource = null;

                dgvManageStudents.DataSource =
                    adminService.GetAllStudents();

                dgvManageStudents.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load students.\n\n" +
                    ex.Message,
                    "Student Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMSSearch_Click(
            object sender,
            EventArgs e)
        {
            string keyword =
                textBoxMSUsername.Text.Trim();

            try
            {
                dgvManageStudents.AutoGenerateColumns = true;

                dgvManageStudents.DataSource = null;

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dgvManageStudents.DataSource =
                        adminService.GetAllStudents();
                }
                else
                {
                    dgvManageStudents.DataSource =
                        adminService.GetAllStudents(keyword);
                }

                dgvManageStudents.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not search students.\n\n" +
                    ex.Message,
                    "Student Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMSActive_Click(
            object sender,
            EventArgs e)
        {
            if (!TryGetSelectedId(
                dgvManageStudents,
                out int userId))
            {
                MessageBox.Show(
                    "Please select a student.",
                    "Student Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirm =
                MessageBox.Show(
                    "Approve / activate this student?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                adminService.ActivateStudent(userId);

                LoadStudents();

                MessageBox.Show(
                    "Student activated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Student activation failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMSBlock_Click(
            object sender,
            EventArgs e)
        {
            if (!TryGetSelectedId(
                dgvManageStudents,
                out int userId))
            {
                MessageBox.Show(
                    "Please select a student.",
                    "Student Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirm =
                MessageBox.Show(
                    "Block this student?",
                    "Confirm Block",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                adminService.BlockStudent(userId);

                LoadStudents();

                MessageBox.Show(
                    "Student blocked successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Student blocking failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // MANAGE DRIVER
        // =====================================================

        private void LoadDrivers()
        {
            try
            {
                dgvManageDriver.AutoGenerateColumns = true;

                dgvManageDriver.DataSource = null;

                dgvManageDriver.DataSource =
                    adminService.GetAllDrivers();

                dgvManageDriver.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load drivers.\n\n" +
                    ex.Message,
                    "Driver Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMDSearch_Click(
            object sender,
            EventArgs e)
        {
            string keyword =
                textBoxMDSearch.Text.Trim();

            try
            {
                DataTable drivers =
                    adminService.GetAllDrivers();

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    DataView view =
                        drivers.DefaultView;

                    string safeKeyword =
                        keyword.Replace("'", "''");

                    view.RowFilter =
                        $"Name LIKE '%{safeKeyword}%'";

                    dgvManageDriver.DataSource =
                        view.ToTable();
                }
                else
                {
                    dgvManageDriver.DataSource =
                        drivers;
                }

                dgvManageDriver.AutoGenerateColumns =
                    true;

                dgvManageDriver.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not search drivers.\n\n" +
                    ex.Message,
                    "Driver Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMDActive_Click(
            object sender,
            EventArgs e)
        {
            if (!TryGetSelectedId(
                dgvManageDriver,
                out int userId))
            {
                MessageBox.Show(
                    "Please select a driver.",
                    "Driver Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirm =
                MessageBox.Show(
                    "Approve / activate this driver?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                userRepository.UpdateStatus(
                    userId,
                    "Active");

                LoadDrivers();

                MessageBox.Show(
                    "Driver approved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Driver approval failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMDBlock_Click(
            object sender,
            EventArgs e)
        {
            if (!TryGetSelectedId(
                dgvManageDriver,
                out int userId))
            {
                MessageBox.Show(
                    "Please select a driver.",
                    "Driver Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirm =
                MessageBox.Show(
                    "Block this driver?",
                    "Confirm Block",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                userRepository.UpdateStatus(
                    userId,
                    "Blocked");

                LoadDrivers();

                MessageBox.Show(
                    "Driver blocked successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Driver blocking failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMDRemove_Click(
            object sender,
            EventArgs e)
        {
            if (!TryGetSelectedId(
                dgvManageDriver,
                out int userId))
            {
                MessageBox.Show(
                    "Please select a driver.",
                    "Driver Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult confirm =
                MessageBox.Show(
                    "This will permanently delete this driver account.\n\n" +
                    "Do you want to continue?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                userRepository.Delete(userId);

                LoadDrivers();

                MessageBox.Show(
                    "Driver removed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Driver removal failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // COMMON GRID ID READER
        // =====================================================

        private bool TryGetSelectedId(
            DataGridView grid,
            out int userId)
        {
            userId = 0;

            if (grid == null)
                return false;

            if (grid.CurrentRow == null)
                return false;

            if (grid.CurrentRow.IsNewRow)
                return false;

            if (!grid.Columns.Contains("Id"))
                return false;

            object value =
                grid.CurrentRow
                    .Cells["Id"]
                    .Value;

            if (value == null ||
                value == DBNull.Value)
            {
                return false;
            }

            return int.TryParse(
                value.ToString(),
                out userId);
        }

        // =====================================================
        // MANAGE ADMIN
        // =====================================================

        private void LoadAdmins()
        {
            try
            {
                dgvAdmin.AutoGenerateColumns = true;

                dgvAdmin.DataSource = null;

                dgvAdmin.DataSource =
                    adminService.GetAllAdmins();

                if (dgvAdmin.Columns.Contains("Password"))
                {
                    dgvAdmin.Columns["Password"]
                        .Visible = false;
                }

                dgvAdmin.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load admin accounts.\n\n" +
                    ex.Message,
                    "Admin Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnApproveAdmin_Click(
            object sender,
            EventArgs e)
        {
            if (SessionManager.CurrentUser == null ||
                !string.Equals(
                    SessionManager.CurrentUser.Username,
                    "admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only the System Admin can approve or block admin accounts.",
                    "Admin Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!TryGetSelectedId(
                dgvAdmin,
                out int adminId))
            {
                MessageBox.Show(
                    "Please select an admin.",
                    "Admin Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to approve this admin account?",
                    "Confirm Approval",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                adminService.ApproveAdmin(adminId);

                LoadAdmins();

                MessageBox.Show(
                    "Admin approved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Approve admin failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnBlockAdmin_Click(
            object sender,
            EventArgs e)
        {
            if (SessionManager.CurrentUser == null ||
                !string.Equals(
                    SessionManager.CurrentUser.Username,
                    "admin",
                    StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "Only the System Admin can approve or block admin accounts.",
                    "Admin Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!TryGetSelectedId(
                dgvAdmin,
                out int adminId))
            {
                MessageBox.Show(
                    "Please select an admin.",
                    "Admin Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (adminId == SessionManager.CurrentUser.Id)
            {
                MessageBox.Show(
                    "The System Admin account cannot be blocked.",
                    "Admin Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to block this admin account?",
                    "Confirm Block",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                adminService.BlockAdmin(adminId);

                LoadAdmins();

                MessageBox.Show(
                    "Admin blocked successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Block admin failed.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // MENU BUTTON STYLE
        // =====================================================

        private void SetActiveMenuButton(
            Button? button)
        {
            if (activeMenuButton != null)
            {
                activeMenuButton.BackColor =
                    MenuNormalColor;
            }

            activeMenuButton = button;

            if (activeMenuButton != null)
            {
                activeMenuButton.BackColor =
                    MenuActiveColor;
            }
        }

        // =====================================================
        // MANAGE ROUTES
        // =====================================================

        private void textBoxMRRouteName_Enter(
            object sender,
            EventArgs e)
        {
            if (textBoxMRRouteName.Text ==
                "Route Name")
            {
                textBoxMRRouteName.Text = "";

                textBoxMRRouteName.ForeColor =
                    Color.Black;
            }
        }

        private void textBoxMRLocationName_Enter(
            object sender,
            EventArgs e)
        {
            if (textBoxMRLocationName.Text ==
                "Location Name")
            {
                textBoxMRLocationName.Text = "";

                textBoxMRLocationName.ForeColor =
                    Color.Black;
            }
        }

        private void buttonMRCreateRoute_Click(
            object sender,
            EventArgs e)
        {
            string routeName =
                textBoxMRRouteName.Text.Trim();

            string? direction =
                comboBoxMRDirection
                    .SelectedItem?
                    .ToString();

            if (string.IsNullOrWhiteSpace(routeName) ||
                routeName == "Route Name")
            {
                MessageBox.Show(
                    "Please enter a route name.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (string.IsNullOrWhiteSpace(direction))
            {
                MessageBox.Show(
                    "Please select a direction.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (direction != "To University" &&
                direction != "From University")
            {
                MessageBox.Show(
                    "Invalid route direction.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                string dbDirection =
                    direction == "To University"
                        ? "ToUniversity"
                        : "FromUniversity";

                adminService.CreateRoute(
                    routeName,
                    dbDirection);

                LoadRoutes();

                textBoxMRRouteName.Text =
                    "Route Name";

                textBoxMRRouteName.ForeColor =
                    Color.Gray;

                comboBoxMRDirection.SelectedIndex =
                    -1;

                comboBoxMRDirection.Text =
                    "Select Direction";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not create route.\n\n" +
                    ex.Message,
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonMRAddLocation_Click(
            object sender,
            EventArgs e)
        {
            if (dgvMRRoutes.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a route first.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string locationName =
                textBoxMRLocationName.Text.Trim();

            if (string.IsNullOrWhiteSpace(locationName) ||
                locationName == "Location Name")
            {
                MessageBox.Show(
                    "Please enter a location name.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!decimal.TryParse(
                    textBoxMRFare.Text.Trim(),
                    out decimal fare) ||
                fare < 0)
            {
                MessageBox.Show(
                    "Please enter a valid fare.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!TryGetSelectedId(
                dgvMRRoutes,
                out int selectedRouteId))
            {
                MessageBox.Show(
                    "Invalid selected route.",
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                adminService.AddLocationToRoute(
                    selectedRouteId,
                    locationName,
                    fare);

                LoadLocations(selectedRouteId);

                textBoxMRLocationName.Text =
                    "Location Name";

                textBoxMRLocationName.ForeColor =
                    Color.Gray;

                textBoxMRFare.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not add location.\n\n" +
                    ex.Message,
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadRoutes()
        {
            try
            {
                dgvMRRoutes.AutoGenerateColumns = true;

                dgvMRRoutes.DataSource = null;

                dgvMRRoutes.DataSource =
                    adminService.GetAllRoutes();

                if (dgvMRRoutes.Columns.Contains("Id"))
                {
                    dgvMRRoutes.Columns["Id"]
                        .Visible = false;
                }

                dgvMRRoutes.ClearSelection();

                dgvMRLocations.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load routes.\n\n" +
                    ex.Message,
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvMRRoutes_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvMRRoutes.CurrentRow == null)
                return;

            try
            {
                if (!TryGetSelectedId(
                    dgvMRRoutes,
                    out int routeId))
                {
                    return;
                }

                LoadLocations(routeId);
            }
            catch
            {
            }
        }

        private void LoadLocations(
            int routeId)
        {
            try
            {
                dgvMRLocations.AutoGenerateColumns =
                    true;

                dgvMRLocations.DataSource = null;

                dgvMRLocations.DataSource =
                    adminService.GetLocationsByRoute(
                        routeId);

                if (dgvMRLocations.Columns.Contains(
                    "Id"))
                {
                    dgvMRLocations.Columns["Id"]
                        .Visible = false;
                }

                if (dgvMRLocations.Columns.Contains(
                    "RouteId"))
                {
                    dgvMRLocations.Columns["RouteId"]
                        .Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load locations.\n\n" +
                    ex.Message,
                    "Route Management",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // ASSIGN BUS
        // =====================================================

        private void InitializeAssignBusPanel()
        {
            try
            {
                List<Models.Route> routes =
                    adminService.GetAllRoutes();

                comboBoxABRoute.DataSource = null;

                comboBoxABRoute.DisplayMember =
                    "RouteName";

                comboBoxABRoute.ValueMember =
                    "Id";

                comboBoxABRoute.DataSource =
                    routes;

                DataTable drivers =
                    adminService
                        .GetActiveDriversForAssignment();

                comboBoxABDriver.DataSource = null;

                comboBoxABDriver.DisplayMember =
                    "Name";

                comboBoxABDriver.ValueMember =
                    "Id";

                comboBoxABDriver.DataSource =
                    drivers;

                comboBoxABTimeSlot.DataSource = null;

                comboBoxABTimeSlot.Format -=
                    comboBoxABTimeSlot_Format;

                comboBoxABTimeSlot.Format +=
                    comboBoxABTimeSlot_Format;

                comboBoxABTimeSlot.DisplayMember =
                    nameof(Models.TimeSlot.Id);

                comboBoxABTimeSlot.ValueMember =
                    nameof(Models.TimeSlot.Id);

                if (comboBoxABRoute.SelectedIndex >= 0)
                {
                    comboBoxABRoute_SelectedIndexChanged(
                        comboBoxABRoute,
                        EventArgs.Empty);
                }

                DataTable buses =
                    adminService.GetAllBuses();

                comboBoxABBus.DataSource = null;

                comboBoxABBus.DisplayMember =
                    "BusName";

                comboBoxABBus.ValueMember =
                    "Id";

                comboBoxABBus.DataSource =
                    buses;

                LoadAssignmentsForPresentDay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not initialize bus assignment.\n\n" +
                    ex.Message,
                    "Assign Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void comboBoxABRoute_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (comboBoxABRoute.SelectedItem
                is not Models.Route selectedRoute)
            {
                return;
            }

            List<Models.TimeSlot> allSlots =
                adminService.GetAllTimeSlots();

            List<Models.TimeSlot> filteredSlots =
                new List<Models.TimeSlot>();

            string direction =
                selectedRoute.Direction?.Trim() ?? "";

            bool isToUniversity =
                direction.Equals(
                    "ToUniversity",
                    StringComparison.OrdinalIgnoreCase) ||
                direction.Equals(
                    "To University",
                    StringComparison.OrdinalIgnoreCase) ||
                direction.Equals(
                    "AIUB to Dhaka",
                    StringComparison.OrdinalIgnoreCase);

            bool isFromUniversity =
                direction.Equals(
                    "FromUniversity",
                    StringComparison.OrdinalIgnoreCase) ||
                direction.Equals(
                    "From University",
                    StringComparison.OrdinalIgnoreCase) ||
                direction.Equals(
                    "Dhaka to AIUB",
                    StringComparison.OrdinalIgnoreCase);

            foreach (Models.TimeSlot slot in allSlots)
            {
                if (isToUniversity &&
                    slot.StartTime <
                    new TimeSpan(13, 0, 0))
                {
                    filteredSlots.Add(slot);
                }
                else if (isFromUniversity &&
                         slot.StartTime >=
                         new TimeSpan(13, 0, 0))
                {
                    filteredSlots.Add(slot);
                }
            }

            comboBoxABTimeSlot.DataSource = null;

            comboBoxABTimeSlot.DisplayMember =
                nameof(Models.TimeSlot.Id);

            comboBoxABTimeSlot.ValueMember =
                nameof(Models.TimeSlot.Id);

            comboBoxABTimeSlot.DataSource =
                filteredSlots;
        }

        private void comboBoxABTimeSlot_Format(
            object? sender,
            ListControlConvertEventArgs e)
        {
            if (e.ListItem is Models.TimeSlot slot)
            {
                e.Value =
                    $"{slot.StartTime:hh\\:mm} - " +
                    $"{slot.EndTime:hh\\:mm}";
            }
        }

        private void LoadAssignmentsForPresentDay()
        {
            try
            {
                dgvAssignBus.AutoGenerateColumns =
                    true;

                dgvAssignBus.DataSource = null;

                dgvAssignBus.DataSource =
                    adminService
                        .GetAssignmentsByDateWithDetails(
                            dateTimePickerAssignBus.Value.Date);

                if (dgvAssignBus.Columns.Contains(
                    "Id"))
                {
                    dgvAssignBus.Columns["Id"]
                        .Visible = false;
                }

                if (dgvAssignBus.Columns.Contains(
                    "Date"))
                {
                    dgvAssignBus.Columns["Date"]
                        .DefaultCellStyle
                        .Format = "yyyy-MM-dd";
                }

                dgvAssignBus.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load bus assignments.\n\n" +
                    ex.Message,
                    "Assign Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonABAssign_Click(
            object sender,
            EventArgs e)
        {
            if (comboBoxABRoute.SelectedValue == null ||
                comboBoxABDriver.SelectedItem == null ||
                comboBoxABBus.SelectedValue == null ||
                comboBoxABTimeSlot.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select Route, Driver, Bus, and Time Slot.",
                    "Assign Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(
                    comboBoxABRoute
                        .SelectedValue?
                        .ToString(),
                    out int routeId) ||

                !int.TryParse(
                    comboBoxABBus
                        .SelectedValue?
                        .ToString(),
                    out int busId) ||

                !int.TryParse(
                    comboBoxABTimeSlot
                        .SelectedValue?
                        .ToString(),
                    out int timeSlotId))
            {
                MessageBox.Show(
                    "Invalid selections.",
                    "Assign Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int driverId;

            if (comboBoxABDriver.SelectedItem
                is DataRowView driverRow)
            {
                if (!int.TryParse(
                        driverRow["Id"]?.ToString(),
                        out driverId))
                {
                    MessageBox.Show(
                        "Invalid driver selection.",
                        "Assign Bus",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }
            else
            {
                MessageBox.Show(
                    "Invalid driver selection.",
                    "Assign Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                adminService.AssignBus(
                    routeId,
                    driverId,
                    busId,
                    timeSlotId,
                    dateTimePickerAssignBus.Value);

                LoadAssignmentsForPresentDay();

                MessageBox.Show(
                    "Bus assigned successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Assign Bus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // REPORTS
        // =====================================================

        private void LoadReports()
        {
            try
            {
                dgvReport.AutoGenerateColumns = true;

                dgvReport.DataSource = null;

                dgvReport.DataSource =
                    adminService.GetReport();

                decimal total =
                    adminService.GetTotalCollectedFees();

                labelRTotalCollectedAmount.Text =
                    $"Total Collected Amount: {total:0.00}";

                dgvReport.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load reports.\n\n" +
                    ex.Message,
                    "Reports",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonRRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadReports();
        }

        // =====================================================
        // LOGOUT
        // =====================================================

        private void buttonLogout_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to logout?",
                    "Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            SessionManager.EndSession();

            Application.Restart();
        }

        // =====================================================
        // EMPTY EVENTS
        // =====================================================

        private void dgvReport_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
        }

        private void panelReports_Paint(
            object sender,
            PaintEventArgs e)
        {
        }

        private void comboBoxMRDirection_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
        }

        private void labelMRDirection_Click(
            object sender,
            EventArgs e)
        {
        }

        // Amdmin change password
        private void btnChangePassword_Click(
            object sender,
            EventArgs e)
        {
            ChangePasswordForm form =
                new ChangePasswordForm();

            form.ShowDialog();
        }
    }
}