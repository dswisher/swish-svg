// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG ellipse element.
    /// </summary>
    [SvgElement("ellipse")]
    public class SvgEllipseElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the x-axis coordinate of the center of the ellipse.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("cx")]
        public string CX { get; set; }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the center of the ellipse.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("cy")]
        public string CY { get; set; }

        /// <summary>
        /// Gets or sets the x-axis radius of the ellipse.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("rx")]
        public string RX { get; set; }

        /// <summary>
        /// Gets or sets the y-axis radius of the ellipse.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("ry")]
        public string RY { get; set; }
    }
}
