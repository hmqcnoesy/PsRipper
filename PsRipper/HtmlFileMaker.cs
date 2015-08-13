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
                <html lang=""en"">
                <head>
                <meta charset=""utf-8"">
                <title>{0}</title>
                <style>{1}</style>
                </head>", course.Title, GetCss());
        }


        private static string GetCss()
        {
            return @"
                html
                {
                    background-color: gainsboro;
                    overflow: -moz-scrollbars-vertical; 
                    overflow-y: scroll;
                }

                body
                {
                    box-shadow: 0.1em 0.1em 0.5em #000;
                    font-family: 'Segoe UI', Arial, Helvetica, sans-serif;
                    font-size: 1.5em;
                    padding: 0.5em;
                    margin: 0.5em;
                    background-color: #3d3d3d;
                }

                header
                {
                    position: relative;
                    left: 0px;
                    top: 0px;
                }

                h1
                {
                    margin: 0px;
                    font-size: 2em;
                    text-shadow: 0.05em 0.05em 0.1em #333;
                    color: white;
                    width: auto;
                    background-image: url('mongoose.png');
                    background-repeat: no-repeat;
                    padding-left: 150px;
                }

                input
                {
                    float: right;
                    padding: 0.2em;
                    margin: 0.4em;
                    font-size: 0.8em;
                    width: 10em;
                    display: block;
                    position: absolute;
                    right: 0px;
                    bottom: 0px;
                }

                div#errors
                {
                    color: red;
                }

                a
                {
                    display: block;
                    color: white;
                    border: 1px solid gainsboro;
                    padding: 0.4em;
                    margin: 0.4em;
                    background-color: #080808;
                    text-decoration: none;
                }

                a:hover, a:active, a:focus
                {
                    border: 1px solid white;
                    background-color: #3d3d3d;
                    text-decoration: underline;
                }
                .nodisplay { display: none; }
            ";
        }


        private static string GetHtmlBody(PsCourse course)
        {
            var body = @"
                <body>
                    {0}
                    {1}
                </body>
                ";

            var sb = new StringBuilder(string.Format(@"
                <div id=""toggleon"">&gt;&gt;</div>
                <div id=""settings"" class=""nodisplay"">
	                <span class=""speedsetting"" data-speed=""1.0"">1.0</span>
	                <span class=""speedsetting"" data-speed=""1.2"">1.2</span>
	                <span class=""speedsetting"" data-speed=""1.5"">1.5</span>
	                <span class=""speedsetting"" data-speed=""2.0"">2.0</span>
                </div>
                <div id=""toc"">
                <h1 id=""h1"">{0}</h1>", course.Title));

            
            var clipCount = 0;

            foreach(var module in course.ModuleList) 
            {
	            sb.AppendLine(string.Format("<h2>{0}</h2>", module.Title));
	            sb.AppendLine("<ul>");
	
	            foreach(var clip in module.Clips) 
	            {
		            sb.AppendLine(string.Format("<li data-href=\"{0}.mp4\">{1}</li>", clipCount++, clip.Title));
	            }
	            sb.AppendLine("</ul>");
            }

            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"vid\"><video id=\"video\" width=\"1280\" height=\"960\" controls></video></div>");
            sb.AppendLine("</body>");

            return string.Format(body, sb.ToString(), GetJavaScript());
        }


        private static string GetJavaScript()
        {
            return @"
                var liElements = document.getElementsByTagName('li');
                var courseTitle = document.getElementById('h1').innerHTML;
                var videoElement = document.getElementById('video');

                for (var i = 0; i < liElements.length; i++) {
	                var clipTitle = liElements[i].innerHTML;
	                var videoId = courseTitle + clipTitle;
	                if (localStorage.getItem(videoId)) {
		                liElements[i].classList.add('selected');
	                } else {
		                liElements[i].classList.remove('selected');
	                }
	
	                liElements[i].addEventListener('click', function() {
		                videoElement.src = liElements[i].dataHref;
		                videoElement.load();
		                videoElement.play();
		
		                if (localStorage.getItem(videoId)) {
			                localStorage.removeItem(videoId);
			                liElements[i].classList.remove('selected');
		                } else {
			                localStorage.setItem(videoId, videoId);
			                liElements[i].classList.add('selected');
		                }
	                });
                }

                var settingsElement = document.getElementById('settings');
                var toggleOn = document.getElementById('toggleon');
                toggleOn.addEventListener('click', function() {
	                settingsElement.classList.remove('nodisplay');
                });

                var speedElements = document.querySelectorAll('.speedsetting');
                foreach(var i = 0; i < speedElements.length; i++) {
	                speedElements[i].addEventListener('click', function() {
		                settingsElement.classList.add('nodisplay');
		                videoElement.playbackRate = Number(settingsElement[i].innerHTML);
		                videoElement.defaultPlaybackRate = Number(settingsElement[i].innerHTML);
	                });
                }
";
        }
    }
}