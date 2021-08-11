using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentsScheduler.DAL;
using AppointmentsScheduler.Model;

namespace AppointmentsScheduler.BLL
{
    public class BLLPatient
    {
        private readonly DALPatient _dalPatient;

        public BLLPatient(string connectionString)
        {
            _dalPatient = new DALPatient(connectionString);
        }

        public async Task<Patient> GetPatient(int id)
        {
            try
            {
                return await _dalPatient.Select(id);
            }
            catch (Exception ex)
            {
                //Log;
                throw;
            }

        }

        public async Task<List<Patient>> GetAllPatients()
        {
            try
            {
                return await _dalPatient.SelectAll();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void UpdatePatient(Patient Patient)
        {
            try
            {
                _dalPatient.Update(Patient);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool PatientExists(int id)
        {
            try
            {
                return _dalPatient.Exists(id);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task InsertPatient(Patient Patient)
        {
            try
            {
                Patient.Id = 0;
                await _dalPatient.Insert(Patient);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task DeletePatient(Patient Patient)
        {
            try
            {
                await _dalPatient.Delete(Patient);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
