using DataAccess.Entities;
using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    public Task<List<Manufacturer>> GetAllManufacturers()
    {
        try
        {
            return ManufacturerDAO.Instance.GetAllManufacturers();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
