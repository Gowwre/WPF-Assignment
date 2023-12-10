using Backend.DAO;
using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories;

public class SupplierRepository : ISupplierRepository
{
    public Task<List<Supplier>> GetAllSuppliers()
    {
        try
        {
            return SupplierDAO.Instance.GetAllSuppliers();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
