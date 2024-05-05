using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Piasecki.Electronics.UI.ViewsModels;

public class PhoneViewModel : INotifyPropertyChanged
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

    private string camera;

    public string Camera
    {
        get { return camera; }
        set { SetField(ref camera, value); }
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
    public bool CanSave => !string.IsNullOrWhiteSpace(Name) && Price > 0 && !string.IsNullOrWhiteSpace(Camera);


    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}