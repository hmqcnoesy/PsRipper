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
                <style>
                    {1}
                </style>
                </head>", course.Title, GetCss());
        }


        private static string GetCss()
        {
            return @"
                    html
					{
						margin: 0;
						padding: 0;
					}

					body
					{
						margin: 0;
						padding: 0;
						font-family: Segoe UI, Helvetica, sans-serif;
					}

					div#toggleon 
					{
						cursor: default;
						background-color: gainsboro;
						color: black;
						padding: 4px;
						font-size: 2em;
						border: 2px solid white;
						z-index: 2;
						position: fixed;
						top: 0px;
						left: 0px;
						opacity: 0.5;
					}

					div#settings
					{
						background-color: gainsboro;
						border: 2px solid white;
						z-index: 3;
						position: fixed;
						top: 0px;
						left: 0px;
						cursor: default;
						padding: 4px;
					}

					span.speedsetting 
					{
						background-color: black;
						color: white;
						padding: 4px;
						margin: 4px;
						font-size: 2em;
						border: 2px solid white;
						cursor: default;
					}

					div#toc
					{
						background-color: black;
						position: absolute;
						top: 0px;
						left: 0px;
						width: 16%;
						height: 100%;
						margin: 0;
						padding: 0;
						overflow-y: scroll;
						z-index: 1;
					}

					div#vid
					{
						position: absolute;
						left: 16%;
						top: 0px;
						width: 84%;
						height: 100%;
						margin: 0;
						padding: 0;
						background-color: black;
						z-index: 0;
					}

					h1
					{
						font-size: 14pt;
						font-weight: bold;
						background-color: black;
						color: white;
						margin: 0px;
						padding: 4px 2px 4px 2px;
					}

					h2
					{
						font-size: 13pt;
						font-weight: bold;
						background-color: #333;
						color: white;
						margin: 0px;
						margin-top: 48px;
						padding: 4px 2px 4px 2px;
					}

					ul
					{
						padding: 0;
						margin: 0;
					}

					li
					{
						color: white;
						border: 1px solid #333;
						padding: 0.8em;
						margin: 0.4em;
						background-color: #181818;
						text-decoration: none;
					}

					.selected
					{
						border-left: 0.8em  solid #333;
						padding-left: 1px !important;
						/*background-color: #444444;*/
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
		            sb.AppendLine(string.Format("<li data-href=\"{0}.mp4\">{1}</li>", clipCount++.ToString("000"), clip.Title));
	            }
	            sb.AppendLine("</ul>");
            }

            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"vid\"><video id=\"video\" width=\"100%\" height=\"100%\" controls></video></div>");

            return string.Format(body, sb.ToString(), GetJavaScript());
        }


        private static string GetJavaScript()
        {
            return @"
			<script>
                var liElements = document.getElementsByTagName('li');
                var courseTitle = document.getElementById('h1').innerHTML;
                var videoElement = document.getElementById('video');

                for (var i = 0; i < liElements.length; i++) {
	                var clipNumber = liElements[i].getAttribute('data-href');
	                var videoId = courseTitle + clipNumber;
	                if (localStorage[videoId]) {
		                liElements[i].classList.add('selected');
	                } else {
		                liElements[i].classList.remove('selected');
	                }
	
	                liElements[i].addEventListener('click', function(event) {
						var clickedElement = event.target;
						var href = clickedElement.getAttribute('data-href');
						var videoId = courseTitle + href;
						
		                videoElement.src = href;
		                videoElement.load();
		                videoElement.play();
		
		                if (localStorage[videoId]) {
			                localStorage.removeItem(videoId);
			                clickedElement.classList.remove('selected');
		                } else {
			                localStorage.setItem(videoId, videoId);
			                clickedElement.classList.add('selected');
		                }
	                });
                }

                var settingsElement = document.getElementById('settings');
                var toggleOn = document.getElementById('toggleon');
                toggleOn.addEventListener('click', function() {
	                settingsElement.classList.remove('nodisplay');
                });

                var speedElements = document.querySelectorAll('.speedsetting');
                for(var i = 0; i < speedElements.length; i++) {
	                speedElements[i].addEventListener('click', function(event) {
		                var speedButton = event.target;
		                videoElement.playbackRate = Number(speedButton.innerHTML);
		                videoElement.defaultPlaybackRate = Number(speedButton.innerHTML);
						settingsElement.classList.add('nodisplay');
	                });
                }
			</script>";
        }
    }
}