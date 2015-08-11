using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PsRipper
{
    public class HtmlFileMaker
    {
        public static void CreateHtmlFile(string saveLocation, PsCourse course)
        {
            var head = GetHtmlHead(course);
            var body = GetHtmlBody(course);
            var path = Path.Combine(saveLocation, "index.html");
            File.WriteAllText(path, head + body, Encoding.UTF8);
        }


        private static string GetHtmlHead(PsCourse course)
        {
            return string.Format(@"<!doctype html>
                <html>
                <head>
                    <meta charset=""utf-8"">
                    <link rel=""stylesheet"" href=""../style.css"">
                    <title>{0}</title>
                </head>", course.Title);
        }

        private static string GetHtmlBody(PsCourse course)
        {
            var body = @"
                <body>
                    
                </body>
                </html>
                ";
        }
    }
}
