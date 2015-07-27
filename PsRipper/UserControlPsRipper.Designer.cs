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
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtVideoMimeTypes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(14, 199);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(24, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Idle";
            // 
            // txtVideoMimeTypes
            // 
            this.txtVideoMimeTypes.Location = new System.Drawing.Point(368, 28);
            this.txtVideoMimeTypes.Margin = new System.Windows.Forms.Padding(2);
            this.txtVideoMimeTypes.Multiline = true;
            this.txtVideoMimeTypes.Name = "txtVideoMimeTypes";
            this.txtVideoMimeTypes.Size = new System.Drawing.Size(161, 93);
            this.txtVideoMimeTypes.TabIndex = 2;
            this.txtVideoMimeTypes.Text = "application/octet-stream\r\nbinary/octet-stream\r\nvideo/x-ms-wmv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rip MIME Types:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Location:";
            // 
            // ddlCourse
            // 
            this.ddlCourse.FormattingEnabled = true;
            this.ddlCourse.Location = new System.Drawing.Point(14, 28);
            this.ddlCourse.Margin = new System.Windows.Forms.Padding(2);
            this.ddlCourse.Name = "ddlCourse";
            this.ddlCourse.Size = new System.Drawing.Size(338, 21);
            this.ddlCourse.TabIndex = 4;
            this.ddlCourse.SelectedIndexChanged += new System.EventHandler(this.OnCourseSelectionChanged);
            this.ddlCourse.Enter += new System.EventHandler(this.OnCourseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Course:";
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Location = new System.Drawing.Point(14, 167);
            this.txtSaveLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.Size = new System.Drawing.Size(515, 20);
            this.txtSaveLocation.TabIndex = 6;
            // 
            // UserControlPsRipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSaveLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlCourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVideoMimeTypes);
            this.Controls.Add(this.lblMessage);
            this.Name = "UserControlPsRipper";
            this.Size = new System.Drawing.Size(531, 516);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtVideoMimeTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaveLocation;
    }
}
