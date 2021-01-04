
using CommandLine;

namespace TestApp.Options
{
    [Verb("load-save", HelpText = "Load an SVG document and save it back to a file.")]
    public class LoadSaveOptions
    {
        [Option("svg", Required = true, HelpText = "The name of the SVG file to load.")]
        public string SvgPath { get; set; }

        [Option("echo", Required = false, HelpText = "Echo the SVG to the console.")]
        public bool Echo { get; set; }

        [Option("no-html", Required = false, HelpText = "Disable creation of the HTML wrapper.")]
        public bool NoHtml { get; set; }
    }
}
