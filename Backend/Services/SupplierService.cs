using Backend.Entities;
using Backend.Repositories;
using BusinessObjects.Entities;

namespace Backend.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    public SupplierService(ISupplierRepository supplierRepository) => this._supplierRepository = supplierRepository;

    public Task<List<Supplier>> GetSuppliers() => this._supplierRepository.GetAllSuppliers();
}
