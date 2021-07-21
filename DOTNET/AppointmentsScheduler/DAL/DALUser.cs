using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public class DALUser : BaseDAL
    {
        public DALUser(string connectionString) : base(connectionString)
        {
                
        }

        /// <summary>
        /// Get all users from DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Model.User>> SelectAll()
        {
            return await User.ToListAsync();
        }

        /// <summary>
        /// Get an user filtering by Id
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        public async Task<Model.User> Select(int id)
        {
            return await User.FindAsync(id);
        }

        /// <summary>
        /// Update a user 
        /// </summary>
        /// <param name="user">User object to be updated</param>
        /// <returns></returns>
        public async Task Update(Model.User user)
        {
            Entry(user).State = EntityState.Modified;

            await SaveChangesAsync();
        }

        /// <summary>
        /// Insert a User on database
        /// </summary>
        /// <param name="user">User to be added</param>
        /// <returns></returns>
        public async Task Insert(Model.User user)
        {
            User.Add(user);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Delete a user from database
        /// </summary>
        /// <param name="user">User to be deleted</param>
        /// <returns></returns>
        public async Task Delete(Model.User user)
        {
            User.Remove(user);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Check if a user exists in DB
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return User.Any(u=>u.Id == id);
        }

    }
}
