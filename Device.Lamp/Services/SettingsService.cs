using System.IO;
using System.Text.Json;
using Device.Lamp.Models;

namespace Device.Lamp.Services;

public static class SettingsService
{
    private static readonly string FilePath = "settings.json";

    public static AppSettings LoadSettings()
    {
        if (!File.Exists(FilePath))
        {
            return new AppSettings
            {
                ConnectionString = "HostName=demi-iothub.azure-devices.net;DeviceId=Lampa;SharedAccessKey=jPtXcMaqrplU2ftWCy3lJ9vETGhxy5AxXuvZpToVIXc=",
                DeviceId = "Lampa"
            };
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
    }


    public static void SaveSettings(AppSettings settings)
    {
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}
