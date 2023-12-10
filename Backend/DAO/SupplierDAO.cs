
using Backend.Entities;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAO;

public class SupplierDAO
{
    private static SupplierDAO? instance = null;
    private static readonly object padlock = new object();

    private SupplierDAO() { }
    public static SupplierDAO Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                    instance = new SupplierDAO();
            }
            return instance;
        }
    }

    public Task<List<Supplier>> GetAllSuppliers()
    {
        var dbContext = new FucarRentingManagementContext();
        try
        {
            var result = dbContext.Suppliers.ToListAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
