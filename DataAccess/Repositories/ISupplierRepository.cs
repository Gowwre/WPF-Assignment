using BusinessObjects.Entities;

namespace DataAccess.Repositories {
    public interface ISupplierRepository {
        Task<List<Supplier>> GetAllSuppliers();
    }
}