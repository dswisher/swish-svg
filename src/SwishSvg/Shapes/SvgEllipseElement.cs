// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.DataTypes;
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
        [SvgAttribute("cx")]
        public SvgLength CX { get; set; }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the center of the ellipse.
        /// </summary>
        [SvgAttribute("cy")]
        public SvgLength CY { get; set; }

        /// <summary>
        /// Gets or sets the x-axis radius of the ellipse.
        /// </summary>
        [SvgAttribute("rx")]
        public SvgLength RX { get; set; }

        /// <summary>
        /// Gets or sets the y-axis radius of the ellipse.
        /// </summary>
        [SvgAttribute("ry")]
        public SvgLength RY { get; set; }
    }
}
