using AIUBBusManagementSystem.Forms;
using AIUBBusManagementSystem.Services;
using AIUBBusManagementSystem.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AIUBBusManagementSystem.UserControls.Student
{
    public partial class StudentDashboardControl : UserControl
    {
        private readonly AdminService adminService = new AdminService();
        private readonly StudentService studentService = new StudentService();

        private Button? activeMenuButton;
        private Button buttonPUChangePassword;

        private static readonly System.Drawing.Color MenuNormalColor =
            System.Drawing.Color.SteelBlue;

        private static readonly System.Drawing.Color MenuActiveColor =
            System.Drawing.Color.DodgerBlue;

        public StudentDashboardControl()
        {
            InitializeComponent();
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            HideAllContentPanels();

            SetActiveMenuButton(buttonPickupSelection);

            ShowPanel(panelPickupSelection);

            InitializePickupSelection();
        }

        private void HideAllContentPanels()
        {
            if (panelPickupSelection != null)
                panelPickupSelection.Visible = false;

            if (panelFeePayment != null)
                panelFeePayment.Visible = false;

            if (panelProfileUpdate != null)
                panelProfileUpdate.Visible = false;
        }

        private void ShowPanel(Panel panel)
        {
            HideAllContentPanels();

            panel.Visible = true;
            panel.BringToFront();
        }

        private void SetActiveMenuButton(Button? button)
        {
            if (activeMenuButton != null)
                activeMenuButton.BackColor = MenuNormalColor;

            activeMenuButton = button;

            if (activeMenuButton != null)
                activeMenuButton.BackColor = MenuActiveColor;
        }

        private void InitializePickupSelection()
        {
            try
            {
                List<Models.TimeSlot> slots =
                    adminService.GetAllTimeSlots();

                comboBoxPSTimeSlot.DataSource = null;

                comboBoxPSTimeSlot.DisplayMember = "DisplayTime";
                comboBoxPSTimeSlot.ValueMember =
                    nameof(Models.TimeSlot.Id);

                comboBoxPSTimeSlot.DataSource =
                    slots.Select(slot => new
                    {
                        Id = slot.Id,
                        DisplayTime =
                            $"{slot.StartTime:hh\\:mm} - {slot.EndTime:hh\\:mm}"
                    }).ToList();

                if (slots.Count > 0)
                    comboBoxPSTimeSlot.SelectedIndex = 0;

                LoadRoutesForSelectedTimeSlot();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load time slots.\n\n" + ex.Message,
                    "Pickup Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void comboBoxPSTimeSlot_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            LoadRoutesForSelectedTimeSlot();
        }

        private void LoadRoutesForSelectedTimeSlot()
        {
            if (comboBoxPSTimeSlot.SelectedValue == null)
                return;

            if (!int.TryParse(
                comboBoxPSTimeSlot.SelectedValue.ToString(),
                out int timeSlotId))
            {
                return;
            }

            try
            {
                DataTable routes =
                    studentService.GetAvailableRoutesForTimeSlotToday(
                        timeSlotId);

                comboBoxPSRoute.DataSource = null;

                comboBoxPSRoute.DisplayMember = "RouteName";
                comboBoxPSRoute.ValueMember = "RouteId";

                comboBoxPSRoute.DataSource = routes;

                grpLocations.Controls.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load routes.\n\n" + ex.Message,
                    "Pickup Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void comboBoxPSRoute_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            grpLocations.Controls.Clear();

            if (comboBoxPSRoute.SelectedValue == null)
                return;

            if (!int.TryParse(
                comboBoxPSRoute.SelectedValue.ToString(),
                out int routeId))
            {
                return;
            }

            try
            {
                List<Models.RouteLocation> locations =
                    adminService.GetLocationsByRoute(routeId);

                int top = 35;

                foreach (Models.RouteLocation location in locations)
                {
                    RadioButton radioButton = new RadioButton
                    {
                        AutoSize = true,
                        Text = $"{location.LocationName} - Fare: {location.Fare:0.00}",
                        Font = new System.Drawing.Font(
                            "Segoe UI",
                            10),
                        Location = new System.Drawing.Point(20, top),
                        Tag = location.Id
                    };

                    grpLocations.Controls.Add(radioButton);

                    top += 30;
                }

                RadioButton? first =
                    grpLocations.Controls
                    .OfType<RadioButton>()
                    .FirstOrDefault();

                if (first != null)
                    first.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load pickup locations.\n\n" +
                    ex.Message,
                    "Pickup Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonPSSavePickup_Click(
            object? sender,
            EventArgs e)
        {
            if (comboBoxPSTimeSlot.SelectedValue == null)
            {
                MessageBox.Show("Please select a time slot.");
                return;
            }

            if (!int.TryParse(
                comboBoxPSTimeSlot.SelectedValue.ToString(),
                out int timeSlotId))
            {
                MessageBox.Show("Invalid time slot.");
                return;
            }

            RadioButton? selected =
                grpLocations.Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            if (selected == null)
            {
                MessageBox.Show("Please select a pickup location.");
                return;
            }

            if (selected.Tag == null)
            {
                MessageBox.Show("Invalid pickup location.");
                return;
            }

            int locationId = Convert.ToInt32(selected.Tag);

            try
            {
                studentService.SavePickupSelection(
                    locationId,
                    timeSlotId);

                MessageBox.Show(
                    "Pickup saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Pickup Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonFPPay_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                decimal totalDue =
                    studentService.GetMyTotalDueAmount();

                if (totalDue <= 0)
                {
                    MessageBox.Show(
                        "No due fees to pay.",
                        "Fee Payment");
                    return;
                }

                if (!decimal.TryParse(
                    textBoxFPAmount.Text.Trim(),
                    out decimal amount))
                {
                    MessageBox.Show(
                        "Please enter a valid amount.",
                        "Fee Payment");
                    return;
                }

                if (amount != totalDue)
                {
                    MessageBox.Show(
                        $"Payment must be exactly {totalDue:0.00}.",
                        "Fee Payment");
                    return;
                }

                bool success =
                    studentService.PayFees(amount);

                if (success)
                {
                    textBoxFPAmount.Clear();

                    LoadFees();

                    MessageBox.Show(
                        "Payment successful.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Fee Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadFees()
        {
            try
            {
                dgvFees.DataSource = null;

                dgvFees.DataSource =
                    studentService.GetMyDueFeesTable();

                if (dgvFees.Columns.Contains("Date"))
                {
                    dgvFees.Columns["Date"]
                        .DefaultCellStyle
                        .Format = "yyyy-MM-dd";
                }

                decimal totalDue =
                    studentService.GetMyTotalDueAmount();

                labelFPTotalDue.Text =
                    $"Total Due: {totalDue:0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load fees.\n\n" + ex.Message,
                    "Fee Payment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void InitializePanelProfileUpdate()
        {
            try
            {
                Models.StudentProfile profile =
                    studentService.GetMyProfile();

                if (profile == null)
                {
                    MessageBox.Show(
                        "Student profile was not found.",
                        "Profile");
                    return;
                }

                textBoxPUStudentID.Text =
                    profile.StudentId ?? "";

                textBoxPUDepartment.Text =
                    profile.Department ?? "";

                textBoxPUEmail.Text =
                    profile.Email ?? "";

                if (buttonPUChangePassword == null)
                {
                    buttonPUChangePassword = new Button
                    {
                        Text = "Change Password",
                        Font = new System.Drawing.Font(
                            "Segoe UI",
                            10,
                            System.Drawing.FontStyle.Bold),
                        BackColor = System.Drawing.Color.SteelBlue,
                        ForeColor = System.Drawing.Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Width = 160,
                        Height = 40,
                        Location = new System.Drawing.Point(190, 320)
                    };

                    buttonPUChangePassword.FlatAppearance.BorderSize = 0;
                    buttonPUChangePassword.Click += buttonPUChangePassword_Click;

                    panelProfileUpdate.Controls.Add(
                        buttonPUChangePassword);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load profile.\n\n" + ex.Message,
                    "Profile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonPUProfileUpdate_Click(
            object? sender,
            EventArgs e)
        {
            string studentId =
                textBoxPUStudentID.Text.Trim();

            string department =
                textBoxPUDepartment.Text.Trim();

            string email =
                textBoxPUEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(department) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Please fill Student ID, Department and Email.",
                    "Profile");
                return;
            }

            try
            {
                studentService.UpdateProfile(
                    studentId,
                    department,
                    email);

                MessageBox.Show(
                    "Profile updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                InitializePanelProfileUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Profile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonPUChangePassword_Click(
            object? sender,
            EventArgs e)
        {
            ChangePasswordForm form =
                new ChangePasswordForm();

            form.ShowDialog();
        }

        private void buttonPickupSelection_Click(
            object? sender,
            EventArgs e)
        {
            SetActiveMenuButton(buttonPickupSelection);

            ShowPanel(panelPickupSelection);

            InitializePickupSelection();
        }

        private void buttonFeePayment_Click(
            object? sender,
            EventArgs e)
        {
            SetActiveMenuButton(buttonFeePayment);

            ShowPanel(panelFeePayment);

            LoadFees();
        }

        private void buttonProfileUpdate_Click(
            object? sender,
            EventArgs e)
        {
            SetActiveMenuButton(buttonProfileUpdate);

            ShowPanel(panelProfileUpdate);

            InitializePanelProfileUpdate();
        }

        private void buttonLogout_Click(
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