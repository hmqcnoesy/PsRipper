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
            return @"html { margin: 0; padding: 0; }
					body { margin: 0; padding: 0; font-family: Segoe UI, Helvetica, sans-serif; }
					div#settings { background-color: black; padding: 4px; line-height: 2em; } 
					input { display: none; } 
					input:checked + label { background-color: black; } 
					label { background-color: darkgray; color: white; padding: 0.01em 0.5em; margin: 0.02em; font-size: 1em; border: 2px solid white; cursor: pointer; }
					div#toc { background-color: black; position: absolute; top: 0px; left: 0px; width: 16%; height: 100%; margin: 0; padding: 0; overflow-y: scroll; z-index: 1; }
					div#vid { position: absolute; left: 16%; top: 0px; width: 84%; height: 100%; margin: 0; padding: 0; background-color: black; z-index: 0; }
					h1 { font-size: 14pt; font-weight: bold; background-color: black; color: white; margin: 0px; padding: 4px 2px 4px 2px;}
					h2 { font-size: 13pt; font-weight: bold; background-color: #333; color: white; margin: 0px; margin-top: 48px; padding: 4px 2px 4px 2px; }
					ul { padding: 0; margin: 0; } 
					li { color: white; border: 1px solid #333; padding: 0.8em; margin: 0.4em; background-color: #181818; text-decoration: none; cursor: pointer; }
					.selected { border-left: 0.8em  solid #333; padding-left: 1px !important; }";
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
                <div id=""toc"">
                    
                <div id=""settings"">
						<input type=""radio"" name=""speed"" value=""1.00"" id=""rb100"" checked /><label for=""rb100"">1.0</label>
						<input type=""radio"" name=""speed"" value=""1.25"" id=""rb125"" /><label for=""rb125"">1.25</label>
						<input type=""radio"" name=""speed"" value=""1.50"" id=""rb150"" /><label for=""rb150"">1.5</label>
						<input type=""radio"" name=""speed"" value=""2.00"" id=""rb200"" /><label for=""rb200"">2.0</label>
						<input type=""checkbox"" id=""chkAuto"" checked /><label for=""chkAuto"">Autoplay</label>
                </div>
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
				
				videoElement.onended = function() { 
					if (!document.getElementById('chkAuto').checked) return;
					var currentVideoNumber = parseInt(videoElement.getAttribute('src').substring(0, 3));
					var updatedVideoNumber = (1 + currentVideoNumber);
					updatedVideoNumber = '000'.substring(0, 3 - updatedVideoNumber.toString().length) + updatedVideoNumber + '.mp4';
					var liToClick = document.querySelector('li[data-href=""' + updatedVideoNumber + '""]');
					if (liToClick) liToClick.click();
				}

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

                var speedElements = document.querySelectorAll('input[type=radio]');
                for(var i = 0; i < speedElements.length; i++) {
	                speedElements[i].addEventListener('click', function(event) {
		                var speedButton = event.target;
		                videoElement.playbackRate = Number(speedButton.value);
		                videoElement.defaultPlaybackRate = Number(speedButton.value);
	                });
                }
			</script>";
        }
    }
}