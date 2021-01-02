// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

namespace SwishSvg
{
    /// <summary>
    /// An unknown element that is part of the SVG namespace.
    /// </summary>
    public class SvgUnknownElement : SvgElement
    {
        /// <summary>
        /// Set the element name.
        /// </summary>
        /// <param name="name">The new element name.</param>
        // TODO - this is hacky, and should be removed? Need a namespace, at least?
        internal void SetElementName(string name)
        {
            ElementName = name;
        }
    }
}
