using BusinessObjects.Entities;
using DataAccess.Repositories;

namespace DataAccess.Services {
    public class CarInformationService : ICarInformationService {
        private readonly ICarInformationRepository _carInformationRepository;

        public CarInformationService(ICarInformationRepository carInformationRepository) {
            _carInformationRepository = carInformationRepository;
        }

        public Task AddCarInformation(CarInformation carInformation) {
            try {
                return _carInformationRepository.AddCarInformation(carInformation);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<CarInformation> Find(int carId) {
            try {
                return _carInformationRepository.Find(carId);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<CarInformation>> GetAllCarInformation() {
            try {
                return _carInformationRepository.GetAll();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }


        public Task UpdateCarInformation(CarInformation carInformation) {
            try {
                return _carInformationRepository.UpdateCarInformation(carInformation);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task DeleteCarInformation(CarInformation carInformation) {
            try {
                return _carInformationRepository.DeleteCarInformation(carInformation);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<CarInformation>> GetCarInformationByName(string name) {
            try {
                return _carInformationRepository.GetCarInformationByName(name);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}