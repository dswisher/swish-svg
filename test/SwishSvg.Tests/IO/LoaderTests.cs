
using System;

using FluentAssertions;
using Xunit;

namespace SwishSvg.Tests.IO
{
    public class LoaderTests
    {
        [Theory]
        [InlineData("svg", typeof(SvgSvgElement))]
        public void CanLoadElement(string elementName, Type elementType)
        {
            // Arrange
            var content = $"<{elementName}></{elementName}>";

            // Act
            var elem = Svg.FromString(content);

            // Assert
            elem.Should().BeOfType(elementType);
        }
    }
}
