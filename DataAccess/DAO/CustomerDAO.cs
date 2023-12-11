using BusinessObjects.Entities;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO {
    public class CustomerDAO {
        private static CustomerDAO? instance;
        private static readonly object padlock = new();

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
            FucarRentingManagementContext dbContext = new();
            try {
                Customer? result = dbContext.Customers.Where(c => c.Email == email && c.Password == password)
                    .FirstOrDefault();
                return result;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Task<List<Customer>> GetAllCustomers() {
            FucarRentingManagementContext dbContext = new();
            try {
                Task<List<Customer>> result = dbContext.Customers.ToListAsync();
                return result;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Task DeleteCustomer(Customer toBeDeleted) {
            FucarRentingManagementContext dbContext = new();
            try {
                dbContext.Customers.Remove(toBeDeleted);
                return dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task AddCustomer(Customer newCustomer) {
            FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
            try {
                dbContext.Customers.Add(newCustomer);
                return dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task UpdateCustomer(Customer customer) {
            FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
            try {
                dbContext.Customers.Update(customer);
                return dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<Customer> GetOne(string currentUserEmail) {
            FucarRentingManagementContext dbContext = new FucarRentingManagementContext();
            try {
                Task<Customer?> result = dbContext.Customers.Where(c => c.Email == currentUserEmail)
                    .FirstOrDefaultAsync();
                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}