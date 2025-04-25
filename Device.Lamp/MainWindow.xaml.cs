using Device.Lamp.Views;
using System.Windows;
using System.Windows.Input;

namespace Device.Lamp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ContentRegion.Content = new MainView();
    }

    private void ShowLamp(object sender, RoutedEventArgs e)
    {
        ContentRegion.Content = new MainView();
    }

    private void ShowSettings(object sender, RoutedEventArgs e)
    {
        ContentRegion.Content = new SettingsView();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState == MouseButtonState.Pressed)
        {
            this.DragMove();
        }
    }
}
