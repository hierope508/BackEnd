using RestWithMongo.Model;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace RestWithMongo.DAL
{
    public class DALPartner
    {
        private readonly IMongoCollection<Partner> _partners;

        /// <summary>
        /// Load the databse configurations
        /// </summary>
        /// <param name="settings">Settings object with database parameters</param>
        public DALPartner(DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _partners = database.GetCollection<Partner>("Partners");

            //Creating table unique keys
            var keys = Builders<Partner>.IndexKeys.Ascending("document");
            var options = new CreateIndexOptions() { Unique = true };
            var indexModel = new CreateIndexModel<Partner>(keys, options);
            _ = database.GetCollection<Partner>("Partners").Indexes.CreateOne(indexModel);
        }


        /// <summary>
        /// Get a Partner from the database
        /// </summary>
        /// <param name="id">The Id of the partner</param>
        /// <returns>A Partner</returns>
        public Partner GetPartner(string id)
        {
            return _partners.Find(p => p.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Insert a Partner object in the database
        /// </summary>
        /// <param name="partner">The partner to be created</param>
        /// <returns>A Partner</returns>
        public Partner Insert(Partner partner)
        {
            _partners.InsertOne(partner);
            return partner;
        }

        /// <summary>
        /// Insert a list of Partners in the database
        /// </summary>
        /// <param name="partners">The partners to be created</param>
        /// <returns>A list of Partners</returns>
        public List<Partner> InsertMany(List<Partner> partners)
        {
            _partners.InsertMany(partners);
            return partners;
        }

        /// <summary>
        /// Gets the closest partners based on the longitude and latitude provided
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns>A list of partners</returns>
        public List<Partner> GetClosestPartners(double longitude, double latitude)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var filter = Builders<Partner>.Filter.GeoIntersects("coverageArea", point);

            return _partners.Find(filter).ToList();

        }

        public long GetRowCount()
        {
            return _partners.CountDocuments(p=>true);
        }

        /// <summary>
        /// For tests purposes
        /// Clean database deleting all the Partners
        /// </summary>
        public void CleanDatabase()
        {
            _partners.DeleteMany(p => true);
        } 
    }
}