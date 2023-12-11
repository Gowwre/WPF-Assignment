using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories {
    public class CarInformationRepository : ICarInformationRepository {
        public Task AddCarInformation(CarInformation carInformation) {
            try {
                return CarInformationDAO.Instance.AddCarInformation(carInformation);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<CarInformation> Find(int carId) {
            try {
                return CarInformationDAO.Instance.GetCarInformationById(carId);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<CarInformation>> GetAll() {
            try {
                Task<List<CarInformation>> result = CarInformationDAO.Instance.GetAllCarInformation();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task UpdateCarInformation(CarInformation carInformation) {
            try {
                return CarInformationDAO.Instance.UpdateCarInformation(carInformation);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task DeleteCarInformation(CarInformation carInformation) {
            try {
                return CarInformationDAO.Instance.DeleteCarInformation(carInformation);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<CarInformation>> GetCarInformationByName(string name) {
            try {
                return CarInformationDAO.Instance.GetCarInformationByName(name);
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}