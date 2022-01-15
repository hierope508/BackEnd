using AppointmentsScheduler.DAL;
using AppointmentsScheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentsScheduler.BLL
{
    public class BLLAuthentication
    {
        public static bool Authenticate(User user, string password)
        {
            if(user != null)
            {
                string hashedValue = user.Password;
                bool validPassword = new BLLSecurity().VerifyPassWord(password, hashedValue);

                return validPassword;

            }

            return false;
        }

    }
}
