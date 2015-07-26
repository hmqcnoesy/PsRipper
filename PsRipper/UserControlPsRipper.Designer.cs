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
            this.btnStartFinish = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtVideoMimeTypes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaveLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartFinish
            // 
            this.btnStartFinish.Location = new System.Drawing.Point(38, 191);
            this.btnStartFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartFinish.Name = "btnStartFinish";
            this.btnStartFinish.Size = new System.Drawing.Size(100, 28);
            this.btnStartFinish.TabIndex = 0;
            this.btnStartFinish.Text = "Start";
            this.btnStartFinish.UseVisualStyleBackColor = true;
            this.btnStartFinish.Click += new System.EventHandler(this.OnClickStartFinish);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(38, 228);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(30, 17);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Idle";
            // 
            // txtVideoMimeTypes
            // 
            this.txtVideoMimeTypes.Location = new System.Drawing.Point(3, 20);
            this.txtVideoMimeTypes.Multiline = true;
            this.txtVideoMimeTypes.Name = "txtVideoMimeTypes";
            this.txtVideoMimeTypes.Size = new System.Drawing.Size(213, 114);
            this.txtVideoMimeTypes.TabIndex = 2;
            this.txtVideoMimeTypes.Text = "application/octet-stream\r\nbinary/octet-stream\r\nvideo/x-ms-wmv";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rip MIME Types:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Location:";
            // 
            // ddlCourse
            // 
            this.ddlCourse.FormattingEnabled = true;
            this.ddlCourse.Location = new System.Drawing.Point(239, 21);
            this.ddlCourse.Name = "ddlCourse";
            this.ddlCourse.Size = new System.Drawing.Size(244, 24);
            this.ddlCourse.TabIndex = 4;
            this.ddlCourse.SelectedIndexChanged += new System.EventHandler(this.OnCourseSelectionChanged);
            this.ddlCourse.Enter += new System.EventHandler(this.OnCourseEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Course:";
            // 
            // txtSaveLocation
            // 
            this.txtSaveLocation.Location = new System.Drawing.Point(239, 111);
            this.txtSaveLocation.Name = "txtSaveLocation";
            this.txtSaveLocation.Size = new System.Drawing.Size(244, 22);
            this.txtSaveLocation.TabIndex = 6;
            // 
            // UserControlPsRipper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSaveLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlCourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVideoMimeTypes);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnStartFinish);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControlPsRipper";
            this.Size = new System.Drawing.Size(708, 635);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartFinish;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtVideoMimeTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaveLocation;
    }
}
