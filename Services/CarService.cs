using CarRentalSystem.Models;
using CarRentalSystem.Repositories;

namespace CarRentalSystem.Services
{
    public class CarService : ICarService
    {
        private ICarRepository _carRepo;

        public CarService(ICarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        //CheckCarAvailability of car

        public async Task<bool> CheckCarAvailability(int carId)
        {
            if (carId==0)
            {
                throw new ArgumentException("Car ID cannot be 0.");
            }

            var car = await GetById(carId);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {carId} not found.");
            }
            
            return car.IsAvailable;
        }

        //Rent car
        public async Task<string> RentCar(int carId)
        {
            try
            {
                var status = await CheckCarAvailability(carId);
                if (!status)
                {
                    return $"Car with id {carId} is alredy rented";
                }
                await UpdateAvailability(carId);

                return $"Car with id {carId} is rented successfully";
            }
            catch (KeyNotFoundException e)
            {
                return e.Message;
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }


        //repository functions
        public Task<IEnumerable<Car>> GetAvailable()
        {
            return _carRepo.GetAvailableCars();
        }
        public Task<Car> GetById(int id)
        {
            return _carRepo.GetCarById(id);
        }
        public Task<Car> Add(Car c)
        {
            return _carRepo.AddCar(c);
        }
        public Task<Car> UpdateAvailability(int id)
        {
            return _carRepo.UpdateCarAvailability(id);
        }

        public Task Delete(int carId) 
        {
            return _carRepo.DeleteCar(carId);
        }

    }
}
