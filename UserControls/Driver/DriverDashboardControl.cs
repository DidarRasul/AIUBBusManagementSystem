using AIUBBusManagementSystem.Forms;
using AIUBBusManagementSystem.Services;
using AIUBBusManagementSystem.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace AIUBBusManagementSystem.UserControls.Driver
{
    public partial class DriverDashboardControl : UserControl
    {
        private readonly DriverService driverService =
            new DriverService();

        private int selectedAssignmentId = 0;
        private int selectedLocationId = 0;
        private int selectedStudentId = 0;

        public DriverDashboardControl()
        {
            InitializeComponent();

            LoadDriverInfo();
            LoadAssignments();

            dgvAssignments.SelectionChanged +=
                dgvAssignments_SelectionChanged;

            dgvPickupLocations.SelectionChanged +=
                dgvPickupLocations_SelectionChanged;

            dgvStudents.SelectionChanged +=
                dgvStudents_SelectionChanged;

            buttonMarkPicked.Click +=
                buttonMarkPicked_Click;
        }

        private void LoadDriverInfo()
        {
            if (SessionManager.CurrentUser == null)
            {
                labelDriverName.Text = "Driver:";
                return;
            }

            labelDriverName.Text =
                "Driver: " + SessionManager.CurrentUser.Username;
        }

        private void LoadAssignments()
        {
            try
            {
                DataTable assignments =
                    driverService.GetMyAssignments(DateTime.Today);

                dgvAssignments.DataSource = null;
                dgvAssignments.DataSource = assignments;

                dgvPickupLocations.DataSource = null;
                dgvStudents.DataSource = null;

                selectedAssignmentId = 0;
                selectedLocationId = 0;
                selectedStudentId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Driver Dashboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvAssignments_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (dgvAssignments.CurrentRow == null)
                return;

            if (!dgvAssignments.Columns.Contains("Id"))
                return;

            object assignmentValue =
                dgvAssignments.CurrentRow.Cells["Id"].Value;

            if (assignmentValue == null ||
                assignmentValue == DBNull.Value)
                return;

            selectedAssignmentId =
                Convert.ToInt32(assignmentValue);

            LoadPickupLocations();
        }

        private void LoadPickupLocations()
        {
            try
            {
                if (selectedAssignmentId == 0)
                    return;

                DataTable locations =
                    driverService.GetLocationCountsForAssignment(
                        selectedAssignmentId,
                        DateTime.Today);

                dgvPickupLocations.DataSource = null;
                dgvPickupLocations.DataSource = locations;

                dgvStudents.DataSource = null;

                selectedLocationId = 0;
                selectedStudentId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Pickup Locations",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvPickupLocations_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (dgvPickupLocations.CurrentRow == null)
                return;

            if (!dgvPickupLocations.Columns.Contains("LocationId"))
                return;

            object locationValue =
                dgvPickupLocations.CurrentRow.Cells["LocationId"].Value;

            if (locationValue == null ||
                locationValue == DBNull.Value)
                return;

            selectedLocationId =
                Convert.ToInt32(locationValue);

            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                if (selectedLocationId == 0 ||
                    selectedAssignmentId == 0)
                    return;

                DataTable students =
                    driverService.GetStudentsForLocationAndAssignment(
                        selectedLocationId,
                        selectedAssignmentId);

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;

                selectedStudentId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Students",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvStudents_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
                return;

            if (!dgvStudents.Columns.Contains("StudentUserId"))
                return;

            object studentValue =
                dgvStudents.CurrentRow.Cells["StudentUserId"].Value;

            if (studentValue == null ||
                studentValue == DBNull.Value)
                return;

            selectedStudentId =
                Convert.ToInt32(studentValue);
        }

        private void buttonMarkPicked_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                if (selectedAssignmentId == 0)
                {
                    MessageBox.Show(
                        "Please select an assignment.",
                        "Mark Picked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (selectedLocationId == 0)
                {
                    MessageBox.Show(
                        "Please select a pickup location.",
                        "Mark Picked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (selectedStudentId == 0)
                {
                    MessageBox.Show(
                        "Please select a student.",
                        "Mark Picked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                driverService.MarkStudentPicked(
                    selectedStudentId,
                    selectedAssignmentId,
                    selectedLocationId);

                MessageBox.Show(
                    "Student marked as picked successfully.",
                    "Mark Picked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Mark Picked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(
            object? sender,
            EventArgs e)
        {
            ChangePasswordForm form =
                new ChangePasswordForm();

            form.ShowDialog();
        }

        private void btnLogOut_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            SessionManager.EndSession();

            Application.Restart();
        }
    }
}