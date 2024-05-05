using System.Windows;
using Piasecki.Electronics.BL;
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

    public CreatePhone(PhoneViewModel phoneViewModel, PhoneService phoneService)
    {
        InitializeComponent();
        _phoneService = phoneService;
        PhoneViewModel = phoneViewModel;

        DataContext = PhoneViewModel;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
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
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}