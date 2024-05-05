using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;
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

    public CreateDisplayMonitor(DisplayMonitor displayMonitor, string name,
        DisplayMonitorService displayMonitorService)
    {
        InitializeComponent();
        _displayMonitorService = displayMonitorService;
        DisplayMonitorViewModel = new DisplayMonitorViewModel
        {
            Price = displayMonitor.Price,
            Id = displayMonitor.Id,
            Diagonal = displayMonitor.Diagonal,
            Name = name,
        };

        DataContext = DisplayMonitorViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(DisplayMonitorViewModel.Name) ||
            DisplayMonitorViewModel.Price < 0 || 
            DisplayMonitorViewModel.Diagonal < 0 )
        {
            MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
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
        this.Close();
        Application.Current.MainWindow?.Show();
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}