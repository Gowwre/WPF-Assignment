using BusinessObjects.Entities;
using DataAccess.Repositories;

namespace DataAccess.Services {
    public class SupplierService : ISupplierService {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository) {
            _supplierRepository = supplierRepository;
        }

        public Task<List<Supplier>> GetSuppliers() {
            return _supplierRepository.GetAllSuppliers();
        }
    }
}