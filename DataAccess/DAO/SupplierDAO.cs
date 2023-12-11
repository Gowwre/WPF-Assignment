using BusinessObjects.Entities;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO {
    public class SupplierDAO {
        private static SupplierDAO? instance;
        private static readonly object padlock = new();

        private SupplierDAO() { }

        public static SupplierDAO Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new SupplierDAO();
                    }
                }

                return instance;
            }
        }

        public Task<List<Supplier>> GetAllSuppliers() {
            FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
            try {
                Task<List<Supplier>> result = dbContext.Suppliers.ToListAsync();
                return result;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}