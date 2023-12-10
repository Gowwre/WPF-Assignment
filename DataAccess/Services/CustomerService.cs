using DataAccess.Entities;
using BusinessObjects.Entities;
using DataAccess.Repositories;

namespace DataAccess.Services;

public class CustomerService : ICustomerService {
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository) => this._customerRepository = customerRepository;

    public Task<List<Customer>> GetCustomers() {
        return this._customerRepository.GetAllCustomers();
    }

    public Customer Login(string email, string password) => this._customerRepository.Login(email, password);

    public Task DeleteCustomer(Customer toBeDeleted) {
        try {
            return _customerRepository.DeleteCustomer(toBeDeleted);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task RegisterCustomer(Customer newCustomer) {
        try {
            return _customerRepository.Add(newCustomer);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task EditCustomer(Customer toBeUpdated) {
        try {
            return _customerRepository.Update(toBeUpdated);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task<Customer> GetCustomerInfo(string currentUserEmail) {
        try {
            return _customerRepository.GetCustomerInfo(currentUserEmail);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    
}