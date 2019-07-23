using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;

namespace GrabFrame.Common.Imaging
{
  static class Imaging
  {
    static Imaging()
    {
      _allowedImageFormats = new Dictionary<string, ImageFormat>(StringComparer.OrdinalIgnoreCase)
      {
        ["bmp"] = ImageFormat.Bmp,
        ["jpg"] = ImageFormat.Jpeg,
        ["png"] = ImageFormat.Png
      };
    }

    public static string[] AllowedImageFormatsNames  => _allowedImageFormats.Keys.ToArray();

    public static ImageFormat[] AllowedImageFormats => _allowedImageFormats.Values.ToArray();

    public static ImageFormat GetAllowedImageFormatByName(string formatName)
    {
      if (formatName.ToLower() == "jpeg")
      {
        formatName = "jpg";
      }

      _allowedImageFormats.TryGetValue(formatName, out ImageFormat imageFormat);
      return imageFormat;
    }
        
    private static readonly Dictionary<string, ImageFormat> _allowedImageFormats;
  }
}