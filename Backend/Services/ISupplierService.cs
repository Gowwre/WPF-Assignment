using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Services;

public interface ISupplierService
{
    Task<List<Supplier>> GetSuppliers();
}