// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG polygon element.
    /// </summary>
    [SvgElement("polygon")]
    public class SvgPolygonElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the points that make up the polygon.
        /// </summary>
        // TODO - make this a type other than string.
        [SvgAttribute("points")]
        public string Points { get; set; }
    }
}
