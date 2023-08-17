# PrintHTML
<p>
    PrintHtml is a command line program for printing HTML pages and more importantly allows you to send output to a specific printer. We need the ability to print to different printers, and the WebBrowser control always sends output to whatever printer is configured as the default for Internet Explorer. Well applied on operating systems with Internet Explorer 10, can print on most CSS structures, and Google fonts.
</p>
<p>
    The program is pretty simple and the command line usage is like this:<br>
</p>
<pre><code class="language-plaintext">Usage: PrintHtml [-p printer] [-l left] [-t top] [-r right] [-b bottom] &lt;url&gt;
-p printer    - Printer to print to. Use 'Default' for default printer.
-a page       - Paper type [A4|A5|US letter]
-l left       - Optional left margin for page.
-t top        - Optional top margin for page.
-r right      - Optional right margin for page.
-b bottom     - Optional bottom margin for page.
url           - Defines the list of URLs to print, one after the other.</code></pre>

# How to use
```cs
var executablePath = $"{AppDomain.CurrentDomain.BaseDirectory}PrintHtml.exe";
var htmlFilePath = $"{System.AppDomain.CurrentDomain.BaseDirectory}{Guid.NewGuid().ToString()}.html";
string commandLineArgs = $@"-p ""{printerName}"" -l {margins.Left} -t {margins.Top} -r {margins.Right} -b {margins.Bottom} ""{htmlFilePath}""";
ProcessStartInfo startInfo = new ProcessStartInfo
{
    FileName = executablePath,
    Arguments = commandLineArgs,
    Verb = "runas", // This will prompt for administrator privileges
    UseShellExecute = true,
    WindowStyle = ProcessWindowStyle.Hidden,
};
```
