// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.BaseTypes;
using SwishSvg.IO;

namespace SwishSvg.Shapes
{
    /// <summary>
    /// An SVG text span element.
    /// </summary>
    [SvgElement("tspan")]
    public class SvgTextSpanElement : SvgPresentationElement
    {
        /// <summary>
        /// Gets or sets the x coordinates of the text.
        /// </summary>
        // TODO - make this something other than a string.
        [SvgAttribute("x")]
        public string X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinates of the text.
        /// </summary>
        // TODO - make this something other than a string.
        [SvgAttribute("y")]
        public string Y { get; set; }

        /// <summary>
        /// Gets or sets the relative x coordinates of the text.
        /// </summary>
        // TODO - make this something other than a string.
        [SvgAttribute("dx")]
        public string DX { get; set; }

        /// <summary>
        /// Gets or sets the relative y coordinates of the text.
        /// </summary>
        // TODO - make this something other than a string.
        [SvgAttribute("dy")]
        public string DY { get; set; }

        /// <summary>
        /// Gets or sets the supplemental rotation about the current text position that will be applied to all of the glyphs corresponding to each character within this element.
        /// </summary>
        // TODO - make this something other than a string.
        [SvgAttribute("rotate")]
        public string Rotate { get; set; }
    }
}
