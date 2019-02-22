using System;
using System.Windows.Forms;

namespace WordAddIn1
{
    partial class TaskPaneInterface
    {
        int Screen_Size = Convert.ToInt32((Globals.ThisAddIn.Application.UsableHeight) - 156);
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        internal System.ComponentModel.IContainer components = null;

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
        internal void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskPaneInterface));
            this.performChecksButton = new System.Windows.Forms.Button();
            this.disclaimer = new System.Windows.Forms.Label();
            this.disclaimerAccept = new System.Windows.Forms.CheckBox();
            this.errorOutputArea = new System.Windows.Forms.RichTextBox();
            this.buildVersion = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.settingsText = new System.Windows.Forms.Label();
            this.settingsTitle = new System.Windows.Forms.Label();
            this.settingsEntryField = new System.Windows.Forms.TextBox();
            this.settingsSubmitButton = new System.Windows.Forms.Button();
            this.settingsOutputText = new System.Windows.Forms.Label();
            this.settingsRestoreDefaults = new System.Windows.Forms.Button();
            this.settingsViewDisclaimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // performChecksButton
            // 
            this.performChecksButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.performChecksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.performChecksButton.Font = new System.Drawing.Font("Segoe UI Symbol", 12F);
            this.performChecksButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.performChecksButton.Location = new System.Drawing.Point(20, 20);
            this.performChecksButton.Margin = new System.Windows.Forms.Padding(0);
            this.performChecksButton.Name = "performChecksButton";
            this.performChecksButton.Size = new System.Drawing.Size(297, 48);
            this.performChecksButton.TabIndex = 0;
            this.performChecksButton.Text = "Perform Checks";
            this.performChecksButton.UseVisualStyleBackColor = false;
            this.performChecksButton.Click += new System.EventHandler(this.performChecksButton_Click);
            // 
            // disclaimer
            // 
            this.disclaimer.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disclaimer.Location = new System.Drawing.Point(20, 20);
            this.disclaimer.Margin = new System.Windows.Forms.Padding(0);
            this.disclaimer.Name = "disclaimer";
            this.disclaimer.Size = new System.Drawing.Size(350, 366);
            this.disclaimer.TabIndex = 2;
            this.disclaimer.Text = resources.GetString("disclaimer.Text");
            // 
            // disclaimerAccept
            // 
            this.disclaimerAccept.AutoSize = true;
            this.disclaimerAccept.Font = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.disclaimerAccept.Location = new System.Drawing.Point(20, 400);
            this.disclaimerAccept.Margin = new System.Windows.Forms.Padding(0);
            this.disclaimerAccept.Name = "disclaimerAccept";
            this.disclaimerAccept.Size = new System.Drawing.Size(134, 23);
            this.disclaimerAccept.TabIndex = 4;
            this.disclaimerAccept.Text = "Accept and agree";
            this.disclaimerAccept.UseVisualStyleBackColor = true;
            this.disclaimerAccept.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // errorOutputArea
            // 
            this.errorOutputArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.errorOutputArea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorOutputArea.Font = new System.Drawing.Font("Segoe UI Symbol", 11F);
            this.errorOutputArea.Location = new System.Drawing.Point(20, 86);
            this.errorOutputArea.Name = "errorOutputArea";
            this.errorOutputArea.ReadOnly = true;
            this.errorOutputArea.Size = new System.Drawing.Size(350, Screen_Size + 100);
            this.errorOutputArea.TabIndex = 5;
            this.errorOutputArea.Text = "";
            // 
            // buildVersion
            // 
            this.buildVersion.AutoSize = true;
            this.buildVersion.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildVersion.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buildVersion.Location = new System.Drawing.Point(17, 7);
            this.buildVersion.Name = "buildVersion";
            this.buildVersion.Size = new System.Drawing.Size(82, 13);
            this.buildVersion.TabIndex = 6;
            this.buildVersion.Text = "Version 1.0.1.1";
            // 
            // settingsButton
            // 
            this.settingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.Location = new System.Drawing.Point(320, 20);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(50, 48);
            this.settingsButton.TabIndex = 7;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // settingsText
            // 
            this.settingsText.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsText.Location = new System.Drawing.Point(20, 86);
            this.settingsText.Margin = new System.Windows.Forms.Padding(0);
            this.settingsText.Name = "settingsText";
            this.settingsText.Size = new System.Drawing.Size(350, 130);
            this.settingsText.TabIndex = 8;
            this.settingsText.Text = "Your report may not need to be checked for all of the possible errors this progra" +
    "m can detect. To set which errors this program detects, enter the six digit numb" +
    "er provided by your module leader.";
            // 
            // settingsTitle
            // 
            this.settingsTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsTitle.Location = new System.Drawing.Point(20, 20);
            this.settingsTitle.Margin = new System.Windows.Forms.Padding(0);
            this.settingsTitle.Name = "settingsTitle";
            this.settingsTitle.Size = new System.Drawing.Size(297, 48);
            this.settingsTitle.TabIndex = 9;
            this.settingsTitle.Text = "Settings";
            this.settingsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsEntryField
            // 
            this.settingsEntryField.AllowDrop = true;
            this.settingsEntryField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsEntryField.Location = new System.Drawing.Point(20, 191);
            this.settingsEntryField.MaxLength = 6;
            this.settingsEntryField.Name = "settingsEntryField";
            this.settingsEntryField.Size = new System.Drawing.Size(80, 25);
            this.settingsEntryField.TabIndex = 10;
            this.settingsEntryField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.settingsEntryField.Click += new System.EventHandler(this.settingsEntryField_Click);
            this.settingsEntryField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.settingsEntryField_KeyPress);
            // 
            // settingsSubmitButton
            // 
            this.settingsSubmitButton.BackColor = System.Drawing.Color.ForestGreen;
            this.settingsSubmitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsSubmitButton.FlatAppearance.BorderSize = 0;
            this.settingsSubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsSubmitButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsSubmitButton.ForeColor = System.Drawing.Color.White;
            this.settingsSubmitButton.Location = new System.Drawing.Point(106, 191);
            this.settingsSubmitButton.Name = "settingsSubmitButton";
            this.settingsSubmitButton.Size = new System.Drawing.Size(80, 25);
            this.settingsSubmitButton.TabIndex = 11;
            this.settingsSubmitButton.Text = "Submit";
            this.settingsSubmitButton.UseVisualStyleBackColor = false;
            this.settingsSubmitButton.Click += new System.EventHandler(this.settingsSubmitButton_Click);
            // 
            // settingsOutputText
            // 
            this.settingsOutputText.Font = new System.Drawing.Font("Segoe UI Symbol", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsOutputText.Location = new System.Drawing.Point(20, 243);
            this.settingsOutputText.Margin = new System.Windows.Forms.Padding(0);
            this.settingsOutputText.Name = "settingsOutputText";
            this.settingsOutputText.Size = new System.Drawing.Size(166, 28);
            this.settingsOutputText.TabIndex = 12;
            this.settingsOutputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsRestoreDefaults
            // 
            this.settingsRestoreDefaults.BackColor = System.Drawing.Color.ForestGreen;
            this.settingsRestoreDefaults.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsRestoreDefaults.FlatAppearance.BorderSize = 0;
            this.settingsRestoreDefaults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsRestoreDefaults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsRestoreDefaults.ForeColor = System.Drawing.Color.White;
            this.settingsRestoreDefaults.Location = new System.Drawing.Point(250, 191);
            this.settingsRestoreDefaults.Name = "settingsRestoreDefaults";
            this.settingsRestoreDefaults.Size = new System.Drawing.Size(120, 25);
            this.settingsRestoreDefaults.TabIndex = 13;
            this.settingsRestoreDefaults.Text = "Restore Defaults";
            this.settingsRestoreDefaults.UseVisualStyleBackColor = false;
            this.settingsRestoreDefaults.Click += new System.EventHandler(this.settingsRestoreDefaults_Click);
            // 
            // settingsViewDisclaimer
            // 
            this.settingsViewDisclaimer.BackColor = System.Drawing.Color.ForestGreen;
            this.settingsViewDisclaimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsViewDisclaimer.FlatAppearance.BorderSize = 0;
            this.settingsViewDisclaimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsViewDisclaimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsViewDisclaimer.ForeColor = System.Drawing.Color.White;
            this.settingsViewDisclaimer.Location = new System.Drawing.Point(250, 246);
            this.settingsViewDisclaimer.Name = "settingsViewDisclaimer";
            this.settingsViewDisclaimer.Size = new System.Drawing.Size(120, 25);
            this.settingsViewDisclaimer.TabIndex = 14;
            this.settingsViewDisclaimer.Text = "View Disclaimer";
            this.settingsViewDisclaimer.UseVisualStyleBackColor = false;
            this.settingsViewDisclaimer.Click += new System.EventHandler(this.settingsViewDisclaimer_Click);
            // 
            // TaskPaneInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.settingsViewDisclaimer);
            this.Controls.Add(this.settingsRestoreDefaults);
            this.Controls.Add(this.settingsOutputText);
            this.Controls.Add(this.settingsSubmitButton);
            this.Controls.Add(this.settingsEntryField);
            this.Controls.Add(this.settingsTitle);
            this.Controls.Add(this.settingsText);
            this.Controls.Add(this.buildVersion);
            this.Controls.Add(this.performChecksButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.errorOutputArea);
            this.Controls.Add(this.disclaimerAccept);
            this.Controls.Add(this.disclaimer);
            this.Name = "TaskPaneInterface";
            this.Size = new System.Drawing.Size(400, 801);
            this.Load += new System.EventHandler(this.TaskPaneInterface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button performChecksButton;
        internal System.Windows.Forms.Label disclaimer;
        internal System.Windows.Forms.CheckBox disclaimerAccept;
        internal System.Windows.Forms.RichTextBox errorOutputArea;
        internal System.Windows.Forms.Label buildVersion;
        internal System.Windows.Forms.Button settingsButton;
        internal Label settingsText;
        internal Label settingsTitle;
        internal TextBox settingsEntryField;
        internal Button settingsSubmitButton;
        internal Label settingsOutputText;
        internal Button settingsRestoreDefaults;
        internal Button settingsViewDisclaimer;
    }
}
