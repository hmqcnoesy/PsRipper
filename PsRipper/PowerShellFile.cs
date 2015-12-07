using System;
using System.IO;
using System.Windows.Forms;

namespace PsRipper
{
    internal class PowerShellFile
    {
        internal static void AddConversionScript(string saveLocation)
        {
            var script = string.Format(@"
                if (Test-Path ""c:\program files\handbrake\HandbrakeCLI.exe"") {{
                    $env:PATH += ""c:\program files\handbrake""
                }} elseif (Test-Path ""c:\program files (x86)\handbrake\HandbrakeCLI.exe"") {{
                    $env:PATH += ""c:\program files (x86)\handbrake""
                }} else {{
                    Write-Host ""Couldn't find Handbrake.  Exiting.""
                }}

                cd ""{0}""
                foreach ($inputFile in get-childitem -recurse -Filter *.wmv)
                {{ 
                    $outputFileName = [System.IO.Path]::GetFileNameWithoutExtension($inputFile.FullName) + "".mp4"";
                    $outputFileName = [System.IO.Path]::Combine($inputFile.DirectoryName, $outputFileName);
     
                    $processName = ""HandbrakeCLI.exe""
                    $processArgs = ""-i `""$($inputFile.FullName)`"" -o `""$outputFileName`"" --ab 64 -e x264 -q 30""
                    $outputFileName
                    start-process $processName $processArgs -WindowStyle Hidden -wait
                }}", saveLocation);

            var path = Path.Combine(saveLocation, "convert.ps1");
            File.WriteAllText(path, script);
        }
    }
}