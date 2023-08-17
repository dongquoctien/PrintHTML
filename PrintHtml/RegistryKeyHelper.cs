using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintHtml
{
    public static class RegistryKeyHelper
    {
        public static void IESetupHeaderFooter()
        {
            try
            {
                string strKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(strKey, true))
                {
                    if (key != null) { key.SetValue("footer", ""); }
                }

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(strKey, true))
                {
                    if (key != null) { key.SetValue("header", ""); }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void IEMargin(Margins margins =  null)
        {
            if (margins == null) { 
                margins = new Margins(0,0,0,0);
            }

            try
            {
                string pageSetupKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
                bool isWritable = true;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(pageSetupKey, isWritable))
                {
                    if (key != null) {
                        key.SetValue("margin_bottom", margins.Bottom);
                        key.SetValue("margin_top", margins.Top);
                        key.SetValue("margin_left", margins.Left);
                        key.SetValue("margin_right", margins.Right);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void IEVersion()
        {
         
            try
            {
                string pageSetupKey = "SOFTWARE\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";
                bool isWritable = true;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(pageSetupKey, isWritable))
                {
                    if (key != null)
                    {
                        key.SetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +".exe", 99999, RegistryValueKind.DWord);
                    }
                }
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", isWritable))
                {
                    if (key != null)
                    {
                        key.SetValue(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ".exe", 99999, RegistryValueKind.DWord);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
