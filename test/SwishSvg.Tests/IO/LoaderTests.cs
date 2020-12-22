
using System;

using FluentAssertions;
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
            // TODO - add a FromString overload that is type-safe, so we don't have to cast
            var rect = (SvgRectElement)Svg.FromString(xml.ToString());

            // Assert
            rect.X.Should().Be(xVal);
            rect.Y.Should().Be(yVal);
        }
    }
}
