using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsScheduler.DAL;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.BLL
{
    public class BLLCountry
    {
        private readonly DALCountry _dalCountry;

        public BLLCountry(string connectionString)
        {
            _dalCountry = new DALCountry(connectionString);
        }

        public async Task<Country> GetCountry(int id)
        {
            try
            {
                return await _dalCountry.Select(id);
            }
            catch (Exception ex)
            {
                //Log;
                throw;
            }

        }

        public async Task<List<Country>> GetAllCountries()
        {
            try
            {
                return await _dalCountry.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdateCountry(Country Country)
        {
            try
            {
                _dalCountry.Update(Country);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool CountryExists(int id)
        {
            try
            {
                return _dalCountry.Exists(id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task InsertCountry(Country Country)
        {
            try
            {
                Country.Id = 0;
                await _dalCountry.Insert(Country);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task DeleteCountry(Country Country)
        {
            try
            {
                await _dalCountry.Delete(Country);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
