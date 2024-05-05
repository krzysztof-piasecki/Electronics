using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki.Electronics.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProductViewModel> _items;
        private ObservableCollection<ProductViewModel> _filteredItems;

        public ObservableCollection<ProductViewModel> Items
        {
            get => _items;
            set => SetField(ref _items, value);
        }

        public ObservableCollection<ProductViewModel> FilteredItems
        {
            get => _filteredItems;
            set => SetField(ref _filteredItems, value);
        }

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<ProductViewModel>();
            FilteredItems = new ObservableCollection<ProductViewModel>(); // Inicjalizacja FilteredItems
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void FilterProductsByType(string type)
        {
            FilteredItems.Clear();

            var filtered = type == "All"
                ? Items
                : Items.Where(p => p.Type.ToString().Equals(type, StringComparison.OrdinalIgnoreCase));

            foreach (var item in filtered)
            {
                FilteredItems.Add(item);
            }
        }
    }
}