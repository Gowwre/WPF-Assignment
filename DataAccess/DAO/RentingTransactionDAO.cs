using BusinessObjects.Entities;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO {
    public class RentingTransactionDAO {
        private static RentingTransactionDAO? instance;
        private static readonly object Padlock = new();

        private RentingTransactionDAO() { }

        public static RentingTransactionDAO Instance {
            get {
                lock (Padlock) {
                    if (instance == null) {
                        instance = new RentingTransactionDAO();
                    }

                    return instance;
                }
            }
        }

        public Task<List<RentingTransaction>> GetAllRentingTransactions() {
            FucarRentingManagementContext dbContext = new();
            try {
                Task<List<RentingTransaction>> result = dbContext.RentingTransactions.ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactionsByCustomerEmail(string email) {
            FucarRentingManagementContext dbContext = new();
            try {
                Task<List<RentingTransaction>> result = dbContext.RentingTransactions
                    .Include(x => x.Customer)
                    .Where(x => x.Customer.Email == email)
                    .ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingDetail>> GetRentingDetails() {
            FucarRentingManagementContext dbContext = new();
            try {
                Task<List<RentingDetail>> result = dbContext.RentingDetails.ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactions() {
            FucarRentingManagementContext dbContext = new();
            try {
                Task<List<RentingTransaction>> result = dbContext.RentingTransactions.ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}