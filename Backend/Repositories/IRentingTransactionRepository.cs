using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories {
    public interface IRentingTransactionRepository {
        Task<List<RentingTransaction>> GetAllRentingTransactions();
        Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string email);
        Task<List<RentingDetail>> GetRentingDetails();
        Task<List<RentingTransaction>> GetRentingTransactions();
    }
}