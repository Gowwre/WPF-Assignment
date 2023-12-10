using BusinessObjects.Entities;

namespace Backend.Services {
    public interface IRentingTransactionService {
        Task<List<RentingTransaction>> GetTransactionsByCustomerEmail(string customerEmail);
        Task<List<RentingDetail>> GetRentingDetails();
        Task<List<RentingTransaction>> GetRentingTransactions();
    }
}