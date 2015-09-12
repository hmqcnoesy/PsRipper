using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PsRipper
{
    public class Ripper
    {
        public void Rip(RipOptions options)
        {
            if (!Directory.Exists(options.SaveLocation))
            {
                Directory.CreateDirectory(options.SaveLocation);
            }

            var count = 0;

            var matchingSessions = Fiddler.FiddlerApplication.UI.GetAllSessions()
                .Where(s => options.MimeTypes.Contains(s.oResponse.MIMEType))
                .ToList();

            foreach (var session in matchingSessions.OrderBy(s => s.id))
            {
                var path = Path.Combine(options.SaveLocation, count++.ToString().PadLeft(3, '0') + ".wmv");
                session.SaveResponseBody(path);
            }

            HtmlFileMaker.CreateHtmlFile(options.SaveLocation, options.SelectedCourse);
            PowerShellFile.AddConversionScript(options.SaveLocation);

            if (options.ClearSessions) Fiddler.FiddlerApplication.UI.actRemoveAllSessions();
        }
    }
}
