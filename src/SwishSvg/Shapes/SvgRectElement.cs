// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.DataTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG rectangle element.
    /// </summary>
    [SvgElement("rect")]
    public class SvgRectElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the X position of the element.
        /// </summary>
        [SvgAttribute("x")]
        public SvgLength X { get; set; }

        /// <summary>
        /// Gets or sets the Y position of the element.
        /// </summary>
        [SvgAttribute("y")]
        public SvgLength Y { get; set; }

        /// <summary>
        /// Gets or sets the width of the element.
        /// </summary>
        [SvgAttribute("width")]
        public SvgLength Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the element.
        /// </summary>
        [SvgAttribute("height")]
        public SvgLength Height { get; set; }

        /// <summary>
        /// Gets or sets the rounded corner amount in the X direction.
        /// </summary>
        [SvgAttribute("rx")]
        public SvgLength RX { get; set; }

        /// <summary>
        /// Gets or sets the rounded corner amount in the Y direction.
        /// </summary>
        [SvgAttribute("ry")]
        public SvgLength RY { get; set; }
    }
}
