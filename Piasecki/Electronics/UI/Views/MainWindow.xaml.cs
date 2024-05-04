using System;
using System.Windows;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.MODEL;
using Piasecki.Electronics.DAO.REPOSITORIES;
using Piasecki.Electronics.UI.Views;

namespace Piasecki;
public partial class MainWindow : Window
{
    private readonly ProductService _productService;
    private readonly PhoneService _phoneService;
    private readonly LaptopService _laptopService;
    private readonly GPUService _gpuService;
    private readonly DisplayMonitorService _displayMonitorService;

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

        LoadProducts();
    }

    private async void LoadProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        foreach (var product in products)
        {
            LvEntries.Items.Add(product);
        }
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

    private void BtnEditClick(object sender, RoutedEventArgs e)
    {
        if (LvEntries.SelectedItem is Phone phone)
        {
            var editPhone = new CreatePhone(phone, _phoneService);
            editPhone.Show();
        }
        else if (LvEntries.SelectedItem is Laptop laptop)
        {
            var editLaptop = new CreateLaptop(laptop, _laptopService);
            editLaptop.Show();
        }
        else if (LvEntries.SelectedItem is GPU gpu)
        {
            var editGPU = new CreateGPU(gpu, _gpuService);
            editGPU.Show();
        }
        else if (LvEntries.SelectedItem is DisplayMonitor displayMonitor)
        {
            var editDisplayMonitor = new CreateDisplayMonitor(displayMonitor, _displayMonitorService);
            editDisplayMonitor.Show();
        }
    }


    private async void BtnDeleteClick(object sender, RoutedEventArgs e)
    {
        if (LvEntries.SelectedItem is Phone phone)
        {
            await _phoneService.DeletePhoneAsync(phone);
            MessageBox.Show("Telefon został usunięty!");
        }
        if (LvEntries.SelectedItem is DisplayMonitor displayMonitor)
        {
            await _displayMonitorService.DeleteDisplayMonitorAsync(displayMonitor);
            MessageBox.Show("Monitor został usunięty!");
        }
        if (LvEntries.SelectedItem is GPU gpu)
        {
            await _gpuService.DeleteGPUAsync(gpu);
            MessageBox.Show("GPU został usunięty!");
        }
        if (LvEntries.SelectedItem is Laptop laptop)
        {
            await _laptopService.DeleteLaptopAsync(laptop);
            MessageBox.Show("Laptop został usunięty!");
        }
    }
}
