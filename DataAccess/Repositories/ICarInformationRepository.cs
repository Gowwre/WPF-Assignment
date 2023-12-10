using DataAccess.Entities;
using BusinessObjects.Entities;

namespace DataAccess.Repositories;

public interface ICarInformationRepository
{
    Task<List<CarInformation>> GetAll();
    Task AddCarInformation(CarInformation carInformation);
    Task UpdateCarInformation(CarInformation carInformation);
    Task<CarInformation> Find(int carId);
    Task DeleteCarInformation(CarInformation carInformation);
    Task<List<CarInformation>> GetCarInformationByName(string name);
}