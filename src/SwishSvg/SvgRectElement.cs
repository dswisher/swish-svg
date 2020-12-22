// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

namespace SwishSvg
{
    /// <summary>
    /// An SVG rectangle element.
    /// </summary>
    public class SvgRectElement : SvgElement
    {
        /// <summary>
        /// Gets or sets the X position of the element.
        /// </summary>
        // TODO - move this up to a base class, shared by all things with X
        // TODO - make this an SvgUnit or some such, and not a string
        public string X { get; set; }

        /// <summary>
        /// Gets or sets the Y position of the element.
        /// </summary>
        // TODO - move this up to a base class, shared by all things with Y
        // TODO - make this an SvgUnit or some such, and not a string
        public string Y { get; set; }
    }
}
