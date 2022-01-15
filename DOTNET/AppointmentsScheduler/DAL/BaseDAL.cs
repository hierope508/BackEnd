using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public abstract class BaseDAL<T> : BaseContext where T : class 
    {

        public BaseDAL(string connectionString) : base(connectionString)
        {

        }

        /// <summary>
        /// Get all <typeparamref name="T"/> objects from DB
        /// </summary>
        /// <returns>A List of <typeparamref name="T"/></returns>
        public async Task<List<T>> SelectAll()
        {
            return await Set<T>().ToListAsync();
        }

        /// <summary>
        /// Get an <typeparamref name="T"/> filtering by Id
        /// </summary>
        /// <param name="id">The id of the <typeparamref name="T"/></param>
        /// <returns>A <typeparamref name="T"/></returns>
        public async Task<T> Select(int id)
        {
            return await Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Update a <typeparamref name="T"/>
        /// </summary>
        /// <param name="obj"> <typeparamref name="T"/> object to be updated</param>
        /// <returns><typeparamref name="T"/> object</returns>
        public void Update(T obj)
        {
            base.Entry(typeof(T)).State = EntityState.Modified;

            SaveChanges();
        }

        /// <summary>
        /// Insert a <typeparamref name="T"/> on database
        /// </summary>
        /// <param name="obj"><typeparamref name="T"/> to be added</param>
        /// <returns></returns>
        public async Task<T> Insert(T obj)
        {
            try
            {
                Set<T>().Add(obj);
                await SaveChangesAsync();
            }
            catch (Exception)
            {
                Entry(obj).State = EntityState.Detached;
                throw;
            }

            return obj;
        }

        /// <summary>
        /// Delete a <typeparamref name="T"/> from database
        /// </summary>
        /// <param name="obj">Object to be deleted</param>
        /// <returns></returns>
        public async Task Delete(T obj)
        {
            Set<T>().Remove(obj);
            await SaveChangesAsync();
        }

        /// <summary>
        /// Check if a <typeparamref name="T"/> exists in DB
        /// </summary>
        /// <param name="id">The id of the obj</param>
        /// <returns>True if exists, false otherwise</returns>
        public abstract bool Exists(int id);
    }
}
