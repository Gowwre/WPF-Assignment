using BusinessObjects.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace UI.ViewModel {
    public partial class CarManagementViewModel : ObservableObject {
        private readonly ICarInformationService _carInformationService;
        private readonly IRentingTransactionService _rentingTransactionService;

        private readonly IWindowManager _windowManager;

        [ObservableProperty] private ObservableCollection<CarInformation> _carInformations;
        [ObservableProperty] private ObservableCollection<Manufacturer> _manufacturers;
        [ObservableProperty] private string _searchText;
        [ObservableProperty] private CarInformation _selectedCarInformation;
        [ObservableProperty] private Manufacturer _selectedManufacturer;
        [ObservableProperty] private Supplier _selectedSupplier;
        [ObservableProperty] private ObservableCollection<Supplier> _suppliers;

        public CarManagementViewModel(ICarInformationService carInformationService, IWindowManager windowManager,
            IRentingTransactionService rentingTransactionService) {
            _carInformationService = carInformationService;
            _rentingTransactionService = rentingTransactionService;
            CarInformations = new ObservableCollection<CarInformation>();
            _ = GetCarInformation();
            _windowManager = windowManager;
        }


        [RelayCommand]
        public async Task GetCarInformation() {
            List<CarInformation> cars = await _carInformationService.GetAllCarInformation();
            CarInformations.Clear();
            foreach (CarInformation item in cars) {
                CarInformations.Add(item);
            }
        }

        [RelayCommand]
        public void ShowCarForm() {
            _windowManager.ShowCarInformationForm();
        }

        [RelayCommand]
        public void ShowCarEditForm() {
            _windowManager.ShowCarInformationEditForm(SelectedCarInformation);
        }

        [RelayCommand]
        public void AddCar() {
            _windowManager.ShowCarInformationForm();
        }

        [RelayCommand]
        public void EditCar() {
            _windowManager.ShowCarInformationForm();
        }

        [RelayCommand]
        public async Task DeleteCar() {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this car?", "Confirmation",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No) {
                return;
            }

            List<RentingDetail> rentingDetails = await _rentingTransactionService.GetRentingDetails();
            bool isRented = rentingDetails.Any(x => x.CarId == SelectedCarInformation.CarId);

            if (isRented) {
                SelectedCarInformation.CarStatus = 0;
                await _carInformationService.UpdateCarInformation(SelectedCarInformation);
            } else {
                await _carInformationService.DeleteCarInformation(SelectedCarInformation);
            }

            await GetCarInformation();
        }

        [RelayCommand]
        public async Task SearchCarInformation() {
            List<CarInformation> result = await _carInformationService.GetCarInformationByName(SearchText);
            CarInformations.Clear();
            foreach (CarInformation item in result) {
                CarInformations.Add(item);
            }
        }
    }
}