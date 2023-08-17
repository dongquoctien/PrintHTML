using PrintHtml;
using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;

namespace PrintHTML.Example
{
    public static class PrintHtmlHelper
    {

        public static void PrintHtmlV2(string printerName, string html, Margins margins)
        {

            string executablePath = $"{AppDomain.CurrentDomain.BaseDirectory}PrintHtml.exe";
            PrintHtml(printerName, html, margins, executablePath);

        }

        private static void PrintHtml(string printerName, string html, Margins margins, string executablePath = "")
        {
            var htmlFilePath = $"{System.AppDomain.CurrentDomain.BaseDirectory}{Guid.NewGuid().ToString()}.html";
            SaveStringHTMLToFile(html, htmlFilePath);

            if (File.Exists(htmlFilePath))
            {
                // Replace "PrintHtml.exe" with the actual name of your command-line application
                string commandLineArgs = $@"-p ""{printerName}"" -l {margins.Left} -t {margins.Top} -r {margins.Right} -b {margins.Bottom} ""{htmlFilePath}""";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = executablePath,
                    Arguments = commandLineArgs,
                    Verb = "runas", // This will prompt for administrator privileges
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };

                try
                {
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void SaveStringHTMLToFile(string htmlContent, string htmlFilePath)
        {
            try
            {
                // Save the HTML content to the file
                File.WriteAllText(htmlFilePath, htmlContent);
                Console.WriteLine("HTML content saved to file: " + htmlFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}