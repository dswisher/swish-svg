
using System;
using System.Linq;

using FluentAssertions;
using SwishSvg.IO;
using SwishSvg.Shapes;
using SwishSvg.Structure;
using Xunit;

namespace SwishSvg.Tests.IO
{
    public class ReflectionCacheTests
    {
        [Theory]
        [InlineData("circle", typeof(SvgCircleElement))]
        [InlineData("desc", typeof(SvgDescElement))]
        [InlineData("ellipse", typeof(SvgEllipseElement))]
        [InlineData("rect", typeof(SvgRectElement))]
        [InlineData("svg", typeof(SvgSvgElement))]
        public void CanGetTypeForElementName(string elementName, Type expectedType)
        {
            // Act
            var actualType = ReflectionCache.GetTypeForElementName(elementName);

            // Assert
            actualType.Should().Be(expectedType);
        }


        [Theory]
        [InlineData(typeof(SvgRectElement), "x")]
        [InlineData(typeof(SvgRectElement), "y")]
        [InlineData(typeof(SvgRectElement), "id")]
        [InlineData(typeof(SvgCircleElement), "cx")]
        [InlineData(typeof(SvgCircleElement), "cy")]
        [InlineData(typeof(SvgCircleElement), "id")]
        [InlineData(typeof(SvgEllipseElement), "cx")]
        [InlineData(typeof(SvgEllipseElement), "cy")]
        public void CanGetInfoForProperty(Type elementType, string attributeName)
        {
            // Act
            var info = ReflectionCache.GetPropertyInfo(elementType, attributeName);

            // Assert
            info.Should().NotBeNull();
        }


        [Theory]
        [InlineData(typeof(SvgRectElement), "id", "x", "y")]
        [InlineData(typeof(SvgCircleElement), "id", "cx", "cy")]
        public void CanGetPropertiesForElement(Type elementType, params string[] attributeNames)
        {
            // Act
            var pairs = ReflectionCache.GetPropertyInfos(elementType);

            // Assert
            var actualNames = pairs.Select(x => x.Key);

            actualNames.Should().Contain(attributeNames);
        }
    }
}
