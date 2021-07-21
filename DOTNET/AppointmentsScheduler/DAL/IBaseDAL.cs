using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsScheduler.DAL
{
    public interface IBaseDAL<T>
    {
        /// <summary>
        /// Get all <typeparamref name="T"/> objects from DB
        /// </summary>
        /// <returns>A List of <typeparamref name="T"/></returns>
        public Task<List<T>> SelectAll();

        /// <summary>
        /// Get an <typeparamref name="T"/> filtering by Id
        /// </summary>
        /// <param name="id">The id of the <typeparamref name="T"/></param>
        /// <returns>A <typeparamref name="T"/></returns>
        public Task<T> Select(int id);

        /// <summary>
        /// Update a <typeparamref name="T"/>
        /// </summary>
        /// <param name="obj"> <typeparamref name="T"/> object to be updated</param>
        /// <returns><typeparamref name="T"/> object</returns>
        public void Update(T obj);

        /// <summary>
        /// Insert a <typeparamref name="T"/> on database
        /// </summary>
        /// <param name="obj"><typeparamref name="T"/> to be added</param>
        /// <returns></returns>
        public Task Insert(T obj);

        /// <summary>
        /// Delete a <typeparamref name="T"/> from database
        /// </summary>
        /// <param name="obj">User to be deleted</param>
        /// <returns></returns>
        public Task Delete(T obj);

        /// <summary>
        /// Check if a <typeparamref name="T"/> exists in DB
        /// </summary>
        /// <param name="id">The id of the user</param>
        /// <returns>True if exists, false otherwise</returns>
        public bool Exists(int id);
    }
}
