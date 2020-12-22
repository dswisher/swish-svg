// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.Reflection;

namespace SwishSvg.IO
{
    /// <summary>
    /// Use reflection to find elements and attributes and cache them.
    /// </summary>
    internal static class ReflectionCache
    {
        /// <summary>
        /// For a given element name, return the corresponding type.
        /// </summary>
        /// <param name="elementName">The name of the element whose type is sought.</param>
        /// <returns>The type of element to create.</returns>
        public static Type GetTypeForElementName(string elementName)
        {
            // TODO - use reflection to do this! Hunt for SvgElement attributes...
            switch (elementName)
            {
                case "desc":
                    return typeof(SvgDescElement);

                case "rect":
                    return typeof(SvgRectElement);

                case "svg":
                    return typeof(SvgSvgElement);

                default:
                    return typeof(SvgUnknownElement);
            }
        }


        /// <summary>
        /// For a given attribute name, return the corresponding property (if any) on the specified element type.
        /// </summary>
        /// <param name="elementType">The element type whose property is sought.</param>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The PropertyInfo for the matching property, or null if no match.</returns>
        public static PropertyInfo GetPropertyInfo(Type elementType, string attributeName)
        {
            // TODO - use reflection to do this properly, and cache the result!
            if (elementType.Name == "SvgRectElement")
            {
                if (attributeName == "x")
                {
                    return elementType.GetProperty("X");
                }
                else if (attributeName == "y")
                {
                    return elementType.GetProperty("Y");
                }
            }

            return null;
        }
    }
}
