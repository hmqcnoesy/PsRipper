using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PsRipper
{
    public partial class UserControlPsRipper : UserControl
    {
        private PsRipperExtension _extension;

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
    }
}
