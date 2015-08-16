namespace PsRipper
{
    partial class UserControlPsRipper
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
            this.txtVideoMimeTypes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.chkClearSessions = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtVideoMimeTypes
            // 
            this.txtVideoMimeTypes.Location = new System.Drawing.Point(14, 30);
            this.txtVideoMimeTypes.Margin = new System.Windows.Forms.Padding(2);
            this.txtVideoMimeTypes.Multiline = true;
            this.txtVideoMimeTypes.Name = "txtVideoMimeTypes";
            this.txtVideoMimeTypes.Size = new System.Drawing.Size(347, 93);
            this.txtVideoMimeTypes.TabIndex = 2;
            this.txtVideoMimeTypes.Text = "application/octet-stream\r\nbinary/octet-stream\r\nvideo/x-ms-wmv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rip MIME Types:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Location:";
            // 
            // ddlCourse
            // 
            this.ddlCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCourse.FormattingEnabled = true;
            this.ddlCourse.Location = new System.Drawing.Point(14, 160);
            this.ddlCourse.Margin = new System.Windows.Forms.Padding(2);
            this.ddlCourse.Name = "ddlCourse";
            this.ddlCourse.Size = new System.Drawing.Size(347, 21);
            this.ddlCourse.TabIndex = 4;
            this.ddlCourse.SelectedIndexChanged += new System.EventHandler(this.OnCourseSelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Course:";
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Location = new System.Drawing.Point(14, 214);
            this.txtSaveLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.Size = new System.Drawing.Size(347, 20);
            this.txtSaveLocation.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(365, 213);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 20);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnClickSaveButton);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(365, 160);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(66, 21);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.OnClickReloadButton);
            // 
            // chkClearSessions
            // 
            this.chkClearSessions.AutoSize = true;
            this.chkClearSessions.Checked = true;
            this.chkClearSessions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearSessions.Location = new System.Drawing.Point(14, 249);
            this.chkClearSessions.Name = "chkClearSessions";
            this.chkClearSessions.Size = new System.Drawing.Size(156, 17);
            this.chkClearSessions.TabIndex = 8;
            this.chkClearSessions.Text = "Clear all sessions after save";
            this.chkClearSessions.UseVisualStyleBackColor = true;
            // 
            // UserControlPsRipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkClearSessions);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSaveLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlCourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVideoMimeTypes);
            this.Name = "UserControlPsRipper";
            this.Size = new System.Drawing.Size(718, 516);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtVideoMimeTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaveLocation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.CheckBox chkClearSessions;
    }
}
