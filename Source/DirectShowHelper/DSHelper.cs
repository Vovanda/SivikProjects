using System;
using System.Diagnostics;
using System.Linq;
using DirectShowLib;

namespace DirectShowHelper
{
  public sealed class DSHelper
  {
    public static IBaseFilter GetVideoSourceBaseFilter(DsDevice dsDevice)
    {
      if (dsDevice is null)
        throw new ArgumentNullException();

      Guid baseFilterIdentifier = typeof(IBaseFilter).GUID;
      dsDevice.Mon.BindToObject(null, null, ref baseFilterIdentifier, out object videoSourceObject);
      return (IBaseFilter)videoSourceObject;
    }

    public static string[] GetDevicesName()
    {
      return DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).Select( x => x.Name).ToArray();
    }

    public static DsDevice[] GetDevices()
    {
      return DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice).ToArray();
    }    

    public static void CheckHR(int hr) 
    {
      if (hr < 0)
      {
        Debug.WriteLine(DsError.GetErrorText(hr));
        DsError.ThrowExceptionForHR(hr);
      }
    }
    
    public static void CheckHR(int hr, string msg)
    {
      if (hr < 0)
      {
        Debug.WriteLine(msg);
        DsError.ThrowExceptionForHR(hr);
      }
    }       
  }
}
