
using System;
using System.IO;

using SwishSvg;
using TestApp.Helpers;
using TestApp.Options;

namespace TestApp.Commands
{
    public class LoadSaveCommand
    {
        private readonly LoadSaveOptions options;

        public LoadSaveCommand(LoadSaveOptions options)
        {
            this.options = options;
        }


        public void Execute()
        {
            // Load the SVG
            var svg = Svg.Load(options.SvgPath);

            // Save the SVG
            var outPath = Path.Join("OUTPUT", Path.GetFileName(options.SvgPath));

            FileHelpers.SaveSvg(svg, outPath);

            // Optionally, print the SVG to the console
            if (options.Echo)
            {
                Svg.Save(svg, Console.Out);

                Console.WriteLine();
            }

            // Create the HTML wrapper, unless requested otherwise.
            string htmlPath = null;
            if (!options.NoHtml)
            {
                htmlPath = Path.Join("OUTPUT", Path.GetFileNameWithoutExtension(outPath) + ".html");

                FileHelpers.WriteHtmlWrapper(htmlPath, options.SvgPath, outPath);
            }

            // Optionally, open the HTML wrapper (or SVG) in the default browser
            // TODO
        }
    }
}
