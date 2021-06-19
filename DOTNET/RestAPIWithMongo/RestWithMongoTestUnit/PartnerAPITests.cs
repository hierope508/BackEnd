using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestWithMongo.DAL;
using RestWithMongo.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using RestWithMongo.BLL;

namespace RestWithMongoTestUnit
{
    [TestClass]
    public class PartnerAPITests
    {
        public IConfigurationRoot Configuration { get; set; }
        public DALPartner _dalPartner;
        public BLLPartner _bllPartner;
        public RestWithMongo.Controllers.PartnerController API;
        public PartnerAPITests()
        {
            LoadConfigurations();
            DatabaseSettings connectionSettings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            _dalPartner = new DALPartner(connectionSettings);
            _bllPartner = new BLLPartner(_dalPartner);
            API = new RestWithMongo.Controllers.PartnerController(_bllPartner);
        }

        [TestMethod]
        public void A001_InsertPartnerTest()
        {
            string partnerJson = "{" + '"' + "id" + '"' + ":" + '"' + "5" + '"' + "," + '"' + "tradingName" + '"' + ":" + '"' + "Bar Legal" + '"' + "," + '"' + "ownerName" + '"' + ":" + '"' + "Fernando Silva" + '"' + "," + '"' + "document" + '"' + ":" + '"' + "05202839000126" + '"' + "," + '"' + "coverageArea" + '"' + ":{" + '"' + "type" + '"' + ":" + '"' + "MultiPolygon" + '"' + "," + '"' + "coordinates" + '"' + ":[[[[-43.50404,-22.768366],[-43.45254,-22.775646],[-43.429195,-22.804451],[-43.38422,-22.788942],[-43.390743,-22.764568],[-43.355724,-22.739239],[-43.403446,-22.705671],[-43.440525,-22.707571],[-43.4752,-22.698704],[-43.514683,-22.742722],[-43.50404,-22.768366]]]]}," + '"' + "address" + '"' + ":{" + '"' + "type" + '"' + ":" + '"' + "Point" + '"' + "," + '"' + "coordinates" + '"' + ":[-43.432034,-22.747707]}}";
            var partner = API.Create(JsonSerializer.Deserialize<Partner>(partnerJson)).Value;
            var partnerGet = API.Get("5").Value;
            Assert.IsNotNull(partner);
            Assert.IsNotNull(partnerGet);
            Assert.AreEqual(partner.ToString(), partnerGet.ToString());
        }

        [TestMethod]
        public void A002_GetPartnerTest()
        {
            var partner = API.Get("5").Value;
            Assert.IsNotNull(partner);
            Assert.AreEqual(partner.Id, "5");
        }

        [TestMethod]
        public void A003_GetClosestPartnerTest()
        {
            var locationAPI = new RestWithMongo.Controllers.PartnerLocationController(_bllPartner);
            List<Partner> partners = locationAPI.GetClosestPartners(-44.01078284691772, -19.886458308949283).Value;
            Assert.IsNotNull(partners);
            //Assert.IsTrue(partners.Count > 0);
        }

        private void LoadConfigurations()
        {
            string configurationPath = Path.Combine(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("RestWithMongoTestUnit")), "RestWithMongo");
            
            var builder = new ConfigurationBuilder()
            .SetBasePath(configurationPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

        }
    }
}
