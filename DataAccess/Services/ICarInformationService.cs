using DataAccess.Entities;
using BusinessObjects.Entities;

namespace DataAccess.Services;

public interface ICarInformationService
{
    Task AddCarInformation(CarInformation carInformation);
    Task DeleteCarInformation(CarInformation carInformation);
    Task<CarInformation> Find(int carId);
    Task<List<CarInformation>> GetAllCarInformation();
    Task<List<CarInformation>> GetCarInformationByName(string name);
    Task UpdateCarInformation(CarInformation carInformation);
}
