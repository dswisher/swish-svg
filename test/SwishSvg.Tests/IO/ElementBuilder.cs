
using System.Collections.Generic;
using System.Text;

namespace SwishSvg.Tests.IO
{
    public class ElementBuilder
    {
        private readonly Dictionary<string, string> attributes = new Dictionary<string, string>();


        public static ElementBuilder Create(string elementName, bool selfClosing = true)
        {
            return new ElementBuilder
            {
                ElementName = elementName,
                SelfClosing = selfClosing
            };
        }


        public string ElementName { get; private set; }
        public bool SelfClosing { get; private set; }


        public ElementBuilder AddAttribute(string name, string value)
        {
            attributes.Add(name, value);

            return this;
        }


        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append($"<{ElementName}");

            foreach (var att in attributes)
            {
                builder.Append($" {att.Key}=\"{att.Value}\"");
            }

            if (SelfClosing)
            {
                builder.Append(" />");
            }
            else
            {
                builder.Append($"></{ElementName}>");
            }

            return builder.ToString();
        }
    }
}
