using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PsRipper
{
    public partial class UserControlPsRipper : UserControl
    {
        private PsRipperExtension _extension;

        public List<string> VideoMimeTypes
        {
            get
            {
                return txtVideoMimeTypes.Lines.ToList();
            }
        }


        public string SaveLocation
        {
            get
            {
                return txtSaveLocation.Text;
            }
        }

        public UserControlPsRipper(PsRipperExtension extension)
        {
            InitializeComponent();
            _extension = extension;
        }

        private void OnClickStartFinish(object sender, EventArgs e)
        {
            if (_extension.IsEnabled)
            {
                _extension.IsEnabled = false;
                this.btnStartFinish.Text = "Start";
            }
            else
            {
                _extension.IsEnabled = true;
                this.btnStartFinish.Text = "Finish";
            }
        }


        public void DisplayMessage(string message)
        {
            this.lblMessage.Text = message;
        }

        private void OnCourseSelectionChanged(object sender, EventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtSaveLocation.Text = Path.Combine(desktopPath, "PsRipper", ddlCourse.Text);
        }

        private void OnCourseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("entering");
        }
    }
}
