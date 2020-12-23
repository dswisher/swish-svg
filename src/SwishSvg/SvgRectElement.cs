// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.IO;

namespace SwishSvg
{
    /// <summary>
    /// An SVG rectangle element.
    /// </summary>
    [SvgElement("rect")]
    public class SvgRectElement : SvgElement
    {
        /// <summary>
        /// Gets or sets the X position of the element.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("x")]
        public string X { get; set; }

        /// <summary>
        /// Gets or sets the Y position of the element.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("y")]
        public string Y { get; set; }
    }
}
