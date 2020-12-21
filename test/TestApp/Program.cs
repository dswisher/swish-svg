
using System;
using System.Diagnostics;

using SwishSvg;

namespace TestApp
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

                if (args.Length != 1)
                {
                    Console.WriteLine("You must specify the name of an SVG file to load.");
                    return 1;
                }

                var path = args[0];
                var svg = Svg.Load(path);

                Svg.Save(svg, Console.Out);

                Console.WriteLine();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception:");
                Console.WriteLine(ex);

                return 2;
            }
        }
    }
}
