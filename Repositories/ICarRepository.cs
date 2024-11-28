using CarRentalSystem.Models;
namespace CarRentalSystem.Repositories
{
//, , , 
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAvailableCars();
        Task<Car> GetCarById(int id);
        Task<Car> AddCar(Car c);
        Task<Car> UpdateCarAvailability(int id);
        Task DeleteCar(int id);


    }
}
