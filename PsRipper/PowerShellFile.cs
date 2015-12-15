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
                    $env:PATH = ""c:\program files\handbrake;"" + $env:PATH
                }} elseif (Test-Path ""c:\program files (x86)\handbrake\HandbrakeCLI.exe"") {{
                    $env:PATH = ""c:\program files (x86)\handbrake;"" + $env:PATH
                }} else {{
                    Write-Host ""Couldn't find Handbrake.  Exiting.""
                }}
                
                $create = Read-Host -prompt ""Create additional single video file ? (ffmpeg must be in path)""

                cd ""{0}""
                foreach ($inputFile in get-childitem -recurse -Filter *.wmv)
                {{ 
                    $outputFileName = [System.IO.Path]::GetFileNameWithoutExtension($inputFile.FullName) + "".mp4"";
                    $outputFileName = [System.IO.Path]::Combine($inputFile.DirectoryName, $outputFileName);
     
                    $processName = ""HandbrakeCLI.exe""
                    $processArgs = ""-i `""$($inputFile.FullName)`"" -o `""$outputFileName`"" --ab 64 -e x264 -q 30""
                    $outputFileName
                    start-process $processName $processArgs -WindowStyle Hidden -wait
                }}

                if ($create.Length -gt 0 -and $create.Substring(0, 1).ToLower() -eq 'y') {{
                    $mp4files = get-childitem -Filter *.mp4 | sort | % {{ (""file '"" + $_.FullName + ""'"") }}
                    [System.IO.File]::WriteAllLines(""mp4list.txt"", $mp4files, (New-Object System.Text.UTF8Encoding($false)))
                    $processName = ""ffmpeg""
                    $processArgs = ""-f concat -i mp4list.txt -codec copy """"{0}\{1}.mp4""""""
                    start-process $processName $processArgs -WindowStyle Hidden -wait
                }}", saveLocation, new DirectoryInfo(saveLocation).Name);

            var path = Path.Combine(saveLocation, "convert.ps1");
            File.WriteAllText(path, script);
        }
    }
}