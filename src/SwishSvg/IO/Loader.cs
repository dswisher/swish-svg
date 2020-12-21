// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.Collections.Generic;
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
        /// Load an element from the specified reader.
        /// </summary>
        /// <param name="reader"> The reader from which the element will be loaded.</param>
        /// <returns>The element that was loaded.</returns>
        public SvgElement Load(XmlReader reader)
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

                        default:
                            Trace.TraceWarning("Unhandled XmlNodeType: {0}", reader.NodeType);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // TODO - should this throw?
                    Trace.TraceError(ex.Message);
                }
            }

            // TODO - hack!
            return new SvgSvgElement();
        }


        private void StartElement(XmlReader reader)
        {
            Trace.Indent();

            try
            {
                // Create an instance of the element
                var elementName = reader.LocalName;
                var elementNS = reader.NamespaceURI;

                Trace.TraceInformation("StartElement: {0}", elementName);

                SvgElement createdElem = null;

                if (elementNS == Constants.SvgNamespace || string.IsNullOrEmpty(elementNS))
                {
                    // TODO - use reflection to create the proper type
                    createdElem = new SvgSvgElement();

                    Trace.TraceInformation("created {0} element for name {1}", createdElem.GetType().Name, elementName);

                    // TODO - set attributes
                }
                else
                {
                    // TODO - handle non-SVG elements
                    throw new System.NotImplementedException($"Non-SVG elements are not yet implemented: {elementNS}:{elementName}");
                }

                // If we have a parent element, add this as a child
                // TODO - link child and parent (if any)

                // Push this element on the stack
                elementStack.Push(createdElem);
            }
            finally
            {
                Trace.Unindent();
            }
        }


        private void EndElement(XmlReader reader)
        {
            Trace.Indent();

            try
            {
                var elementName = reader.LocalName;
                var elementNS = reader.NamespaceURI;

                // Pop the element off the stack
                var element = elementStack.Pop();

                // TODO - handle content nodes and/or styles

                Trace.TraceInformation("EndElement: {0}", elementName);
            }
            finally
            {
                Trace.Unindent();
            }
        }
    }
}
