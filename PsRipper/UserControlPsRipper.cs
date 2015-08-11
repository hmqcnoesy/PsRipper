using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace PsRipper
{
    public partial class UserControlPsRipper : UserControl
    {
        private PsRipperExtension _extension;

        public PsInfo PsInfo { get; set; }


        public UserControlPsRipper(PsRipperExtension extension)
        {
            InitializeComponent();
            _extension = extension;
        }


        private void OnCourseSelectionChanged(object sender, EventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var selectedCourse = (PsCourse)ddlCourse.SelectedItem;
            txtSaveLocation.Text = Path.Combine(desktopPath, "PsRipper", MakeSafeFileName(selectedCourse.Title));
        }


        private void OnCourseEnter(object sender, EventArgs e)
        {
            if (this.PsInfo != null) return;
            var cursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            var json = (new WebClient()).DownloadString("http://www.pluralsight.com/training/metadata/live/courses");
            this.PsInfo = JsonConvert.DeserializeObject<PsInfo>(json);
            foreach (var course in this.PsInfo.Courses.OrderBy(c => c.Title)) 
            {
                ddlCourse.Items.Add(course);
            }
            Cursor.Current = cursor;
        }


        private string MakeSafeFileName(string input)
        {
            foreach (var nastyCharacter in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(nastyCharacter.ToString(), string.Empty);
            }

            return input;
        }

        private void OnClickSaveButton(object sender, EventArgs e)
        {
            var mimeTypes = txtVideoMimeTypes.Lines.ToList();

            var saveLocation = txtSaveLocation.Text;
            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            var selectedCourse = (PsCourse)ddlCourse.SelectedItem;
            var courseModuleIds = selectedCourse.Modules.Split(",".ToCharArray()).Select(m => int.Parse(m));
            foreach(var moduleId in courseModuleIds)
            {
                selectedCourse.ModuleList.Add(PsInfo.Modules.ElementAt(moduleId));
            }

            _extension.RipSessions(selectedCourse, saveLocation, mimeTypes);
        }
    }
}
