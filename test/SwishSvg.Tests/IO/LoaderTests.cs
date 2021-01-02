
using System;
using System.IO;
using System.Reflection;

using FluentAssertions;
using SwishSvg.Shapes;
using Xunit;

namespace SwishSvg.Tests.IO
{
    public class LoaderTests
    {
        [Theory]
        [InlineData("desc", typeof(SvgDescElement))]
        [InlineData("svg", typeof(SvgSvgElement))]
        [InlineData("rect", typeof(SvgRectElement))]
        [InlineData("not-an-svg-element", typeof(SvgUnknownElement))]
        public void CanLoadElement(string elementName, Type elementType)
        {
            // Arrange
            var xml = $"<{elementName}></{elementName}>";

            // Act
            var elem = Svg.FromString(xml);

            // Assert
            elem.Should().BeOfType(elementType);
        }


        [Fact]
        public void CanLoadDescContent()
        {
            // Arrange
            var content = "Some random text that is not lorem ipsum.";
            var desc = $"<desc>{content}</desc>";

            // Act
            var elem = Svg.FromString(desc);

            // Assert
            elem.Should().BeOfType<SvgDescElement>();
            elem.Content.Should().Be(content);
        }


        [Fact]
        public void CanLoadRectAttributes()
        {
            // Arrange
            const string xVal = "3cm";
            const string yVal = "8in";

            var xml = ElementBuilder.Create("rect")
                .AddAttribute("x", xVal)
                .AddAttribute("y", yVal);

            // Act
            var rect = Svg.FromString<SvgRectElement>(xml.ToString());

            // Assert
            rect.X.Should().Be(xVal);
            rect.Y.Should().Be(yVal);
        }


        [Theory]
        [InlineData("svg-spec/rect01.svg")]
        // [InlineData("svg-spec/rect02.svg")]
        public void CanLoadSample(string samplePath)
        {
            // Arrange
            string content;
            var assembly = Assembly.GetExecutingAssembly();
            var cleaned = samplePath.Replace("-", "_").Replace("/", ".");
            var path = "SwishSvg.Tests.Samples." + cleaned;
            using (var stream = assembly.GetManifestResourceStream(path))
            {
                stream.Should().NotBeNull($"{path} should exist");

                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            // Act
            var svg = Svg.FromString<SvgSvgElement>(content);

            // Assert
            VerifyNoUnknownElements(svg, "svg");
            VerifyNoExtraAttributes(svg, "svg");
        }


        private void VerifyNoUnknownElements(SvgElement element, string path)
        {
            element.Should().NotBeOfType<SvgUnknownElement>($"{path} should be parsed");

            foreach (var child in element.Children)
            {
                VerifyNoUnknownElements(child, $"{path}.{child.ElementName}");
            }
        }


        private void VerifyNoExtraAttributes(SvgElement element, string path)
        {
            foreach (var extra in element.ExtraAttributes)
            {
                string extraAtt;
                if (element.Id == null)
                {
                    extraAtt = $"{path}@{extra.Key}";
                }
                else
                {
                    extraAtt = $"{path}(id={element.Id})@{extra.Key}";
                }

                extraAtt += $" = \"{extra.Value}\"";

                extraAtt.Should().BeEmpty();
            }

            foreach (var child in element.Children)
            {
                VerifyNoExtraAttributes(child, $"{path}.{child.ElementName}");
            }
        }
    }
}
