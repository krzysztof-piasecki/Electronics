using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki.Electronics.UI.Views;

public partial class CreatePhone : Window
{
    public PhoneViewModel PhoneViewModel { get; set; }
    private PhoneService _phoneService;

    public CreatePhone(PhoneService phoneService)
    {
        InitializeComponent();
        _phoneService = phoneService;

        PhoneViewModel = new PhoneViewModel();
        DataContext = PhoneViewModel;
    }

    public CreatePhone(Phone phone,string name, PhoneService phoneService)
    {
        InitializeComponent();
        _phoneService = phoneService;
        PhoneViewModel = new PhoneViewModel()
        {
            Camera = phone.Camera,
            Id = phone.Id,
            Name = name,
            Price = phone.Price
        };

        DataContext = PhoneViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(PhoneViewModel.Name) ||
            PhoneViewModel.Price < 0 || 
            string.IsNullOrWhiteSpace(PhoneViewModel.Camera))
        {
            MessageBox.Show("Wszystkie pola muszą być wypełnione.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
        if (PhoneViewModel.Id is null)
        {
            await _phoneService.AddPhoneAsync(PhoneViewModel);
            MessageBox.Show("Nowy telefon zapisany!");
        }
        else
        {
            await _phoneService.UpdatePhoneAsync(PhoneViewModel);
            MessageBox.Show("Telefon zaktualizowany!");
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