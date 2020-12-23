// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SwishSvg.IO
{
    /// <summary>
    /// Use reflection to find elements and attributes and cache them.
    /// </summary>
    internal static class ReflectionCache
    {
        private static readonly Dictionary<string, Type> ElementMap;
        private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> PropertyMap;

        static ReflectionCache()
        {
            // Build the element map by scanning the assembly for any classes with the SvgElement attribute
            ElementMap = typeof(ReflectionCache).Assembly.GetExportedTypes()
                .Where(x => x.GetCustomAttribute<SvgElementAttribute>() != null)
                .ToDictionary(k => k.GetCustomAttribute<SvgElementAttribute>().ElementName, v => v);

            // Build the property map by finding all the properties with the SvgProperty attribute.
            // Assume that every element has at least one property...
            PropertyMap = ElementMap
                .ToDictionary(k => k.Value, v => new Dictionary<string, PropertyInfo>());

            foreach (var element in PropertyMap)
            {
                foreach (var prop in element.Key.GetProperties())
                {
                    var att = prop.GetCustomAttribute<SvgAttributeAttribute>();

                    if (att != null)
                    {
                        element.Value.Add(att.AttributeName, prop);
                    }
                }
            }
        }


        /// <summary>
        /// For a given element type, return the corresponding name.
        /// </summary>
        /// <param name="elementType">The type of the element whose name is sought.</param>
        /// <returns>The name of the element.</returns>
        public static string GetNameForElementType(Type elementType)
        {
            // TODO - use a "reverse" dictionary for this for speed?
            return ElementMap
                .Where(x => x.Value == elementType)
                .Select(x => x.Key)
                .FirstOrDefault();
        }


        /// <summary>
        /// For a given element name, return the corresponding type.
        /// </summary>
        /// <param name="elementName">The name of the element whose type is sought.</param>
        /// <returns>The type of element.</returns>
        public static Type GetTypeForElementName(string elementName)
        {
            if (ElementMap.ContainsKey(elementName))
            {
                return ElementMap[elementName];
            }

            return typeof(SvgUnknownElement);
        }


        /// <summary>
        /// For a given attribute name, return the corresponding property (if any) on the specified element type.
        /// </summary>
        /// <param name="elementType">The element type whose property is sought.</param>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns>The PropertyInfo for the matching property, or null if no match.</returns>
        public static PropertyInfo GetPropertyInfo(Type elementType, string attributeName)
        {
            if (!PropertyMap.ContainsKey(elementType))
            {
                return null;
            }

            var map = PropertyMap[elementType];

            if (map.ContainsKey(attributeName))
            {
                return map[attributeName];
            }

            return null;
        }
    }
}
