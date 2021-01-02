// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.IO;

namespace SwishSvg.Shapes
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
        /// Gets or sets the rounded corner amount in the X direction.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("rx")]
        public string RX { get; set; }

        /// <summary>
        /// Gets or sets the rounded corner amount in the Y direction.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("ry")]
        public string RY { get; set; }

        /// <summary>
        /// Gets or sets the fill of the element.
        /// </summary>
        // TODO - make this something other than a string
        [SvgAttribute("fill")]
        public string Fill { get; set; }

        /// <summary>
        /// Gets or sets the stroke of the element.
        /// </summary>
        // TODO - make this something other than a string
        [SvgAttribute("stroke")]
        public string Stroke { get; set; }

        /// <summary>
        /// Gets or sets the stroke width of the element.
        /// </summary>
        // TODO - make this something other than a string
        [SvgAttribute("stroke-width")]
        public string StrokeWidth { get; set; }
    }
}
