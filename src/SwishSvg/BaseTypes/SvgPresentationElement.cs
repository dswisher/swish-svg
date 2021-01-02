// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using SwishSvg.IO;

namespace SwishSvg.BaseTypes
{
    /// <summary>
    /// Base class for elements that involve presentation.
    /// </summary>
    public abstract class SvgPresentationElement : SvgElement
    {
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

        /// <summary>
        /// Gets or sets the transform for the element.
        /// </summary>
        // TODO - make this a type other than a string.
        [SvgAttribute("transform")]
        public string Transform { get; set; }

        /// <summary>
        /// Gets or sets the font family of the element.
        /// </summary>
        // TODO - make this something other than a string?
        [SvgAttribute("font-family")]
        public string FontFamily { get; set; }

        /// <summary>
        /// Gets or sets the font size of the element.
        /// </summary>
        // TODO - make this something other than a string
        [SvgAttribute("font-size")]
        public string FontSize { get; set; }

        /// <summary>
        /// Gets or sets the font weight of the element.
        /// </summary>
        // TODO - make this something other than a string
        [SvgAttribute("font-weight")]
        public string FontWeight { get; set; }
    }
}
