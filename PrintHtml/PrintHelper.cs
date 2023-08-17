using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintHtml
{
    public static class PrintHelper
    {
        

        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        public static void Init(Margins margins)
        {

            RegistryKeyHelper.IESetupHeaderFooter();

            RegistryKeyHelper.IEMargin(margins);

            RegistryKeyHelper.IEVersion();
        }

        public static void printHtml(string printer , string fileHtml)
        {
            myPrinters.SetDefaultPrinter(printer);

            // Create a WebBrowser instance. 
            WebBrowser webBrowserForPrinting = new WebBrowser();

            // Add an event handler that prints the document after it loads.
            webBrowserForPrinting.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(PrintDocument);

            // Set the Url property to load the document.

            webBrowserForPrinting.Url = new Uri(fileHtml);
        }

        private static void PrintDocument(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var webBrowser = (WebBrowser)sender;

            webBrowser.Print();
            
            webBrowser.Dispose();

        }

    }
}
