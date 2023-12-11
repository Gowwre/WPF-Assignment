using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories {
    public class SupplierRepository : ISupplierRepository {
        public Task<List<Supplier>> GetAllSuppliers() {
            try {
                return SupplierDAO.Instance.GetAllSuppliers();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}