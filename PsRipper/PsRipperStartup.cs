using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;
using System.IO;

namespace PsRipper
{
    public class PsRipperExtension : Fiddler.IFiddlerExtension
    {
        private UserControlPsRipper _userControl;

        void IFiddlerExtension.OnLoad()
        {
            var tabPage = new TabPage("PS Ripper");
            tabPage.ImageIndex = (int)Fiddler.SessionIcons.Video;
            _userControl = new UserControlPsRipper(this);
            tabPage.Controls.Add(_userControl);
            tabPage.Controls[0].Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            Fiddler.FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
        }

        void IFiddlerExtension.OnBeforeUnload()
        {
        }
    }
}
