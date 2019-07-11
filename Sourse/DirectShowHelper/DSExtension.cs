using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DirectShowLib;

namespace DirectShowHelper
{
  public static class DSExtension
  {
    public static T AddFilter<T>(this T graph, IBaseFilter filter) where T : IFilterGraph
    {
      if (graph != null && filter != null)
      {
        int hr = graph.AddFilter(filter, filter.GetName());
        DSHelper.CheckHR(hr);
        return graph;
      }
      throw new ArgumentNullException();
    }
     
    public static T AddFilters<T>(this T graph, params IBaseFilter[] filters) where T : IFilterGraph
    {
      if (graph == null)
      {
        throw new ArgumentNullException(nameof(graph));
      }

      if (filters == null)
      {
        throw new ArgumentNullException(nameof(filters));
      }

      for (int i = 0; i < filters.Length; i++)
      {
        graph.AddFilter(filters[i]);
      }

      return graph;
    }

    public static T AddFilters<T>(this T graph, params DShowObject<IBaseFilter>[] filters) where T : IFilterGraph
    {
      if (graph == null)
      {
        throw new ArgumentNullException(nameof(graph));
      }

      if (filters == null)
      {
        throw new ArgumentNullException(nameof(filters));
      }

      for (int i = 0; i < filters.Length; i++)
      {
        graph.AddFilter(filters[i].Object);
      }

      return graph;
    }

    public static (T graph, IBaseFilter lastConnectedFilter) ConnectDirect<T>(this T graph, IBaseFilter first, IBaseFilter second, int idxOutPin, int idxInPin, AMMediaType pmt = null) where T : IFilterGraph
    {      
      if (graph != null && first != null && second != null)
      {
        var outPin = first.GetPins((x) => x.dir == PinDirection.Output).Skip(idxOutPin).Take(1).FirstOrDefault();
        var inPin = second.GetPins((x) => x.dir == PinDirection.Input).Skip(idxInPin).Take(1).FirstOrDefault();
        int hr = graph.ConnectDirect(outPin, inPin, pmt);
        DSHelper.CheckHR(hr);
        return (graph, second);
      }
      throw new ArgumentNullException();
    }
        
    public static (T graph, IBaseFilter lastConnectedFilter) Next<T>(this (T graph, IBaseFilter first) item, IBaseFilter nextFilter, int idxOutPin, int idxInPin, AMMediaType pmt = null) where T : IFilterGraph
    {
      if (item.graph != null && item.first != null && nextFilter != null)
      {
        var outPin = item.first.GetPins((x) => x.dir == PinDirection.Output).Skip(idxOutPin).Take(1).FirstOrDefault();
        var inPin = nextFilter.GetPins((x) => x.dir == PinDirection.Input).Skip(idxInPin).Take(1).FirstOrDefault();
        int hr = item.graph.ConnectDirect(outPin, inPin, pmt);
        DSHelper.CheckHR(hr);
        return (item.graph, nextFilter);
      }
      throw new ArgumentNullException();
    }

    public static (T graph, DShowObject<IBaseFilter> lastConnectedFilter) ConnectDirect<T>(this T graph, DShowObject<IBaseFilter> first, DShowObject<IBaseFilter> second, int idxOutPin, int idxInPin, AMMediaType pmt = null) where T : IFilterGraph
    {
      if (graph != null && first != null && second != null)
      {
        var outPin = first.Object.GetPins((x) => x.dir == PinDirection.Output).Skip(idxOutPin).Take(1).FirstOrDefault();
        var inPin = second.Object.GetPins((x) => x.dir == PinDirection.Input).Skip(idxInPin).Take(1).FirstOrDefault();
        int hr = graph.ConnectDirect(outPin, inPin, pmt);
        DSHelper.CheckHR(hr);
        return (graph, second);
      }
      throw new ArgumentNullException();
    }

    public static (T graph, DShowObject<IBaseFilter> lastConnectedFilter) Next<T>(this (T graph, DShowObject<IBaseFilter> first) item, DShowObject<IBaseFilter> nextFilter, int idxOutPin, int idxInPin, AMMediaType pmt = null) where T : IFilterGraph
    {
      if (item.graph != null && item.first != null && nextFilter != null)
      {
        var outPin = item.first.Object.GetPins((x) => x.dir == PinDirection.Output).Skip(idxOutPin).Take(1).FirstOrDefault();
        var inPin = nextFilter.Object.GetPins((x) => x.dir == PinDirection.Input).Skip(idxInPin).Take(1).FirstOrDefault();
        int hr = item.graph.ConnectDirect(outPin, inPin, pmt);
        DSHelper.CheckHR(hr);
        return (item.graph, nextFilter);
      }
      throw new ArgumentNullException();
    }
    
    public static IEnumerable<IPin> GetPins(this IBaseFilter filter, Func<PinInfo, bool> predicate = null)
    {
      int hr = filter.EnumPins(out IEnumPins epins);
      if (hr < 0)
      {
        yield break;
      }

      IntPtr fetched = Marshal.AllocCoTaskMem(4);
      IPin[] pins = new IPin[1];
      while (epins.Next(1, pins, fetched) == 0)
      {
        pins[0].QueryPinInfo(out PinInfo pinfo);
        DsUtils.FreePinInfo(pinfo);
        if (predicate is null || predicate(pinfo))
        {
          yield return pins[0];
        }
      }
      yield break;
    }

    public static string GetName(this IBaseFilter filter)
    {
      if (filter == null)
      {
        throw new ArgumentNullException(nameof(filter));
      }

      FilterInfo info;
      filter.QueryFilterInfo(out info);
      return info.achName;
    }
  }
}
