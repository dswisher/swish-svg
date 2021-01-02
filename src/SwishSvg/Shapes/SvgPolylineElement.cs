// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG polyline element.
    /// </summary>
    [SvgElement("polyline")]
    public class SvgPolylineElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the points that make up the polyline.
        /// </summary>
        // TODO - make this a type other than string.
        [SvgAttribute("points")]
        public string Points { get; set; }
    }
}
