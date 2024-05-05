using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;
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

    public CreateLaptop(Laptop laptop,string name, LaptopService laptopService)
    {
        InitializeComponent();
        _laptopService = laptopService;
        LaptopViewModel = new LaptopViewModel()
        {
            Brand = laptop.Brand,
            Name = name,
            Id = laptop.Id,
            GPU = laptop.GPU,
            CPU = laptop.CPU
        };

        DataContext = LaptopViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(LaptopViewModel.Name) ||
            LaptopViewModel.Price < 0 || 
            string.IsNullOrWhiteSpace(LaptopViewModel.CPU) ||
            string.IsNullOrWhiteSpace(LaptopViewModel.GPU)
            )
        {
            MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
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
        this.Close();
        Application.Current.MainWindow?.Show();
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}