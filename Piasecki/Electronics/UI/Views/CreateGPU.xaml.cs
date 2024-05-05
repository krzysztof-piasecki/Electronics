using System.Windows;
using Piasecki.Electronics.BL;
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

    public CreateGPU(GPUViewModel gpuViewModel, GPUService gpuService)
    {
        InitializeComponent();
        _gpuService = gpuService;
        GPUViewModel = gpuViewModel;

        DataContext = GPUViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
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
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}