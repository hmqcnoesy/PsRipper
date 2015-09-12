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
using System.Reflection;

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
            lblInfo.Text = "Modified: " + File.GetLastWriteTime(Assembly.GetAssembly(this.GetType()).Location).ToString("yy-MM-dd hh:mm:ss");
        }


        private void OnCourseSelectionChanged(object sender, EventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var selectedCourse = (PsCourse)ddlCourse.SelectedItem;
            txtSaveLocation.Text = Path.Combine(desktopPath, "PsRipper", MakeSafeFileName(selectedCourse.Title));
        }



        private string MakeSafeFileName(string input)
        {
            foreach (var nastyCharacter in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(nastyCharacter.ToString(), string.Empty);
            }

            return input;
        }


        private async void OnClickSaveButton(object sender, EventArgs e)
        {            
            var selectedCourse = (PsCourse)ddlCourse.SelectedItem;
            var courseModuleIds = selectedCourse.Modules.Split(",".ToCharArray()).Select(m => int.Parse(m));
            foreach(var moduleId in courseModuleIds)
            {
                selectedCourse.ModuleList.Add(PsInfo.Modules.ElementAt(moduleId));
            }

            var options = new RipOptions
            {
                SelectedCourse = selectedCourse,
                SaveLocation = txtSaveLocation.Text,
                MimeTypes = txtVideoMimeTypes.Lines.ToList(),
                ClearSessions = chkClearSessions.Checked
            };

            var ripper = new Ripper();
            await ripper.Rip(options);
        }


        private void OnClickReloadButton(object sender, EventArgs e)
        {
            btnReload.Enabled = false;
            btnReload.Text = "Working";
            var webClient = new WebClient();
            webClient.DownloadStringAsync(new Uri("http://www.pluralsight.com/training/metadata/live/courses"));
            webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
        }


        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var json = e.Result;
            this.PsInfo = JsonConvert.DeserializeObject<PsInfo>(json);
            foreach (var course in this.PsInfo.Courses.OrderBy(c => c.Title))
            {
                ddlCourse.Items.Add(course);
            }
            btnReload.Enabled = true;
            btnReload.Text = "Reload";
        }
    }
}
