using AppointmentsScheduler.DAL;
using AppointmentsScheduler.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentsScheduler.BLL
{
    public class BLLUser
    {
        private readonly DALUser _dalUser;

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

        public void UpdateUser(User user)
        {
            try
            {
                _dalUser.Update(user);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool UserExists(int id)
        {
            try
            {
                return _dalUser.Exists(id);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task InsertUser(User user)
        {
            try
            {
                user.Id = 0;
                await _dalUser.Insert(user);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task DeleteUser(User user)
        {
            try
            {
                await _dalUser.Delete(user);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
