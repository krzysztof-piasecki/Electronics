using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.UI.ViewModels;
using Piasecki.Electronics.UI.Views;
using Piasecki.Electronics.UI.ViewsModels;

namespace Piasecki
{
    public partial class MainWindow : Window
    {
        private readonly ProductService _productService;
        private readonly PhoneService _phoneService;
        private readonly LaptopService _laptopService;
        private readonly GPUService _gpuService;
        private readonly DisplayMonitorService _displayMonitorService;
        private MainWindowViewModel _viewModel;

        public MainWindow(ProductService productService, PhoneService phoneService,
            LaptopService laptopService, GPUService gpuService,
            DisplayMonitorService displayMonitorService)
        {
            InitializeComponent();
            _productService = productService;
            _phoneService = phoneService;
            _laptopService = laptopService;
            _gpuService = gpuService;
            _displayMonitorService = displayMonitorService;
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            this.Activated += async (sender, e) => await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            _viewModel.FilteredItems.Clear();
            foreach (var product in products)
            {
                _viewModel.FilteredItems.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type
                });
                _viewModel.Items.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Type = product.Type
                });
            }
            AdjustColumnWidths();
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            string searchQuery = SearchBox.Text.ToLower();
            var filteredProducts = _viewModel.FilteredItems
                .Where(product => product.Name.ToLower().Contains(searchQuery));

            _viewModel.FilteredItems = new ObservableCollection<ProductViewModel>(filteredProducts);
        }

        private void BtnAddPhoneClick(object sender, RoutedEventArgs e)
        {
            var createPhone = new CreatePhone(_phoneService);
            createPhone.Show();
        }

        private void BtnAddLaptopClick(object sender, RoutedEventArgs e)
        {
            var createLaptop = new CreateLaptop(_laptopService);
            createLaptop.Show();
        }

        private void BtnAddGPUClick(object sender, RoutedEventArgs e)
        {
            var createGPU = new CreateGPU(_gpuService);
            createGPU.Show();
        }

        private void BtnAddDisplayMonitorClick(object sender, RoutedEventArgs e)
        {
            var createDisplayMonitor = new CreateDisplayMonitor(_displayMonitorService);
            createDisplayMonitor.Show();
        }

        private async void BtnEditClick(object sender, RoutedEventArgs e)
        {
            if (LvEntries.SelectedItem is ProductViewModel selectedProduct)
            {
                switch (selectedProduct.Type.ToString())
                {
                    case "Phone":
                        var phone = await _phoneService.GetPhoneByGuid(selectedProduct.Id);
                        var editPhone = new CreatePhone(phone,selectedProduct.Name, _phoneService);
                        editPhone.Show();
                        break;
                    case "Laptop":
                        var laptop = await _laptopService.GetLaptopByGuid(selectedProduct.Id);
                        var editLaptop = new CreateLaptop(laptop,selectedProduct.Name, _laptopService);
                        editLaptop.Show();
                        break;
                    case "GPU":
                        var gpu = await _gpuService.GetGPUByGuid(selectedProduct.Id);
                        var editGPU = new CreateGPU(gpu,selectedProduct.Name, _gpuService);
                        editGPU.Show();
                        break;
                    case "DisplayMonitor":
                        var displayMonitor = await _displayMonitorService.GetDisplayMonitorByGuid(selectedProduct.Id);
                        var editDisplayMonitor = new CreateDisplayMonitor(displayMonitor, selectedProduct.Name, _displayMonitorService);
                        editDisplayMonitor.Show();
                        break;
                }
            }
        }


        private async void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            if (LvEntries.SelectedItem is Phone phone)
            {
                await _phoneService.DeletePhoneAsync(phone);
                MessageBox.Show("Telefon został usunięty!");
            }
            else if (LvEntries.SelectedItem is DisplayMonitor displayMonitor)
            {
                await _displayMonitorService.DeleteDisplayMonitorAsync(displayMonitor);
                MessageBox.Show("Monitor został usunięty!");
            }
            else if (LvEntries.SelectedItem is GPU gpu)
            {
                await _gpuService.DeleteGPUAsync(gpu);
                MessageBox.Show("GPU został usunięty!");
            }
            else if (LvEntries.SelectedItem is Laptop laptop)
            {
                await _laptopService.DeleteLaptopAsync(laptop);
                MessageBox.Show("Laptop został usunięty!");
            }
        }
        private void AdjustColumnWidths()
        {
            var gridView = LvEntries.View as GridView;
            if (gridView != null && gridView.Columns.Count > 1)
            {
                var totalWidth = LvEntries.ActualWidth - SystemParameters.VerticalScrollBarWidth;
                for (int i = 1; i < gridView.Columns.Count; i++)
                {
                    totalWidth -= gridView.Columns[i].Width;
                }
                gridView.Columns[0].Width = totalWidth > 0 ? totalWidth : 0;
            }
        }
        private void TypeFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypeFilterComboBox == null || TypeFilterComboBox.SelectedItem == null || _viewModel == null) 
                return;
            if (TypeFilterComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                var selectedType = selectedItem.Tag.ToString();
                _viewModel.FilterProductsByType(selectedType);
            }
        }
    }
}