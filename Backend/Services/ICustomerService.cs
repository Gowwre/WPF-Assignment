﻿using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Services;

public interface ICustomerService
{
    Customer Login(string email, string password);
    Task<List<Customer>> GetCustomers();
    Task DeleteCustomer(Customer toBeDeleted);
    Task RegisterCustomer(Customer newCustomer);
    Task EditCustomer(Customer toBeUpdated);
    Task<Customer> GetCustomerInfo(string currentUserEmail);
}