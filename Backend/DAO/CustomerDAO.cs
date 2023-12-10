
using Backend.Entities;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAO;

public class CustomerDAO {
    private static CustomerDAO? instance;
    private static readonly object padlock = new object();

    private CustomerDAO() { }
    public static CustomerDAO Instance {
        get {
            lock (padlock) {
                if (instance == null) {
                    instance = new CustomerDAO();
                }
                return instance;
            }
        }
    }

    public Customer GetCustomer(string email, string password) {
        FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
        try {
            Customer? result = dbContext.Customers.Where(c => c.Email == email && c.Password == password).FirstOrDefault();
            return result;
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }
    }

    public Task<List<Customer>> GetAllCustomers() {
        FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
        try {
            Task<List<Customer>> result = dbContext.Customers.ToListAsync();
            return result;
        } catch (Exception ex) {
            throw new Exception(ex.Message);
        }


    }

    public Task DeleteCustomer(Customer toBeDeleted) {
        FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
        try {
            dbContext.Customers.Remove(toBeDeleted);
            return dbContext.SaveChangesAsync();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }

    public Task AddCustomer(Customer newCustomer) {
        var dbContext = new FucarRentingManagementContext();
        try {
            dbContext.Customers.Add(newCustomer);
            return dbContext.SaveChangesAsync();
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    } 
    
    public Task UpdateCustomer(Customer customer) {
        var dbContext = new FucarRentingManagementContext();
        try {
            dbContext.Customers.Update(customer);
            return dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<Customer> GetOne(string currentUserEmail) {
        var dbContext = new FucarRentingManagementContext();
        try {
            var result = dbContext.Customers.Where(c => c.Email == currentUserEmail).FirstOrDefaultAsync();
            return result;
        } catch (Exception e) {
            throw new Exception(e.Message);
        }
    }
}
