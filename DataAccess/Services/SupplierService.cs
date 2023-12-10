using DataAccess.Entities;
using BusinessObjects.Entities;
using DataAccess.Repositories;

namespace DataAccess.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    public SupplierService(ISupplierRepository supplierRepository) => this._supplierRepository = supplierRepository;

    public Task<List<Supplier>> GetSuppliers() => this._supplierRepository.GetAllSuppliers();
}
