
using Backend.Entities;
using BusinessObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.DAO;

public class ManufacturerDAO
{
    private static ManufacturerDAO? instance;
    private static readonly object padlock = new object();

    private ManufacturerDAO() { }
    public static ManufacturerDAO Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                { instance = new ManufacturerDAO(); }
            }
            return instance;
        }
    }

    public Task<List<Manufacturer>> GetAllManufacturers()
    {
        var dbContext = new FucarRentingManagementContext();
        try
        {
            var result = dbContext.Manufacturers.ToListAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public Task<Manufacturer> GetManufacturer(string name)
    {
        var dbContext = new FucarRentingManagementContext();
        try
        {
            var result = dbContext.Manufacturers.Where(m => m.ManufacturerName == name).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
