// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System.Collections.Generic;
using System.Xml;

using SwishSvg.IO;

namespace SwishSvg
{
    /// <summary>
    /// The base class from which all other SVG elements derive.
    /// </summary>
    public abstract class SvgElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvgElement"/> class.
        /// </summary>
        protected SvgElement()
        {
            ElementName = ReflectionCache.GetNameForElementType(this.GetType());

            if (ElementName == null)
            {
                // TODO - HACK! Throw? Should never get here!
                ElementName = "UNKNOWN";
            }

            Children = new List<SvgElement>();
            ExtraAttributes = new Dictionary<string, string>();
        }


        /// <summary>
        /// Gets or sets the ID of the element.
        /// </summary>
        [SvgAttribute("id")]
        public string Id { get; set; }


        /// <summary>
        /// Gets or sets the content of the element.
        /// </summary>
        public string Content { get; set; }


        /// <summary>
        /// Gets or sets the name of this element.
        /// </summary>
        // NOTE: this is protected, only for the SvgUnknownElement hack
        public string ElementName { get; protected set; }


        /// <summary>
        /// Gets the dictionary of attributes that do not have a corresponding property (SvgAttribute).
        /// </summary>
        // TODO - need a namespace on these!
        public Dictionary<string, string> ExtraAttributes { get; private set; }


        /// <summary>
        /// Gets or sets the parent of this element.
        /// </summary>
        public SvgElement Parent { get; set; }


        /// <summary>
        /// Gets the list of children for this element.
        /// </summary>
        public List<SvgElement> Children { get; private set; }


        /// <summary>
        /// Write the element to the specified XML writer.
        /// </summary>
        /// <param name="writer">The XML writer where the element will be written.</param>
        public void Write(XmlWriter writer)
        {
            WriteStartElement(writer);
            WriteChildren(writer);
            WriteEndElement(writer);
        }


        private void WriteStartElement(XmlWriter writer)
        {
            writer.WriteStartElement(ElementName);

            WriteAttributes(writer);
        }


        private void WriteEndElement(XmlWriter writer)
        {
            writer.WriteEndElement();
        }


        private void WriteAttributes(XmlWriter writer)
        {
            // Write out the extra attributes
            foreach (var extra in ExtraAttributes)
            {
                writer.WriteAttributeString(extra.Key, extra.Value);
            }

            // Write out the non-extra attributes
            var props = ReflectionCache.GetPropertyInfos(this.GetType());

            if (props == null)
            {
                return;
            }

            foreach (var pair in props)
            {
                // TODO - if the attribute is empty/null/default, do not write it
                var name = pair.Key;
                var val = pair.Value.GetValue(this);

                if (val != null)
                {
                    writer.WriteAttributeString(name, val.ToString());
                }
            }
        }


        private void WriteChildren(XmlWriter writer)
        {
            if (!string.IsNullOrEmpty(Content))
            {
                writer.WriteString(Content);
            }

            foreach (var child in Children)
            {
                child.Write(writer);
            }
        }
    }
}
