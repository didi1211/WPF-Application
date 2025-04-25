using Device.Lamp.Models;
using Device.Lamp.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Device.Lamp.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private AppSettings settings;

    public string ConnectionString
    {
        get => settings.ConnectionString;
        set
        {
            settings.ConnectionString = value;
            OnPropertyChanged();
        }
    }

    public string DeviceId
    {
        get => settings.DeviceId;
        set
        {
            settings.DeviceId = value;
            OnPropertyChanged();
        }
    }

    public SettingsViewModel()
    {
        settings = SettingsService.LoadSettings();
    }

    public void Save()
    {
        SettingsService.SaveSettings(settings);
        ConfirmationMessage = "New settings saved";
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }


    private string confirmationMessage;
    public string ConfirmationMessage
    {
        get => confirmationMessage;
        set
        {
            confirmationMessage = value;
            OnPropertyChanged();
        }
    }

}
