using System.ComponentModel;
using System.Runtime.CompilerServices;
using Piasecki.Electronics.DAO.MODEL;

namespace Piasecki.Electronics.UI.ViewsModels;

public class ProductViewModel : INotifyPropertyChanged
{
    private Guid id;

    public Guid Id
    {
        get { return id; }
        set { SetField(ref id, value); }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { SetField(ref name, value); }
    }

    private ProductType type;

    public ProductType Type
    {
        get { return type; }
        set { SetField(ref type, value); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

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