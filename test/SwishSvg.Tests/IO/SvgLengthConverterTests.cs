
using FluentAssertions;
using SwishSvg.DataTypes;
using SwishSvg.IO;
using Xunit;

namespace SwishSvg.Tests.IO
{
    public class SvgLengthConverterTests
    {
        private readonly SvgLengthConverter converter = new SvgLengthConverter();


        [Fact]
        public void CanConvertFromString()
        {
            // Act and assert
            converter.CanConvertFrom(typeof(string)).Should().BeTrue();
        }


        [Fact]
        public void CanConvertToString()
        {
            // Act and assert
            converter.CanConvertTo(typeof(string)).Should().BeTrue();
        }


        [Fact]
        public void ConvertFromNone()
        {
            // Act
            var len = (SvgLength)converter.ConvertFromString("none");

            // Assert
            len.Should().BeSameAs(SvgLength.None);
        }


        [Theory]
        [InlineData("8.6px", 8.6, SvgUnit.Pixel)]
        [InlineData("17.2em", 17.2, SvgUnit.Em)]
        [InlineData("5.6%", 5.6, SvgUnit.Percentage)]
        [InlineData("4.3", 4.3, SvgUnit.User)]
        [InlineData("122in", 122, SvgUnit.Inch)]
        [InlineData("3cm", 3, SvgUnit.Centimeter)]
        [InlineData("30mm", 30, SvgUnit.Millimeter)]
        public void ConvertFromString(string str, float expectedVal, SvgUnit expectedUnit)
        {
            // Act
            var len = (SvgLength)converter.ConvertFromString(str);

            // Assert
            len.Value.Should().Be(expectedVal);
            len.Unit.Should().Be(expectedUnit);
        }


        [Theory]
        [InlineData(1, SvgUnit.None, "none")]
        [InlineData(3, SvgUnit.Pixel, "3px")]
        [InlineData(4, SvgUnit.Em, "4em")]
        [InlineData(5.2, SvgUnit.Percentage, "5.2%")]
        [InlineData(6.3, SvgUnit.User, "6.3")]
        [InlineData(7, SvgUnit.Inch, "7in")]
        [InlineData(8, SvgUnit.Centimeter, "8cm")]
        [InlineData(10, SvgUnit.Millimeter, "10mm")]
        public void ConvertToString(float val, SvgUnit unit, string expected)
        {
            // Arrange
            var len = new SvgLength(val, unit);

            // Act
            var actual = converter.ConvertToString(len);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
