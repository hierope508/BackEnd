using System;

namespace AppointmentsScheduler.BLL
{
    public class BLLSecurity
    {
        public string GenerateHashedPassword(string pass)
        {
            string hash = String.Empty ;
            hash = BCrypt.Net.BCrypt.HashPassword(pass);

            return hash;
        }

        public bool VerifyPassWord(string enteredValue, string hashedValue)
        {
            try
            {
                string hash = GenerateHashedPassword(enteredValue);
                return BCrypt.Net.BCrypt.Verify(enteredValue, hashedValue);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
