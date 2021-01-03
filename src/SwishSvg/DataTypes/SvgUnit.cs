// Copyright (c) Doug Swisher. All Rights Reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

namespace SwishSvg.DataTypes
{
    /// <summary>
    /// Defines the various units for <see cref="SvgLength"/>.
    /// </summary>
    public enum SvgUnit
    {
        /// <summary>
        /// Unit indicating no value.
        /// </summary>
        None,

        /// <summary>
        /// A unit of pixels.
        /// </summary>
        Pixel,

        /// <summary>
        /// Unit equal to the point size of the current font.
        /// </summary>
        Em,

        /// <summary>
        /// Percentage
        /// </summary>
        Percentage,

        /// <summary>
        /// A value in the current user coordinate system.
        /// </summary>
        User,

        /// <summary>
        /// Inches
        /// </summary>
        Inch,

        /// <summary>
        /// Centimeters
        /// </summary>
        Centimeter,

        /// <summary>
        /// Millimeters
        /// </summary>
        Millimeter
    }
}
