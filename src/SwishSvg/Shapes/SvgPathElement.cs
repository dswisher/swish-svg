// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG path element.
    /// </summary>
    [SvgElement("path")]
    public class SvgPathElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the definition of the outline of a shape.
        /// </summary>
        // TODO - make this something other than a string
        [SvgAttribute("d")]
        public string PathData { get; set; }
    }
}
