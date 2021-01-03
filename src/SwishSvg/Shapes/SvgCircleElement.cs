// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.DataTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG circle element.
    /// </summary>
    [SvgElement("circle")]
    public class SvgCircleElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the X position of the element center.
        /// </summary>
        [SvgAttribute("cx")]
        public SvgLength CX { get; set; }

        /// <summary>
        /// Gets or sets the Y position of the element center.
        /// </summary>
        [SvgAttribute("cy")]
        public SvgLength CY { get; set; }

        /// <summary>
        /// Gets or sets the radius of the circle.
        /// </summary>
        [SvgAttribute("r")]
        public SvgLength R { get; set; }
    }
}
