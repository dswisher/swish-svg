// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.ComponentModel;
using System.Globalization;

using SwishSvg.IO;

namespace SwishSvg.DataTypes
{
    /// <summary>
    /// A length is a distance measurement, given as a number along with a unit which may be optional.
    /// </summary>
    [TypeConverter(typeof(SvgLengthConverter))]
    public class SvgLength
    {
        /// <summary>
        /// Gets a length of none.
        /// </summary>
        public static readonly SvgLength None = new SvgLength(0, SvgUnit.None);


        /// <summary>
        /// Initializes a new instance of the <see cref="SvgLength"/> class.
        /// </summary>
        /// <param name="value">The value for the length.</param>
        /// <param name="unit">The unit for the length.</param>
        public SvgLength(float value, SvgUnit unit = SvgUnit.User)
        {
            Value = value;
            Unit = unit;
        }


        /// <summary>
        /// Gets the value of the length.
        /// </summary>
        public float Value { get; private set; }


        /// <summary>
        /// Gets the unit of the length.
        /// </summary>
        public SvgUnit Unit { get; private set; }


        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            var other = obj as SvgLength;

            if (other == null)
            {
                return false;
            }

            return Value == other.Value && Unit == other.Unit;
        }


        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Unit.GetHashCode();
        }


        /// <inheritdoc />
        public override string ToString()
        {
            string unit;

            switch (Unit)
            {
                case SvgUnit.None:
                    return "none";

                case SvgUnit.Pixel:
                    unit = "px";
                    break;

                case SvgUnit.Em:
                    unit = "em";
                    break;

                case SvgUnit.Percentage:
                    unit = "%";
                    break;

                case SvgUnit.User:
                    unit = string.Empty;
                    break;

                case SvgUnit.Inch:
                    unit = "in";
                    break;

                case SvgUnit.Centimeter:
                    unit = "cm";
                    break;

                case SvgUnit.Millimeter:
                    unit = "mm";
                    break;

                default:
                    throw new Exception($"Unhandled length unit: {Unit}");
            }

            return string.Concat(Value.ToString(CultureInfo.InvariantCulture), unit);
        }
    }
}
