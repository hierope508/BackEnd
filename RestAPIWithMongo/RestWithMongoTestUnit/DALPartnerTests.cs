using RestWithMongo.DAL;
using RestWithMongo.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RestWithMongoTestUnit
{
    [TestClass]
    public class DALPartnerTests
    {
        public IConfigurationRoot Configuration { get; set; }
        public DALPartner _dalPartner;

        public DALPartnerTests()
        {
            LoadConfigurations();
            DatabaseSettings connectionSettings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            _dalPartner = new DALPartner(connectionSettings);
        }

        [TestMethod]
        public void A001_InsertManyPartnerTest()
        {
            if (_dalPartner.GetRowCount()>0)
                return;

            _dalPartner.CleanDatabase();
            string partnersJson = File.ReadAllText("Assets/Partners.json");
            List<Partner> partners = JsonSerializer.Deserialize<List<Partner>>(partnersJson);
            var result = _dalPartner.InsertMany(partners);
            Assert.IsNotNull(result);
            Assert.AreEqual(partners.Count, result.Count);
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
