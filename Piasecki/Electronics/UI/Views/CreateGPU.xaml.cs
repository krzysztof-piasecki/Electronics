using System.Windows;
using System.Windows.Input;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;

namespace Piasecki.Electronics.UI.Views;

public partial class CreateGPU : Window
{
    private GPU _gpu;
    private GPUService _gpuService;

    public CreateGPU(GPUService gpuService)
    {
        InitializeComponent();
        _gpuService = gpuService;
        _gpu = new GPU(); 
    }

    public CreateGPU(GPU gpu, GPUService gpuService)
    {
        InitializeComponent();
        _gpuService = gpuService;
        _gpu = gpu;
        LoadGPUData();
    }

    private void LoadGPUData()
    {
        TextBoxName.Text = _gpu.Name;
        TextBoxPrice.Text = _gpu.Price.ToString();
        TextBoxVram.Text = _gpu.VRam;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        _gpu.Name = TextBoxName.Text;
        _gpu.VRam = TextBoxVram.Text;

        if (!decimal.TryParse(TextBoxPrice.Text, out decimal price))
        {
            MessageBox.Show("Podaj poprawną cenę w formacie liczbowym.");
            return;
        }
        _gpu.Price = price;

        if (_gpu.Id == Guid.Empty)
        {
            await _gpuService.AddGPUAsync(_gpu);
            MessageBox.Show("Nowy GPU zapisany!");
        }
        else
        {
            await _gpuService.UpdateGPUAsync(_gpu); 
            MessageBox.Show("GPU zaktualizowany!");
        }
    }
    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}
