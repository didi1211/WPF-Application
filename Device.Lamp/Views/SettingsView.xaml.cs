using Device.Lamp.ViewModels;
using System.Windows.Controls;


namespace Device.Lamp.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
    }

    private void Spara_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var vm = (SettingsViewModel)DataContext;
        vm.Save();
        
    }

    

}
