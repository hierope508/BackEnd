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
        private readonly DALAppointment _dalAppointment;

        public BLLAppointment(string connectingString)
        {
            _dalAppointment = new DALAppointment(connectingString);
        }


        public async Task<List<Appointment>> GetAllAppointment()
        {
            try
            {
                return await _dalAppointment.SelectAll();
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
                return await _dalAppointment.Select(id);
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
                _dalAppointment.Update(appointment);
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
                return _dalAppointment.Exists(id);
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
                await _dalAppointment.Delete(appointment);
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
                return await _dalAppointment.Insert(appointment);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
