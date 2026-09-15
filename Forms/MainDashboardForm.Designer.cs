using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AIUBBusManagementSystem.Forms
{
    partial class MainDashboardForm
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            panelDashboardHost = new Panel();
            SuspendLayout();
            // 
            // panelDashboardHost
            // 
            panelDashboardHost.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDashboardHost.BorderStyle = BorderStyle.FixedSingle;
            panelDashboardHost.Location = new Point(0, 0);
            panelDashboardHost.Name = "panelDashboardHost";
            panelDashboardHost.Size = new Size(900, 600);
            panelDashboardHost.TabIndex = 0;
            panelDashboardHost.Paint += panelDashboardHost_Paint;
            // 
            // MainDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(panelDashboardHost);
            Name = "MainDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AIUB Bus Management System";
            ResumeLayout(false);
        }

        #endregion

        private Panel panelDashboardHost;
    }
}