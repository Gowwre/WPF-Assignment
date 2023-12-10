using Backend.Entities;
using BusinessObjects.Entities;

namespace Backend.Services;

public interface IManufacturerService
{
    Task<List<Manufacturer>> GetManufacturers();
}