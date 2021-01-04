
using CommandLine;

namespace TestApp.Options
{
    [Verb("create", HelpText = "Load an SVG document and save it back to a file.")]
    public class CreateOptions
    {
        [Option("name", Required = true, HelpText = "The name of the example to create.")]
        public string Name { get; set; }
    }
}
