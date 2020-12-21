
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
        [InlineData("unknown-name", typeof(SvgUnknownElement))]
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
    }
}
