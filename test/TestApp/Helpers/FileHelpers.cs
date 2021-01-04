
using System;
using System.IO;

using SwishSvg;

namespace TestApp.Helpers
{
    public static class FileHelpers
    {
        public static void SaveSvg(SvgSvgElement svg, string path)
        {
            // Make sure the output directory exists
            var outDir = Path.GetDirectoryName(path);

            if (!Directory.Exists(outDir))
            {
                Console.WriteLine("Creating output directory: {0}.", outDir);
                Directory.CreateDirectory(outDir);
            }

            // Write the SVG
            using (var writer = new StreamWriter(path))
            {
                Svg.Save(svg, writer);
            }

            // Tell the user where we wrote it
            Console.WriteLine("Wrote SVG to {0}.", path);
        }


        public static void WriteHtmlWrapper(string htmlPath, string svgPath1, string svgPath2)
        {
            // Make the two images relative to the HTML file
            var svgRel1 = MakeRelativeTo(htmlPath, svgPath1);
            var svgRel2 = MakeRelativeTo(htmlPath, svgPath2);

            // Write the file
            using (var writer = new StreamWriter(htmlPath))
            {
                // Start it
                writer.WriteLine("<html><head><title>SVG Sample</title></head><body>");

                // Add the two SVG images
                // TODO - include border and label
                writer.WriteLine($"<img src=\"{svgRel1}\" />");
                writer.WriteLine($"<img src=\"{svgRel2}\" />");

                // Finish it
                writer.WriteLine("</body></html>");
            }

            // Tell the user what we did
            Console.WriteLine("Wrote HTML wrapper to {0}.", htmlPath);
        }


        public static string MakeRelativeTo(string basePath, string otherPath)
        {
            var baseDir = Path.GetDirectoryName(basePath);

            return Path.GetRelativePath(baseDir, otherPath);
        }
    }
}
