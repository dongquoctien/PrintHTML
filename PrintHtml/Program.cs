using PrintHtml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PrintHtmlApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length < 2)
            {
                string usage = "Usage: PrintHtmlApp.exe [-test] [-p printer] [-l left] [-t top] [-r right] [-b bottom] [-a paper] [-o orientation] <url> [url2]\n\n";
                usage += "-test                   - Don't print, just show what would have printed.\n";
                usage += "-p printer              - Printer to print to. Use 'Default' for default printer.\n";
                usage += "-l left                 - Optional left margin for page.\n";
                usage += "-t top                  - Optional top margin for page.\n";
                usage += "-r right                - Optional right margin for page.\n";
                usage += "-b bottom               - Optional bottom margin for page.\n";
                usage += "-a [A4|A5|Letter]       - Optional paper type.\n";
                usage += "-o [Portrait|Landscape] - Optional orientation type.\n";
                usage += "url                     - Defines the list of URLs to print, one after the other.\n";

                Console.WriteLine(usage, "PrintHtml Usage");
                return;
            }

            PrintHtmlForm printHtmlForm = new PrintHtmlForm(args); // Pass any necessary arguments
            Application.Run(printHtmlForm);
        }
    }

    public partial class PrintHtmlForm : Form
    {
        private string[] urls;
        private bool testMode = false;
        private string printer = "Default";
        private int leftMargin = 0;
        private int topMargin = 0;
        private int rightMargin = 0;
        private int bottomMargin = 0;
        private string paper = "letter";
        private string orientation = "portrait";


        public PrintHtmlForm(string[] args)
        {
            this.Visible = false;
            this.Opacity = 0;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;

            ParseCommandLine(args);

            // Set up SSL certificates
            PrintHelper.Init(new System.Drawing.Printing.Margins(leftMargin, rightMargin, topMargin, bottomMargin));

            PrintHelper.printHtml(printer ,urls[0]);
            Console.WriteLine("Print success");

           

            // Other initialization code...
        }



        private void ParseCommandLine(string[] args)
        {
            List<string> urlList = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                switch (arg)
                {
                    case "-test":
                        testMode = true;
                        break;
                    case "-p":
                        printer = args[++i];
                        break;
                    case "-l":
                        leftMargin = Convert.ToInt32(args[++i]);
                        break;
                    case "-t":
                        topMargin = Convert.ToInt32(args[++i]);
                        break;
                    case "-r":
                        rightMargin = Convert.ToInt32(args[++i]);
                        break;
                    case "-b":
                        bottomMargin = Convert.ToInt32(args[++i]);
                        break;
                    case "-a":
                        paper = args[++i];
                        break;
                    case "-o":
                        orientation = args[++i];
                        break;
                    default:
                        urlList.Add(arg);
                        break;
                }
            }

            urls = urlList.ToArray();
        }


    }
}
