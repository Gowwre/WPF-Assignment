using BusinessObjects.Entities;

namespace UI.ViewModel;


using System.Collections.ObjectModel;
using System.Windows;
using DataAccess.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class CarFormViewModel : ObservableObject
{

    private readonly ISupplierService _supplierService;
    private readonly IManufacturerService _manufacturerService;
    private readonly ICarInformationService _carInformationService;
    private readonly IWindowManager _windowManager;

    public CarFormViewModel(ISupplierService supplierService, IManufacturerService manufacturerService, ICarInformationService carInformationService, IWindowManager windowManager)
    {

        this._supplierService = supplierService;
        this._manufacturerService = manufacturerService;
        this._carInformationService = carInformationService;
        this._windowManager = windowManager;

        this.Suppliers = new ObservableCollection<Supplier>();
        this.Manufacturers = new ObservableCollection<Manufacturer>();


        this.GetSupplierList();
        this.GetManufacturerList();
    }

    [ObservableProperty]
    private CarInformation _carInformation = new CarInformation();
    [ObservableProperty]
    private ObservableCollection<Supplier> _suppliers;
    [ObservableProperty]
    private ObservableCollection<Manufacturer> _manufacturers;
    [ObservableProperty]
    private Supplier _selectedSupplier = new Supplier();
    [ObservableProperty]
    private Manufacturer _selectedManufacturer = new Manufacturer();

    public bool IsEdit { get; set; } = false;

    [RelayCommand]
    public async Task SaveCarAsync()
    {

        if (this.IsValid(this.CarInformation) == false)
        {
            MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK);
            return;
        }

        if (this.IsEdit == false)
        {
            var input = this.CarInformation;
            input.ManufacturerId = this.SelectedManufacturer.ManufacturerId;
            input.SupplierId = this.SelectedSupplier.SupplierId;

            input.CarStatus = 1;
            await this._carInformationService.AddCarInformation(input);
        }
        else
        {
            var input = this.CarInformation;
            input.ManufacturerId = this.SelectedManufacturer.ManufacturerId;
            input.SupplierId = this.SelectedSupplier.SupplierId;
            input.Supplier = null;
            input.Manufacturer = null;
            await this._carInformationService.UpdateCarInformation(input);
        }
        this._windowManager.CloseCarInformationForm();
        this._windowManager.RefreshCarManagementWindow();
    }

    public async void GetSupplierList()
    {

        var result = await this._supplierService.GetSuppliers();
        this.Suppliers.Clear();
        foreach (var item in result)
        {
            this.Suppliers.Add(item);
        }
    }

    public async void GetManufacturerList()
    {
        var result = await this._manufacturerService.GetManufacturers();
        this.Manufacturers.Clear();
        foreach (var item in result)
        {
            this.Manufacturers.Add(item);
        }
    }

    private bool IsValid(object input)
    {
        var properties = input.GetType().GetProperties();
        foreach (var property in properties)
        {
            if (property.GetValue(input) == null)
            {
                return false;
            }
        }
        return true;
    }

}
