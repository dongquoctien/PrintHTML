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
I can provide you with a rough outline of how you might approach this from the command line. <br>
Please note that you may need to modify or adapt this outline to match your specific requirements and the tools available on your system.
```bash
#!/bin/bash

# Define variables
executablePath="./PrintHtml.exe"
printerName="YourPrinterName"
marginsLeft=10
marginsTop=10
marginsRight=10
marginsBottom=10

# Generate a unique HTML file name
htmlFilePath="$(uuidgen).html"

# Create an HTML file with content (you might need to replace this step with your actual HTML content)
echo "<html><body><h1>Hello, World!</h1></body></html>" > "$htmlFilePath"

# Prepare command-line arguments
commandLineArgs="-p \"$printerName\" -l $marginsLeft -t $marginsTop -r $marginsRight -b $marginsBottom \"$htmlFilePath\""

# Run the external process (adjust this part based on your needs)
"$executablePath" $commandLineArgs

# Clean up: Delete the generated HTML file
rm "$htmlFilePath"

```
<p style="margin-left:0px;">
    Please note the following:
</p>
<ol>
    <li>
        The provided shell script assumes that you have an executable named "PrintHtml.exe" in the same directory as the script. Adjust the <strong>executablePath</strong> variable if necessary.
    </li>
    <li>
        You'll need to replace the placeholder HTML content with your actual HTML content.
    </li>
    <li>
        This script generates a unique HTML file using <strong>uuidgen</strong>. You might need to adjust this part based on your needs.
    </li>
    <li>
        The script uses double quotes around variables to handle spaces in paths or printer names.
    </li>
</ol>
<p style="margin-left:0px;">
    Please adapt and test this script according to your actual requirements and environment. Keep in mind that handling process execution and administrator privileges in a command-line script might not be as straightforward as in a compiled language like C#.
</p>
Or use the following command

```cmd
PrintHtml.exe -p "YourPrinterName" -l 0 -t 0 -r 0 -b 0 "PathFileHtml"
```
