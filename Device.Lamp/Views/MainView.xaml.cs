using Device.Lamp.Services;
using Device.Lamp.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Device.Lamp.Views;

public partial class MainView : UserControl
{
    private MainViewModel viewModel => (MainViewModel)DataContext;

    public MainView()
    {
        InitializeComponent();
        Loaded += async (_, _) =>

        {
            var settings = SettingsService.LoadSettings();
            await viewModel.InitIoTHub(settings.ConnectionString);
            await viewModel.LoadLampStatusFromTwin();

        };

    }

    private async void Toggle_Click(object sender, RoutedEventArgs e)
    {
        await viewModel.ToggleLamp();
    }




}


