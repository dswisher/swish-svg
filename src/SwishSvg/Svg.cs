// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System.IO;
using System.Xml;

using SwishSvg.IO;

namespace SwishSvg
{
    /// <summary>
    /// Class to assist with reading SVG from files or streams.
    /// </summary>
    public static class Svg
    {
        /// <summary>
        /// Load an SVG document from the specified file.
        /// </summary>
        /// <param name="path">The path of the SVG document to load.</param>
        /// <returns>An SVG element.</returns>
        public static SvgSvgElement Load(string path)
        {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                // Load it up
                var element = Load(stream);

                // Make sure it is the proper type.
                if (element is SvgSvgElement svg)
                {
                    return svg;
                }
                else
                {
                    // TODO - is there a better way to handle arbitrary fragments? Maybe this method should be LoadDocument or some such?
                    // TODO - need a custom exception here
                    throw new System.Exception("Loading arbitrary SVG elements from a file is not (yet) supported.");
                }
            }
        }


        /// <summary>
        /// Load an SVG element from the specified string.
        /// </summary>
        /// <param name="content">The string from which to load the SVG element.</param>
        /// <returns>An SVG element.</returns>
        public static SvgElement FromString(string content)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            {
                writer.Write(content);
                writer.Flush();

                memoryStream.Position = 0;

                return Load(memoryStream);
            }
        }


        /// <summary>
        /// Read an SVG element from the specified stream.
        /// </summary>
        /// <param name="stream">The stream from which to read the element.</param>
        /// <returns>An element.</returns>
        public static SvgElement Load(Stream stream)
        {
            var readerSettings = new XmlReaderSettings
            {
                // TODO - for now, just ignore DTD processing
                DtdProcessing = DtdProcessing.Ignore
            };

            using (var reader = XmlReader.Create(stream, readerSettings))
            {
                // Load it up
                var element = Load(reader);

                // Make sure it is the proper type.
                if (element is SvgSvgElement svg)
                {
                    return svg;
                }
                else
                {
                    // TODO - is there a better way to handle arbitrary fragments? Maybe this method should be LoadDocument or some such?
                    // TODO - need a custom exception here
                    throw new System.Exception("Loading arbitrary SVG elements from a file is not (yet) supported.");
                }
            }
        }


        /// <summary>
        /// Read an SVG element from the specified XML reader.
        /// </summary>
        /// <param name="reader">The XML reader from which to read.</param>
        /// <returns>An element.</returns>
        public static SvgElement Load(XmlReader reader)
        {
            var loader = new Loader();
            var elem = loader.Load(reader);

            return elem;
        }
    }
}
