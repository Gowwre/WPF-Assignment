using DataAccess.Entities;
using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories;

public interface IManufacturerRepository
{
    Task<List<Manufacturer>> GetAllManufacturers() => ManufacturerDAO.Instance.GetAllManufacturers();
}