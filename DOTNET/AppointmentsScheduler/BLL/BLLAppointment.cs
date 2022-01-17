using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsScheduler.DAL;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.BLL
{
    public class BLLAppointment
    {
        private readonly string _connectionString;

        public BLLAppointment(string connectingString)
        {
            _connectionString = connectingString;
        }


        public async Task<List<Appointment>> GetAllAppointment()
        {
            try
            {
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                return await dalAppointment.SelectAll();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            try
            {
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                return await dalAppointment.Select(id);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public IList<Appointment> GetAppointments(DateTime date, string query)
        {
            try
            {
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                return dalAppointment.Select(date, query);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void UpdateAppointment(Appointment appointment)
        {
            try
            {
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                dalAppointment.Update(appointment);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool AppointmentExists(int id)
        {
            try
            {
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                return dalAppointment.Exists(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteAppointment(Appointment appointment)
        {
            try
            {
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                await dalAppointment.Delete(appointment);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Appointment> InsertAppointment(Appointment appointment)
        {
            try
            {
                appointment.Id = 0;
                using DALAppointment dalAppointment = new DALAppointment(_connectionString);
                return await dalAppointment.Insert(appointment);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
