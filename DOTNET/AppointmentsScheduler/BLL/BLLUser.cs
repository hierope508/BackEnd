using AppointmentsScheduler.DAL;
using AppointmentsScheduler.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentsScheduler.BLL
{
    public class BLLUser
    {
        private DALUser _dalUser;

        public BLLUser(string connectingString)
        {
            _dalUser = new DALUser(connectingString);
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                return await _dalUser.Select(id);
            }
            catch (Exception ex)
            {
                //Log;
                throw;
            }
            
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _dalUser.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
            
        }



    }
}
