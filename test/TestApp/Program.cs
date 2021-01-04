
using System;
using System.Diagnostics;

using CommandLine;
using TestApp.Commands;
using TestApp.Options;

namespace TestApp
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));

                var parsedArgs = Parser.Default.ParseArguments<CreateOptions, LoadSaveOptions>(args);

                parsedArgs
                    .WithParsed<CreateOptions>(opts => new CreateCommand(opts).Execute())
                    .WithParsed<LoadSaveOptions>(opts => new LoadSaveCommand(opts).Execute());

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled exception:");
                Console.WriteLine(ex);

                return 1;
            }
        }
    }
}
