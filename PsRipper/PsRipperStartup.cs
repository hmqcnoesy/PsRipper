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
    public class PsRipperExtension : Fiddler.IFiddlerExtension, Fiddler.IAutoTamper
    {
        private UserControlPsRipper _userControl;
        private int _count = 0;

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
            if (!_userControl.VideoMimeTypes.Contains(oSession.oResponse.MIMEType)) return;
            var url = oSession.fullUrl.Contains("?") ? oSession.fullUrl.Remove(oSession.fullUrl.IndexOf('?')) : oSession.fullUrl;
            var filenameExtension = url.Substring(url.LastIndexOf('.'));
            if (!Directory.Exists(_userControl.SaveLocation)) Directory.CreateDirectory(_userControl.SaveLocation);
            var filename = Path.Combine(_userControl.SaveLocation, _count.ToString().PadLeft(3, '0') + ".wmv");
            oSession.SaveResponseBody(filename);
            _count++;

            _userControl.DisplayMessage("Saved " + filename);
        }

        void IAutoTamper.AutoTamperRequestAfter(Session oSession) { }

        void IAutoTamper.AutoTamperRequestBefore(Session oSession) { }

        void IAutoTamper.AutoTamperResponseBefore(Session oSession) { }

        void IAutoTamper.OnBeforeReturningError(Session oSession) { }

        void IFiddlerExtension.OnBeforeUnload() { }
    }
}
