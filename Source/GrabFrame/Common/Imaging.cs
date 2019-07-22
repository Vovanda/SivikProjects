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
      _knownAllowedImageFormats = typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public)
        .Where(p => p.PropertyType == typeof(ImageFormat)).Select(p =>
        {
          var format = p.GetValue(null);
          return (Format: format, Name: format.ToString());
        }).Where(p => AllowedImageFormats.Contains(p.Name))
        .ToDictionary(p => p.Format, p => p.Name);
    }

    public static string[] AllowedImageFormats = new[] { "Bmp", "Jpeg", "Png" };

    public static ImageFormat ParseImageFormat(string str)
    {
      return (ImageFormat)_knownAllowedImageFormats.FirstOrDefault(x => x.Value.ToLower() == str.ToLower()).Key;
    }

    public static string GetImageFormatName(ImageFormat format)
    {
      if (_knownAllowedImageFormats.TryGetValue(format.Guid, out string name))
      {
        return name;
      }
      return null;
    }

    public static string GetFormatName(this ImageFormat format)
    {
      return GetImageFormatName(format);
    }
        
    private static readonly Dictionary<object, string> _knownAllowedImageFormats;
  }
}