using Backend.Entities;
using Backend.Repositories;
using BusinessObjects.Entities;

namespace Backend.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;

    public ManufacturerService(IManufacturerRepository manufacturerRepository) => this._manufacturerRepository = manufacturerRepository;

    public Task<List<Manufacturer>> GetManufacturers() => this._manufacturerRepository.GetAllManufacturers();
}
