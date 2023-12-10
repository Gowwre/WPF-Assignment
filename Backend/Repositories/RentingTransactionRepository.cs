using Backend.DAO;
using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories {
    public class RentingTransactionRepository : IRentingTransactionRepository {
        public Task<List<RentingTransaction>> GetAllRentingTransactions() {
            try {
                var result = RentingTransactionDAO.Instance.GetAllRentingTransactions();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string email) {
            try {
                var result = RentingTransactionDAO.Instance.GetRentingTransactionsByCustomerEmail(email);
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingDetail>> GetRentingDetails() {
            try {
                var result = RentingTransactionDAO.Instance.GetRentingDetails();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactions() {
            try {
                var result = RentingTransactionDAO.Instance.GetRentingTransactions();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
        
    }
}