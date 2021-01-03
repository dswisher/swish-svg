// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

using System;
using System.ComponentModel;
using System.Globalization;

using SwishSvg.DataTypes;

namespace SwishSvg.IO
{
    /// <summary>
    /// Type converter for SvgLength.
    /// </summary>
    internal class SvgLengthConverter : TypeConverter
    {
        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }


        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }


        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            // TODO - throw a prettier exception if not a string
            var str = (string)value;

            // None is a special case
            if (str == "none")
            {
                return SvgLength.None;
            }

            // Find the position of the unit
            // TODO - handle exponential notation?
            int unitPos = -1;
            for (var i = 0; i < str.Length; i++)
            {
                if ((str[i] == '%') || char.IsLetter(str[i]))
                {
                    unitPos = i;
                    break;
                }
            }

            float val;
            if (!float.TryParse((unitPos > -1) ? str.Substring(0, unitPos) : str, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
            {
                val = 0.0f;
            }

            if (unitPos == -1)
            {
                return new SvgLength(val, SvgUnit.User);
            }

            var unit = str.Substring(unitPos).ToLower();

            switch (unit)
            {
                case "px":
                    return new SvgLength(val, SvgUnit.Pixel);

                case "em":
                    return new SvgLength(val, SvgUnit.Em);

                case "%":
                    return new SvgLength(val, SvgUnit.Percentage);

                case "in":
                    return new SvgLength(val, SvgUnit.Inch);

                case "cm":
                    return new SvgLength(val, SvgUnit.Centimeter);

                case "mm":
                    return new SvgLength(val, SvgUnit.Millimeter);
            }

            throw new FormatException($"Length is in an invalid format: '{str}'.");
        }


        /// <inheritdoc />
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return ((SvgLength)value).ToString();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
