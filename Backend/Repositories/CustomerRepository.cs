using Backend.DAO;
using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Repositories;

public class CustomerRepository : ICustomerRepository {
    public Task<List<Customer>> GetAllCustomers() {
        var result = CustomerDAO.Instance.GetAllCustomers();
        return result;
    }

    public Customer Login(string email, string password) {
        try {
            Customer result = CustomerDAO.Instance.GetCustomer(email, password);
            return result;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task DeleteCustomer(Customer toBeDeleted) {
        try {
            return CustomerDAO.Instance.DeleteCustomer(toBeDeleted);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task Add(Customer newCustomer) {
        try {
            return CustomerDAO.Instance.AddCustomer(newCustomer);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task Update(Customer toBeUpdated) {
        try {
            return CustomerDAO.Instance.UpdateCustomer(toBeUpdated);
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task<Customer> GetCustomerInfo(string currentUserEmail) {
        try {
            var result = CustomerDAO.Instance.GetOne(currentUserEmail);
            return result;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}