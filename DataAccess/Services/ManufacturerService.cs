using DataAccess.Entities;
using BusinessObjects.Entities;
using DataAccess.Repositories;

namespace DataAccess.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerService(IManufacturerRepository manufacturerRepository) => this._manufacturerRepository = manufacturerRepository;

    public Task<List<Manufacturer>> GetManufacturers() => this._manufacturerRepository.GetAllManufacturers();
}
