using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;

namespace Device.Lamp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private bool isLampOn;
    private DeviceClient? deviceClient;

    public bool IsLampOn
    {
        get => isLampOn;
        set
        {
            if (isLampOn == value) return;
            isLampOn = value;
            OnPropertyChanged();
            _ = ReportToDeviceTwin();
        }
    }

    public async Task InitIoTHub(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString)) return;
        deviceClient = DeviceClient.CreateFromConnectionString(connectionString, TransportType.Mqtt);
        await deviceClient.OpenAsync();
    }

    public async Task ToggleLamp()
    {
        IsLampOn = !IsLampOn;
        await ReportToDeviceTwin();
    }

    private async Task ReportToDeviceTwin()
    {
        if (deviceClient == null) return;

        try
        {
            var reportedProperties = new TwinCollection { ["isLampOn"] = IsLampOn };
            await deviceClient.UpdateReportedPropertiesAsync(reportedProperties);
        }
        catch { }

    }

    public async Task LoadLampStatusFromTwin()
    {
        if (deviceClient == null) return;

        try
        {
            Twin twin = await deviceClient.GetTwinAsync();
            if (twin.Properties.Reported.Contains("isLampOn"))
            {
                isLampOn = twin.Properties.Reported["isLampOn"];
                OnPropertyChanged(nameof(IsLampOn));
            }
        }
        catch { }
       
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null!) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
