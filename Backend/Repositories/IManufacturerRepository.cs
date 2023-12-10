using Backend.DAO;
using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories;

public interface IManufacturerRepository
{
    Task<List<Manufacturer>> GetAllManufacturers() => ManufacturerDAO.Instance.GetAllManufacturers();
}