using CarRentalSystem.Models;

namespace CarRentalSystem.Services
{
    public interface ICarService
    {
        public Task<IEnumerable<Car>> GetAvailable();
        public Task<Car> GetById(int id);
        public Task<Car> Add(Car c);
        public Task<Car> UpdateAvailability(int id);
        public Task<string> RentCar(int carId);
        public Task Delete(int carId);
    }
}
