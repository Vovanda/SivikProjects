using System;
using System.Runtime.InteropServices;
using System.Threading;
using DirectShowLib;

namespace GrabFrame
{
  public class GrayScaleSGCallBack : ISampleGrabberCB
  {
    [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
    private static extern void CopyMemory(IntPtr Destination, IntPtr Source, int Length);
    
    public void CalculateFrameRate()
    {
      if (Environment.TickCount - lastTick >= 1000)
      {
        currentFrameRate = frameRate;
        frameRate = 0;
        lastTick = Environment.TickCount;
      }
      frameRate++;
    }

    public int BufferCB(double sampleTime, IntPtr pBuffer, int bufferLen)
    {
      if (!isWorking)
      {
        CalculateFrameRate();
        isWorking = true;
        if (bufferLenght != bufferLen)
        {
          bufferLenght = bufferLen;
          grayImageBytes = new byte[bufferLenght / 3];
        }
        CreateGrayImage(pBuffer);
        SaveGrayImageToBuffer(pBuffer);
        if (!gotOne)
        {
          try
          {
            gotOne = true;
            scan = Marshal.AllocCoTaskMem(bufferLen);

            CopyMemory(scan, pBuffer, bufferLen);
            _pictureReady.Set();
          }
          catch
          {
            Marshal.FreeCoTaskMem(scan);
            scan = IntPtr.Zero;
          }
        }
        isWorking = false;
      }
      return 0;
    }

    public IntPtr GetScan()
    {
      _pictureReady.Reset();
      gotOne = false;
      if (!_pictureReady.WaitOne(100, false))
      {
        return IntPtr.Zero;
      }
      return scan;
    }

    public int FrameRate => currentFrameRate;

    private void CreateGrayImage(IntPtr pBuffer)
    {
      int len = bufferLenght / 3 - 1;
      for (int i = 0; i < len; i++)
      {
        Marshal.Copy(new IntPtr(pBuffer.ToInt32() + i * 3 + 2), pixelBuffer, 0, 3);
        grayImageBytes[i] = (byte)(pixelBuffer[0] * 0.3 + pixelBuffer[1] * 0.59 + pixelBuffer[2] * 0.11);
      }
    }

    private void SaveGrayImageToBuffer(IntPtr pBuffer)
    {
      for (int targetIndex = 0, i = 0; i < grayImageBytes.Length; i++)
      {
        Marshal.WriteByte(pBuffer, targetIndex++, grayImageBytes[i]);
        Marshal.WriteByte(pBuffer, targetIndex++, grayImageBytes[i]);
        Marshal.WriteByte(pBuffer, targetIndex++, grayImageBytes[i]);
      }
    }

    int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample) => 0;

    private int lastTick;
    private int frameRate;
    private int currentFrameRate;

    private IntPtr scan = IntPtr.Zero;
    private bool gotOne = true;
    private bool isWorking = false;
    private int bufferLenght = 0;
    private byte[] grayImageBytes;
    private readonly byte[] pixelBuffer = new byte[3];
    private readonly ManualResetEvent _pictureReady  = new ManualResetEvent(false);
  }
}
