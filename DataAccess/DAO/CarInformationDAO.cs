using BusinessObjects.Entities;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DAO {
    public class CarInformationDAO {
        private static CarInformationDAO? instance;
        private static readonly object Padlock = new();
        private CarInformationDAO() { }

        public static CarInformationDAO Instance {
            get {
                lock (Padlock) {
                    instance ??= new CarInformationDAO();
                    return instance;
                }
            }
        }

        public Task<List<CarInformation>> GetAllCarInformation() {
            FucarRentingManagementContext dbContext = new();
            try {
                Task<List<CarInformation>> result = dbContext.CarInformations.Include(x => x.Manufacturer)
                    .Include(x => x.Supplier).ToListAsync();
                return result;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public Task AddCarInformation(CarInformation carInformation) {
            FucarRentingManagementContext dbContext = new();

            try {
                dbContext.CarInformations.Add(carInformation);
                return dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task UpdateCarInformation(CarInformation carInformation) {
            FucarRentingManagementContext dbContext = new();
            try {
                dbContext.Update(carInformation);
                return dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public async Task<CarInformation> GetCarInformationById(int id) {
            FucarRentingManagementContext dbContext = new();
            try {
                ValueTask<CarInformation?> result = dbContext.CarInformations.FindAsync(id);
                CarInformation? carInformation = await result;
                return carInformation;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task DeleteCarInformation(CarInformation toBeDeleted) {
            FucarRentingManagementContext dbContext = new();
            try {
                dbContext.CarInformations.Remove(toBeDeleted);
                return dbContext.SaveChangesAsync();
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }

        public Task<List<CarInformation>> GetCarInformationByName(string name) {
            FucarRentingManagementContext dbContext = new();
            try {
                string keyword = "%" + name + "%";
                Task<List<CarInformation>> result = dbContext.CarInformations
                    .Where(x => EF.Functions.Like(x.CarName, keyword))
                    .Include(x => x.Supplier)
                    .Include(x => x.Manufacturer)
                    .ToListAsync();

                return result;
            } catch (Exception e) {
                throw new Exception(e.Message);
            }
        }
    }
}