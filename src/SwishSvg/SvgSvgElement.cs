// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.IO;

namespace SwishSvg
{
    /// <summary>
    /// An SVG document or fragment.
    /// </summary>
    [SvgElement("svg")]
    public class SvgSvgElement : SvgElement
    {
        /// <summary>
        /// Gets or sets the width of the element.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("width")]
        public string Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the element.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("height")]
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets the viewbox of the element.
        /// </summary>
        // TODO - make this a specific type, not just a string
        [SvgAttribute("viewBox")]
        public string ViewBox { get; set; }

        /// <summary>
        /// Gets or sets the version of the element.
        /// </summary>
        [SvgAttribute("version")]
        public string Version { get; set; }
    }
}
