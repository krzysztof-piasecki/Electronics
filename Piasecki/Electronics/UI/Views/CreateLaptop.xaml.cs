using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki.Electronics.UI.Views;

public partial class CreateLaptop : Window
{
    public LaptopViewModel LaptopViewModel { get; set; }
    private LaptopService _laptopService;

    public CreateLaptop(LaptopService laptopService)
    {
        InitializeComponent();
        _laptopService = laptopService;

        LaptopViewModel = new LaptopViewModel();

        DataContext = LaptopViewModel;
    }

    public CreateLaptop(LaptopViewModel laptopViewModel, LaptopService laptopService)
    {
        InitializeComponent();
        _laptopService = laptopService;
        LaptopViewModel = laptopViewModel;

        DataContext = LaptopViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        if (LaptopViewModel.Id is null)
        {
            await _laptopService.AddLaptopAsync(LaptopViewModel);
            MessageBox.Show("Nowy laptop zapisany!");
        }
        else
        {
            await _laptopService.UpdateLaptopAsync(LaptopViewModel);
            MessageBox.Show("Laptop zaktualizowany!");
        }
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}