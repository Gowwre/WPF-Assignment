using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories;

public interface ICustomerRepository
{
    Task Add(Customer newCustomer);
    Task DeleteCustomer(Customer toBeDeleted);
    Task<List<Customer>> GetAllCustomers();
    Customer Login(string email, string password);
    Task Update(Customer toBeUpdated);
    Task<Customer> GetCustomerInfo(string currentUserEmail);
}