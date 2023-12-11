using BusinessObjects.Entities;

namespace DataAccess.Services {
    public interface ISupplierService {
        Task<List<Supplier>> GetSuppliers();
    }
}