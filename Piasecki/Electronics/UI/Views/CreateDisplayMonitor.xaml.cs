using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki.Electronics.UI.Views;

public partial class CreateDisplayMonitor : Window
{
    public DisplayMonitorViewModel DisplayMonitorViewModel { get; set; }
    private DisplayMonitorService _displayMonitorService;

    public CreateDisplayMonitor(DisplayMonitorService displayMonitorService)
    {
        InitializeComponent();
        _displayMonitorService = displayMonitorService;

        DisplayMonitorViewModel = new DisplayMonitorViewModel();

        DataContext = DisplayMonitorViewModel;
    }

    public CreateDisplayMonitor(DisplayMonitorViewModel displayMonitorViewModel,
        DisplayMonitorService displayMonitorService)
    {
        InitializeComponent();
        _displayMonitorService = displayMonitorService;
        DisplayMonitorViewModel = displayMonitorViewModel;

        DataContext = DisplayMonitorViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        if (DisplayMonitorViewModel.Id is null)
        {
            await _displayMonitorService.AddDisplayMonitorAsync(DisplayMonitorViewModel);
            MessageBox.Show("Nowy Monitor zapisany!");
        }
        else
        {
            await _displayMonitorService.UpdateDisplayMonitorAsync(DisplayMonitorViewModel);
            MessageBox.Show("Monitor zaktualizowany!");
        }
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}