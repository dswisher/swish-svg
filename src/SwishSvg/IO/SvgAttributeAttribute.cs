// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;

namespace SwishSvg.IO
{
    /// <summary>
    /// Specifies that property is an SVG property, and gives it a name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class SvgAttributeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgAttributeAttribute"/> class.
        /// </summary>
        /// <param name="attributeName">The name of the SVG element.</param>
        public SvgAttributeAttribute(string attributeName)
        {
            AttributeName = attributeName;
        }


        /// <summary>
        /// Gets the attribute name.
        /// </summary>
        public string AttributeName { get; private set; }
    }
}
