using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project1.Models;

namespace Project1.Services
{
    public class CarsService
    {
        private readonly IMongoCollection<Car> _carsCollection;

        public CarsService(
        IOptions<CarItemsDatabaseSettings> carItemsDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                carItemsDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                carItemsDatabaseSettings.Value.DatabaseName);

            _carsCollection = mongoDatabase.GetCollection<Car>(
                carItemsDatabaseSettings.Value.CarsCollectionName);
        }

        public async Task<List<Car>> GetAsync() =>
            await _carsCollection.Find(_ => true).ToListAsync();

        public async Task<List<Car>> GetAsync(string brand) =>
            await _carsCollection.Find(x => x.Brand == brand).ToListAsync();

        public async Task CreateAsync(Car newCar) =>
            await _carsCollection.InsertOneAsync(newCar);

        public async Task UpdateAsync(string id, Car updatedCar) =>
            await _carsCollection.ReplaceOneAsync(x => x.Id == id, updatedCar);

        public async Task RemoveAsync(string id) =>
            await _carsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
