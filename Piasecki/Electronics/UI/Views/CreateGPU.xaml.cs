using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki.Electronics.UI.Views;

public partial class CreateGPU : Window
{
    public GPUViewModel GPUViewModel { get; set; }
    private GPUService _gpuService;

    public CreateGPU(GPUService gpuService)
    {
        InitializeComponent();
        _gpuService = gpuService;

        GPUViewModel = new GPUViewModel();

        DataContext = GPUViewModel;
    }

    public CreateGPU(GPU gpu, string name, GPUService gpuService)
    {
        InitializeComponent();
        _gpuService = gpuService;
        GPUViewModel = new GPUViewModel()
        {
            VRam = gpu.VRam,
            Id = gpu.Id,
            Price = gpu.Price,
            Name = name
        };

        DataContext = GPUViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(GPUViewModel.Name) ||
            GPUViewModel.Price < 0 || 
            string.IsNullOrWhiteSpace(GPUViewModel.VRam))
        {
            MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (GPUViewModel.Id is null)
        {
            await _gpuService.AddGPUAsync(GPUViewModel);
            MessageBox.Show("Nowy GPU zapisany!");
        }
        else
        {
            await _gpuService.UpdateGPUAsync(GPUViewModel);
            MessageBox.Show("GPU zaktualizowany!");
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