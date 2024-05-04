using System.Windows;
using System.Windows.Input;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.UI.Views;

public partial class CreateLaptop : Window
{
    private Laptop _laptop;
    private LaptopService _laptopService;

    public CreateLaptop(LaptopService laptopService)
    {
        InitializeComponent();
        LoadBrandComboBox();
        _laptopService = laptopService;
        _laptop = new Laptop(); 
    }

    public CreateLaptop(Laptop laptop, LaptopService laptopService)
    {
        InitializeComponent();
        LoadBrandComboBox();
        _laptopService = laptopService;
        _laptop = laptop;
        LoadLaptopData();
        
    }

    private void LoadLaptopData()
    {
        TextBoxName.Text = _laptop.Name;
        TextBoxPrice.Text = _laptop.Price.ToString();
        TextBoxCPU.Text = _laptop.CPU;
        TextBoxGPU.Text = _laptop.GPU;
        BrandComboBox.SelectedValue = (int)_laptop.Brand;
    }

    private void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        _laptop.Name = TextBoxName.Text;
        _laptop.GPU = TextBoxGPU.Text;
        _laptop.CPU = TextBoxCPU.Text;

        if (!decimal.TryParse(TextBoxPrice.Text, out decimal price))
        {
            MessageBox.Show("Podaj poprawną cenę w formacie liczbowym.");
            return;
        }
        _laptop.Price = price;

        if (!decimal.TryParse(TextBoxSize.Text, out decimal size))
        {
            MessageBox.Show("Podaj poprawną cenę w formacie liczbowym.");
            return;
        }
        _laptop.Size = size;
        _laptop.Brand = (ProductBrand)BrandComboBox.SelectedValue;
        if (_laptop.Id == Guid.Empty)
        {
            _laptopService.AddLaptopAsync(_laptop);
            MessageBox.Show("Nowy laptop zapisany!");
        }
        else
        {
            _laptopService.UpdateLaptopAsync(_laptop); 
            MessageBox.Show("Laptop zaktualizowany!");
        }
    }
    
    private void LoadBrandComboBox()
    {
        BrandComboBox.ItemsSource = Enum.GetValues(typeof(ProductBrand))
            .Cast<ProductBrand>()
            .Select(p => new { Key = (int)p, Value = p.ToString() })
            .ToList();

        BrandComboBox.SelectedIndex = 0;
    }
    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}
