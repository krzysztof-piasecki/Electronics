using System.ComponentModel;
using System.Runtime.CompilerServices;
using Piasecki.Electronics.INTERFACES;

namespace Piasecki.Electronics.UI.ViewsModels;

public class LaptopViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string name;

    public string Name
    {
        get { return name; }
        set { SetField(ref name, value); }
    }

    private decimal price;

    public decimal Price
    {
        get { return price; }
        set { SetField(ref price, value); }
    }

    private string gpu;

    public string GPU
    {
        get { return gpu; }
        set { SetField(ref gpu, value); }
    }

    private string cpu;

    public string CPU
    {
        get { return cpu; }
        set { SetField(ref cpu, value); }
    }

    private ProductBrand brand;

    public ProductBrand Brand
    {
        get { return brand; }
        set { SetField(ref brand, value); }
    }

    private Guid? id;

    public Guid? Id
    {
        get { return id; }
        set { SetField(ref id, value); }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}