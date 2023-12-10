using Backend.Entities;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAO {
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
            var dbContext = new FucarRentingManagementContext();
            try {
                var result = dbContext.RentingTransactions.ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactionsByCustomerEmail(string email) {
            var dbContext = new FucarRentingManagementContext();
            try {
                var result = dbContext.RentingTransactions
                    .Include(x => x.Customer)
                    .Where(x => x.Customer.Email == email)
                    .ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingDetail>> GetRentingDetails() {
            var dbContext = new FucarRentingManagementContext();
            try {
                var result = dbContext.RentingDetails.ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactions() {
            var dbContext = new FucarRentingManagementContext();
            try {
                var result = dbContext.RentingTransactions.ToListAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}