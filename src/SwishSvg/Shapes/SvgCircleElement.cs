// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG circle element.
    /// </summary>
    [SvgElement("circle")]
    public class SvgCircleElement : SvgElement
    {
        /// <summary>
        /// Gets or sets the X position of the element center.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("cx")]
        public string CX { get; set; }

        /// <summary>
        /// Gets or sets the Y position of the element center.
        /// </summary>
        // TODO - make this an SvgUnit or some such, and not a string
        [SvgAttribute("cy")]
        public string CY { get; set; }
    }
}
