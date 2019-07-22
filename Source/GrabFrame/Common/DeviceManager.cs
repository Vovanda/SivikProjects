using System.Collections.Generic;
using System.Linq;
using DirectShowHelper;
using DirectShowLib;

namespace GrabFrame
{
  internal class DeviceManager
  {
    public static readonly string NameOfNoneDevice = "(None)";
    
    public IEnumerable<string> DevicesNames => DSHelper.GetDevicesName().Append(NameOfNoneDevice);

    public string SelectedDiviceName { get; private set; } = NameOfNoneDevice;

    public DsDevice GetDeviceByName(string name)
    {
      var selectedDevice = DevicesNames.Zip(_dsDevices, (deviceName, device) => (deviceName, device))
        .FirstOrDefault(x => x.deviceName == name);
      SelectedDiviceName = string.IsNullOrEmpty(selectedDevice.deviceName) ? NameOfNoneDevice : selectedDevice.deviceName;
      return selectedDevice.device;
    }

    private DsDevice[] _dsDevices => DSHelper.GetDevices();
  }
}
