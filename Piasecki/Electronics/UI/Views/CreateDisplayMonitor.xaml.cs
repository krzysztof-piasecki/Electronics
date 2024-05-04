using System.Windows;
using System.Windows.Input;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;

namespace Piasecki.Electronics.UI.Views;

public partial class CreateDisplayMonitor : Window
{
    private DisplayMonitor _displayMonitor;
    private DisplayMonitorService _displayMonitorService;

    public CreateDisplayMonitor(DisplayMonitorService displayMonitorService)
    {
        InitializeComponent();
        _displayMonitorService = displayMonitorService;
        _displayMonitor = new DisplayMonitor(); 
    }

    public CreateDisplayMonitor(DisplayMonitor displayMonitor, DisplayMonitorService displayMonitorService)
    {
        InitializeComponent();
        _displayMonitorService = displayMonitorService;
        _displayMonitor = displayMonitor;
        LoadDisplayMonitorData();
    }

    private void LoadDisplayMonitorData()
    {
        TextBoxName.Text = _displayMonitor.Name;
        TextBoxPrice.Text = _displayMonitor.Price.ToString();
        TextBoxDiagonal.Text = _displayMonitor.Diagonal.ToString();
    }

    private async void BtnSaveClick(object sender, RoutedEventArgs e)
    {
        _displayMonitor.Name = TextBoxName.Text;

        if (!decimal.TryParse(TextBoxPrice.Text, out decimal price))
        {
            MessageBox.Show("Podaj poprawną cenę w formacie liczbowym.");
            return;
        }
        if (!decimal.TryParse(TextBoxPrice.Text, out decimal diagonal))
        {
            MessageBox.Show("Podaj poprawną przekątną w formacie liczbowym.");
            return;
        }
        _displayMonitor.Diagonal = diagonal;

        if (_displayMonitor.Id == Guid.Empty)
        {
            await _displayMonitorService.AddDisplayMonitorAsync(_displayMonitor);
            MessageBox.Show("Nowy monitor zapisany!");
        }
        else
        {
            await _displayMonitorService.UpdateDisplayMonitorAsync(_displayMonitor); 
            MessageBox.Show("Monitor zaktualizowany!");
        }
    }
    private void BtnBackClick(object sender, RoutedEventArgs e)
    {
        this.Close();
        Application.Current.MainWindow?.Show();
    }
}
