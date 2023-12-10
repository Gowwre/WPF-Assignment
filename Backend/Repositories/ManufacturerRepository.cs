using Backend.DAO;
using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories;

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
