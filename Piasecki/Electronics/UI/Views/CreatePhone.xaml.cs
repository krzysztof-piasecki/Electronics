using System.Windows;
using System.Windows.Input;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;

namespace Piasecki.Electronics.UI.Views;

public partial class CreatePhone : Window
{
    private Phone _phone;
    private PhoneService _phoneService;

    public CreatePhone(PhoneService phoneService)
    {
        InitializeComponent();
        _phoneService = phoneService;
        _phone = new Phone();
    }

    public CreatePhone(Phone phone, PhoneService phoneService)
    {
        InitializeComponent();
        _phoneService = phoneService;
        _phone = phone;
        LoadPhoneData();
    }

    private void LoadPhoneData()
    {
        TextBoxName.Text = _phone.Name;
        TextBoxPrice.Text = _phone.Price.ToString();
        TextBoxCamera.Text = _phone.Camera;
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        _phone.Name = TextBoxName.Text;
        _phone.Camera = TextBoxCamera.Text;

        if (!decimal.TryParse(TextBoxPrice.Text, out decimal price))
        {
            MessageBox.Show("Podaj poprawną cenę w formacie liczbowym.");
            return;
        }

        _phone.Price = price;

        if (_phone.Id == Guid.Empty)
        {
            await _phoneService.AddPhoneAsync(_phone);
            MessageBox.Show("Nowy telefon zapisany!");
        }
        else
        {
            await _phoneService.UpdatePhoneAsync(_phone);
            MessageBox.Show("Telefon zaktualizowany!");
        }
    }

    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}