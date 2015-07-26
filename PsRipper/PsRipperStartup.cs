using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

namespace PsRipper
{
    public class PsRipperExtension : Fiddler.IFiddlerExtension, Fiddler.IAutoTamper
    {
        private UserControlPsRipper _userControl;

        public bool IsEnabled { get; set; }

        void IFiddlerExtension.OnLoad()
        {
            IsEnabled = false;
            var tabPage = new TabPage("PS Ripper");
            tabPage.ImageIndex = (int)Fiddler.SessionIcons.Video;
            _userControl = new UserControlPsRipper(this);
            tabPage.Controls.Add(_userControl);
            tabPage.Controls[0].Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            Fiddler.FiddlerApplication.UI.tabsViews.TabPages.Add(tabPage);
        }

        void IAutoTamper.AutoTamperResponseAfter(Session oSession)
        {
            if (!IsEnabled) return;

            _userControl.DisplayMessage(oSession.fullUrl);
        }

        void IAutoTamper.AutoTamperRequestAfter(Session oSession) { }

        void IAutoTamper.AutoTamperRequestBefore(Session oSession) { }

        void IAutoTamper.AutoTamperResponseBefore(Session oSession) { }

        void IAutoTamper.OnBeforeReturningError(Session oSession) { }

        void IFiddlerExtension.OnBeforeUnload() { }
    }
}
