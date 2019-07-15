using System;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace DirectShowHelper
{
  public class DShowObject<T> : IDisposable     
    where T: class
  {
    #region Cast to DShowObject<T>
    public static explicit operator DShowObject<T>(Colour v) => Convert(v);
    public static explicit operator DShowObject<T>(InfTee v) => Convert(v);
    public static explicit operator DShowObject<T>(AVIDec v) => Convert(v);
    public static explicit operator DShowObject<T>(SmartTee v) => Convert(v);
    public static explicit operator DShowObject<T>(FilterGraph v) => Convert(v);
    public static explicit operator DShowObject<T>(VideoRenderer v) => Convert(v);
    public static explicit operator DShowObject<T>(SampleGrabber v) => Convert(v);
    public static explicit operator DShowObject<T>(CaptureGraphBuilder2 v) => Convert(v);
    #endregion

    private static DShowObject<T> Convert<U>(U item) where U: class
    {
      if (item is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }

    public DShowObject(T obj)
    {
      Object = obj ?? throw new ArgumentNullException(nameof(obj));
    }

    #region Dispose
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposed)
      {
        return;
      }

      if (Object != null)
      {
        Marshal.ReleaseComObject(Object);
      }

      Object = null;
      disposed = true;
    }

    ~DShowObject()
    {
      Dispose(false);
    }
    private bool disposed;

    #endregion

    public T Object { get; private set; }
  } 
}
