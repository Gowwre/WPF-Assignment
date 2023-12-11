using BusinessObjects.Entities;
using DataAccess.DAO;

namespace DataAccess.Repositories {
    public class RentingTransactionRepository : IRentingTransactionRepository {
        public Task<List<RentingTransaction>> GetAllRentingTransactions() {
            try {
                Task<List<RentingTransaction>> result = RentingTransactionDAO.Instance.GetAllRentingTransactions();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string email) {
            try {
                Task<List<RentingTransaction>> result =
                    RentingTransactionDAO.Instance.GetRentingTransactionsByCustomerEmail(email);
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingDetail>> GetRentingDetails() {
            try {
                Task<List<RentingDetail>> result = RentingTransactionDAO.Instance.GetRentingDetails();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<RentingTransaction>> GetRentingTransactions() {
            try {
                Task<List<RentingTransaction>> result = RentingTransactionDAO.Instance.GetRentingTransactions();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}