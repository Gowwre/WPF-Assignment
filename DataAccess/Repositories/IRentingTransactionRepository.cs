using BusinessObjects.Entities;

namespace DataAccess.Repositories {
    public interface IRentingTransactionRepository {
        Task<List<RentingTransaction>> GetAllRentingTransactions();
        Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string email);
        Task<List<RentingDetail>> GetRentingDetails();
        Task<List<RentingTransaction>> GetRentingTransactions();
    }
}