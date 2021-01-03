// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;

namespace SwishSvg.IO
{
    /// <summary>
    /// Class to handle the heavy lifting of loading SVG elements from an XML reader.
    /// </summary>
    internal class Loader
    {
        private Stack<SvgElement> elementStack = new Stack<SvgElement>();


        /// <summary>
        /// Gets the root of the SVG element tree.
        /// </summary>
        public SvgElement Root { get; private set; }


        /// <summary>
        /// Load an element from the specified reader.
        /// </summary>
        /// <param name="reader"> The reader from which the element will be loaded.</param>
        public void Load(XmlReader reader)
        {
            while (reader.Read())
            {
                try
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.IsEmptyElement)
                            {
                                StartElement(reader);
                                EndElement(reader);
                            }
                            else
                            {
                                StartElement(reader);
                            }

                            break;

                        case XmlNodeType.EndElement:
                            EndElement(reader);
                            break;

                        case XmlNodeType.Text:
                            // TODO - this is probably way too simplistic
                            elementStack.Peek().Content = reader.Value;
                            break;

                        case XmlNodeType.XmlDeclaration:
                            // TODO - what to do with the XmlDeclaration?
                            break;

                        case XmlNodeType.Whitespace:
                            // Ignored for now, until we find a reason not to ignore it
                            break;

                        case XmlNodeType.Comment:
                            // Ignored
                            break;

                        default:
                            Trace.TraceWarning("Unhandled XmlNodeType: {0}", reader.NodeType);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // TODO - throw a custom exception
                    // TODO - get more info about where the error occurred (line number, element, etc)
                    throw new Exception("Error loading", ex);
                }
            }
        }


        private void StartElement(XmlReader reader)
        {
            // Create an instance of the element
            var elementName = reader.LocalName;
            var elementNS = reader.NamespaceURI;

            SvgElement createdElem = null;

            if (elementNS == Constants.SvgNamespace || string.IsNullOrEmpty(elementNS))
            {
                var elementType = ReflectionCache.GetTypeForElementName(elementName);

                createdElem = (SvgElement)Activator.CreateInstance(elementType);

                // A little hackery, for now
                // TODO - figure out to properly create SvgUnknownElement, with the correct element name
                if (createdElem is SvgUnknownElement unknown)
                {
                    unknown.SetElementName(elementName);
                }

                // Set any attributes
                SetAttributes(reader, createdElem);
            }
            else
            {
                // TODO - handle non-SVG elements
                throw new System.NotImplementedException($"Non-SVG elements are not yet implemented: {elementNS}:{elementName}");
            }

            // If we have a parent element, add this as a child
            if (elementStack.Count == 0)
            {
                Root = createdElem;
            }
            else
            {
                var parent = elementStack.Peek();

                parent.Children.Add(createdElem);
                createdElem.Parent = parent;
            }

            // Push this element on the stack
            elementStack.Push(createdElem);
        }


        private void EndElement(XmlReader reader)
        {
            var elementName = reader.LocalName;
            var elementNS = reader.NamespaceURI;

            // Pop the element off the stack
            var element = elementStack.Pop();

            // TODO - handle content nodes and/or styles
        }


        private void SetAttributes(XmlReader reader, SvgElement element)
        {
            while (reader.MoveToNextAttribute())
            {
                // Ignore some things, at least for now
                if ((element.ElementName == "svg") && (reader.LocalName == "xmlns"))
                {
                    // TODO - figure out how to handle the SVG namespace
                    continue;
                }

                // Find the corresponding property, if possible
                var propInfo = ReflectionCache.GetPropertyInfo(element.GetType(), reader.LocalName);

                if (propInfo != null)
                {
                    var converter = TypeDescriptor.GetConverter(propInfo.PropertyType);

                    propInfo.SetValue(element, converter.ConvertFrom(reader.Value));
                }
                else
                {
                    Trace.TraceWarning("Unhandled {0} attribute: {1}", element.ElementName, reader.LocalName);

                    element.ExtraAttributes.Add(reader.LocalName, reader.Value);
                }
            }
        }
    }
}
