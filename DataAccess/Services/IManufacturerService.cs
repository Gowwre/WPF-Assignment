using BusinessObjects.Entities;

namespace DataAccess.Services {
    public interface IManufacturerService {
        Task<List<Manufacturer>> GetManufacturers();
    }
}