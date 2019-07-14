using System;
using System.Runtime.InteropServices;
using System.Threading;
using DirectShowLib;

namespace GrabFrame
{
  public class SampleGrabberCB : ISampleGrabberCB
  {
    public int SampleCB(double SampleTime, IMediaSample pSample)
    {
      return 0;
    }

    public int BufferCB(double sampleTime, IntPtr pBuffer, int bufferLen)
    {
      if (!isWorking)
      {
        isWorking = true;
        byte[] grayImage = GetGrayImage(pBuffer, bufferLen);
        SaveGrayImageToRGBuffer(grayImage, pBuffer);
        //m_PictureReady.Set();
        isWorking = false;
      }
      return 0;
    }    

    private byte[] GetGrayImage(IntPtr pBuffer, int bufferLen)
    {
      byte[] grayImage = new byte[bufferLen / 3];
      byte[] pixelBuffer = new byte[3];
      int len = bufferLen / 3 - 1;
      for (int i = 0; i < len; i++)
      {
        Marshal.Copy(new IntPtr(pBuffer.ToInt32() + i * 3 + 2), pixelBuffer, 0, 3);
        grayImage[i] = (byte)(pixelBuffer[0] * 0.3 + pixelBuffer[1] * 0.59 + pixelBuffer[2] * 0.11);
      }
      return grayImage;
    }

    private void SaveGrayImageToRGBuffer(byte[] grayImage, IntPtr pBuffer)
    {
      for (int targetIndex = 0, i = 0; i < grayImage.Length; i++)
      {
        Marshal.WriteByte(pBuffer, targetIndex++, grayImage[i]);
        Marshal.WriteByte(pBuffer, targetIndex++, grayImage[i]);
        Marshal.WriteByte(pBuffer, targetIndex++, grayImage[i]);
      }
    }

    public ManualResetEvent m_PictureReady = new ManualResetEvent(false);
    private bool isWorking = false;
  }
}
