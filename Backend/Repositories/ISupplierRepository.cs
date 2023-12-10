using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories;

public interface ISupplierRepository
{
    Task<List<Supplier>> GetAllSuppliers();
}
