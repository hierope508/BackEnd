using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public class DALUser : BaseDAL, IBaseDAL<Model.User>
    {
        public DALUser(string connectionString) : base(connectionString)
        {
                
        }

        public async Task<List<Model.User>> SelectAll()
        {
            return await User.ToListAsync();
        }

        public async Task<Model.User> Select(int id)
        {
            return await User.FindAsync(id);
        }

        public void Update(Model.User user)
        {
            base.Entry(user).State = EntityState.Modified;

            SaveChanges();
        }

        
        public async Task Insert(Model.User user)
        {
            User.Add(user);
            await SaveChangesAsync();
        }

        public async Task Delete(Model.User user)
        {
            User.Remove(user);
            await SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return User.Any(u=>u.Id == id);
        }

    }
}
