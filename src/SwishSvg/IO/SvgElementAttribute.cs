// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;

namespace SwishSvg.IO
{
    /// <summary>
    /// Specifies that a class represents an SVG element and gives it a name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class SvgElementAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgElementAttribute"/> class.
        /// </summary>
        /// <param name="elementName">The name of the SVG element.</param>
        public SvgElementAttribute(string elementName)
        {
            ElementName = elementName;
        }


        /// <summary>
        /// Gets the element name.
        /// </summary>
        public string ElementName { get; private set; }
    }
}
