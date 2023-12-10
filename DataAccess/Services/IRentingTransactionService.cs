using BusinessObjects.Entities;

namespace DataAccess.Services {
    public interface IRentingTransactionService {
        Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string customerEmail);
        Task<List<RentingDetail>> GetRentingDetails();
        Task<List<RentingTransaction>> GetRentingTransactions();
    }
}