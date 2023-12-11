using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Services;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace UI.ViewModel {
    public partial class CarFormViewModel : ObservableObject {
        private readonly ICarInformationService _carInformationService;
        private readonly IManufacturerService _manufacturerService;

        private readonly ISupplierService _supplierService;
        private readonly IWindowManager _windowManager;

        [ObservableProperty] private CarInformation _carInformation = new();

        [ObservableProperty] private ObservableCollection<Manufacturer> _manufacturers;

        [ObservableProperty] private Manufacturer _selectedManufacturer = new();

        [ObservableProperty] private Supplier _selectedSupplier = new();

        [ObservableProperty] private ObservableCollection<Supplier> _suppliers;

        public CarFormViewModel(ISupplierService supplierService, IManufacturerService manufacturerService,
            ICarInformationService carInformationService, IWindowManager windowManager) {
            _supplierService = supplierService;
            _manufacturerService = manufacturerService;
            _carInformationService = carInformationService;
            _windowManager = windowManager;

            Suppliers = new ObservableCollection<Supplier>();
            Manufacturers = new ObservableCollection<Manufacturer>();


            GetSupplierList();
            GetManufacturerList();
        }

        public bool IsEdit { get; set; } = false;

        [RelayCommand]
        public async Task SaveCarAsync() {
            if (IsValid(CarInformation) == false) {
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK);
                return;
            }

            if (IsEdit == false) {
                CarInformation input = CarInformation;
                input.ManufacturerId = SelectedManufacturer.ManufacturerId;
                input.SupplierId = SelectedSupplier.SupplierId;

                input.CarStatus = 1;
                await _carInformationService.AddCarInformation(input);
            } else {
                CarInformation input = CarInformation;
                input.ManufacturerId = SelectedManufacturer.ManufacturerId;
                input.SupplierId = SelectedSupplier.SupplierId;
                input.Supplier = null;
                input.Manufacturer = null;
                await _carInformationService.UpdateCarInformation(input);
            }

            _windowManager.CloseCarInformationForm();
            _windowManager.RefreshCarManagementWindow();
        }

        public async void GetSupplierList() {
            List<Supplier> result = await _supplierService.GetSuppliers();
            Suppliers.Clear();
            foreach (Supplier item in result) {
                Suppliers.Add(item);
            }
        }

        public async void GetManufacturerList() {
            List<Manufacturer> result = await _manufacturerService.GetManufacturers();
            Manufacturers.Clear();
            foreach (Manufacturer item in result) {
                Manufacturers.Add(item);
            }
        }

        private bool IsValid(object input) {
            PropertyInfo[] properties = input.GetType().GetProperties();
            foreach (PropertyInfo property in properties) {
                if (property.GetValue(input) == null) {
                    return false;
                }
            }

            return true;
        }
    }
}