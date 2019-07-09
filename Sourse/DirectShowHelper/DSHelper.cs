using System;
using System.Diagnostics;
using DirectShowLib;

namespace DirectShowHelper
{
  public sealed class DSHelper
  {
    public static IBaseFilter GetVideoSourceBaseFilter(DsDevice dsDevice)
    {
      Guid baseFilterIdentifier = typeof(IBaseFilter).GUID;
      dsDevice.Mon.BindToObject(null, null, ref baseFilterIdentifier, out object videoSourceObject);
      return (IBaseFilter)videoSourceObject;
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
