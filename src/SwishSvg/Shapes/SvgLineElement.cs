// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.DataTypes;
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
        [SvgAttribute("x1")]
        public SvgLength X1 { get; set; }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the start of the line.
        /// </summary>
        [SvgAttribute("y1")]
        public SvgLength Y1 { get; set; }

        /// <summary>
        /// Gets or sets the x-axis coordinate of the end of the line.
        /// </summary>
        [SvgAttribute("x2")]
        public SvgLength X2 { get; set; }

        /// <summary>
        /// Gets or sets the y-axis coordinate of the end of the line.
        /// </summary>
        [SvgAttribute("y2")]
        public SvgLength Y2 { get; set; }
    }
}
