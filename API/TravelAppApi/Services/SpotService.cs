using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TravelAppApi.Models;

namespace TravelAppApi.Services
{
    public class SpotService
    {
        private readonly IMongoCollection<Spot> _spotsCollection;

        public SpotService(IOptions<SpotDatabaseSettings> spotDbSettings)
        {
            var mongoClient = new MongoClient(spotDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(spotDbSettings.Value.DatabaseName);
            _spotsCollection = mongoDatabase.GetCollection<Spot>(spotDbSettings.Value.CollectionName);
        }

        public async Task<List<Spot>> GetAllSpots()
        {
            List<Spot> spots = await _spotsCollection.Find(_ => true).ToListAsync();

            if(spots == null)
            {
                return new List<Spot>();
            }
            return spots;
        }

        public async Task<Spot> GetSpotById(string id)
        {
            //id should be unique. so singleordefault throws exeption if more than
            //one spot is found
            return await _spotsCollection.Find(spot => spot.Id == id).SingleOrDefaultAsync();
        }

        public async Task<Spot> GetSpotByName(string name)
        {
            //there are no two spots with same name. so singleordefault throws exeption if more than
            //one spot is found
            name = name.ToLower();
            return await _spotsCollection.Find(spot => spot.Name.ToLower() == name).SingleOrDefaultAsync();
        }

        public async Task<List<Spot>> GetSpotByDistrict(string district)
        {
            district = district.ToLower();
            List<Spot> spots = await _spotsCollection.Find(spot => spot.District.ToLower() == district).ToListAsync();

            if(spots == null)
            {
                return new List<Spot>();
            }
            return spots;
        }

        public async Task<List<Spot>> GetSpotByCategory(string category)
        {
            category = category.ToLower();
            List<Spot> spots = await _spotsCollection.Find(spot => spot.Category.ToLower() == category).ToListAsync();

            if (spots == null)
            {
                return new List<Spot>();
            }
            return spots;
        }

        public async Task AddSpot(Spot newSpot)
        {
            await _spotsCollection.InsertOneAsync(newSpot);
        }

        public async Task EditSpot(string id, Spot editedSpot)
        {
            await _spotsCollection.ReplaceOneAsync(spot => spot.Id == id, editedSpot);
        }

        public async Task RemoveSpot(string id)
        {
            await _spotsCollection.DeleteOneAsync(spot => spot.Id == id);
        }

    }
}
