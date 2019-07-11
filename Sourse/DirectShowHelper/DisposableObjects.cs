using System;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace DirectShowHelper
{
  public class DShowObject<T> : IDisposable     
    where T: class
  { 
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
       
    public static explicit operator DShowObject<T>(CaptureGraphBuilder2 v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
        return null;
    }

    public static explicit operator DShowObject<T>(AVIDec v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }

    public static explicit operator DShowObject<T>(SmartTee v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }

    public static explicit operator DShowObject<T>(VideoRenderer v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }
    
    public static explicit operator DShowObject<T>(SampleGrabber v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }
    
    public static explicit operator DShowObject<T>(Colour v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }

    public static explicit operator DShowObject<T>(FilterGraph v)
    {
      if (v is T obj && obj != null)
      {
        return new DShowObject<T>(obj);
      }
      return null;
    }
  } 
}
