using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PsRipper
{
    public class RipOptions
    {
        public PsCourse SelectedCourse { get; set; }
        public string SaveLocation { get; set; }
        public List<string> MimeTypes { get; set; }
        public bool ClearSessions { get; set; }
    }
}
