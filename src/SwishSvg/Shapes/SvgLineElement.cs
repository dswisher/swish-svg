// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG line element.
    /// </summary>
    [SvgElement("line")]
    public class SvgLineElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the x-axis coordinate of the start of the line.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("x1")]
        public string X1 { get; set; }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the start of the line.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("y1")]
        public string Y1 { get; set; }

        /// <summary>
        /// Gets or sets the x-axis coordinate of the end of the line.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("x2")]
        public string X2 { get; set; }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the end of the line.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("y2")]
        public string Y2 { get; set; }
    }
}
