// <copyright file="GetImage.cs">
//  Copyright (c) 2015. MIT License.
// </copyright>

namespace GeoIP
{
    using System.Drawing;
    using System.Reflection;

    /// <summary>Returns Flag image from given country code</summary>
    internal static class GetImage
    {
        /// <summary>Returns a.</summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>Country flag</returns>
        internal static Bitmap GetBitmap(string countryCode)
        {
            return new Bitmap(Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("GeoIP.Flags." + countryCode + ".png")));
        }
    }
}
