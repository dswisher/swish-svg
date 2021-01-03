
using System;
using System.IO;
using System.Reflection;

using FluentAssertions;
using SwishSvg.DataTypes;
using SwishSvg.Shapes;
using SwishSvg.Structure;
using Xunit;

namespace SwishSvg.Tests.IO
{
    public class LoaderTests
    {
        [Theory]
        [InlineData("circle", typeof(SvgCircleElement))]
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
            var elem = Svg.FromString<SvgDescElement>(desc);

            // Assert
            elem.Should().BeOfType<SvgDescElement>();
            elem.Content.Should().Be(content);
        }


        [Fact]
        public void CanLoadTitleContent()
        {
            // Arrange
            var content = "Some random text that is not lorem ipsum.";
            var desc = $"<title>{content}</title>";

            // Act
            var elem = Svg.FromString<SvgTitleElement>(desc);

            // Assert
            elem.Should().BeOfType<SvgTitleElement>();
            elem.Content.Should().Be(content);
        }


        [Fact]
        public void CanLoadRectAttributes()
        {
            // Arrange
            var x = new SvgLength(6.2f, SvgUnit.Inch);
            var y = new SvgLength(316, SvgUnit.User);
            var width = new SvgLength(22, SvgUnit.Em);
            var height = new SvgLength(23, SvgUnit.Centimeter);
            var rx = new SvgLength(54, SvgUnit.Inch);
            var ry = new SvgLength(45, SvgUnit.Inch);

            var xml = ElementBuilder.Create("rect")
                .AddAttribute("x", x.ToString())
                .AddAttribute("y", y.ToString())
                .AddAttribute("width", width.ToString())
                .AddAttribute("height", height.ToString())
                .AddAttribute("rx", rx.ToString())
                .AddAttribute("ry", ry.ToString());

            // Act
            var rect = Svg.FromString<SvgRectElement>(xml.ToString());

            // Assert
            rect.X.Should().Be(x);
            rect.Y.Should().Be(y);
            rect.Width.Should().Be(width);
            rect.Height.Should().Be(height);
            rect.RX.Should().Be(rx);
            rect.RY.Should().Be(ry);
        }


        [Fact]
        public void CanLoadCircleAttributes()
        {
            // Arrange
            var cx = new SvgLength(6.2f, SvgUnit.Inch);
            var cy = new SvgLength(316, SvgUnit.User);
            var r = new SvgLength(54, SvgUnit.Inch);

            var xml = ElementBuilder.Create("circle")
                .AddAttribute("cx", cx.ToString())
                .AddAttribute("cy", cy.ToString())
                .AddAttribute("r", r.ToString());

            // Act
            var circle = Svg.FromString<SvgCircleElement>(xml.ToString());

            // Assert
            circle.CX.Should().Be(cx);
            circle.CY.Should().Be(cy);
            circle.R.Should().Be(r);
        }


        [Fact]
        public void CanLoadEllipseAttributes()
        {
            // Arrange
            var cx = new SvgLength(6.2f, SvgUnit.Inch);
            var cy = new SvgLength(316, SvgUnit.User);
            var rx = new SvgLength(54, SvgUnit.Inch);
            var ry = new SvgLength(45, SvgUnit.Inch);

            var xml = ElementBuilder.Create("ellipse")
                .AddAttribute("cx", cx.ToString())
                .AddAttribute("cy", cy.ToString())
                .AddAttribute("rx", rx.ToString())
                .AddAttribute("ry", ry.ToString());

            // Act
            var ellipse = Svg.FromString<SvgEllipseElement>(xml.ToString());

            // Assert
            ellipse.CX.Should().Be(cx);
            ellipse.CY.Should().Be(cy);
            ellipse.RX.Should().Be(rx);
            ellipse.RY.Should().Be(ry);
        }


        [Fact]
        public void CanLoadLineAttributes()
        {
            // Arrange
            var x1 = new SvgLength(6.2f, SvgUnit.Inch);
            var y1 = new SvgLength(316, SvgUnit.User);
            var x2 = new SvgLength(54, SvgUnit.Inch);
            var y2 = new SvgLength(45, SvgUnit.Inch);

            var xml = ElementBuilder.Create("line")
                .AddAttribute("x1", x1.ToString())
                .AddAttribute("y1", y1.ToString())
                .AddAttribute("x2", x2.ToString())
                .AddAttribute("y2", y2.ToString());

            // Act
            var line = Svg.FromString<SvgLineElement>(xml.ToString());

            // Assert
            line.X1.Should().Be(x1);
            line.Y1.Should().Be(y1);
            line.X2.Should().Be(x2);
            line.Y2.Should().Be(y2);
        }


        [Theory]
        [InlineData("svg-spec/circle01.svg")]
        [InlineData("svg-spec/ellipse01.svg")]
        [InlineData("svg-spec/grouping01.svg")]
        [InlineData("svg-spec/line01.svg")]
        [InlineData("svg-spec/polygon01.svg")]
        [InlineData("svg-spec/polyline01.svg")]
        [InlineData("svg-spec/quad01.svg")]
        [InlineData("svg-spec/rect01.svg")]
        [InlineData("svg-spec/rect02.svg")]
        [InlineData("svg-spec/text01.svg")]
        [InlineData("svg-spec/triangle01.svg")]
        [InlineData("svg-spec/tspan01.svg")]
        [InlineData("svg-spec/tspan02.svg")]
        [InlineData("svg-spec/tspan03.svg")]
        [InlineData("svg-spec/tspan04.svg")]
        [InlineData("svg-spec/tspan05.svg")]
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
