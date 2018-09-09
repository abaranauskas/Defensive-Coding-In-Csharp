using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common
{
    public class EmailLibrary
    {
        public void SendEmail(string emailAddress, string v)
        {
            //if valid email

            try
            {
                //send email
            }
            catch (InvalidOperationException ex)
            {
                //log issue kol turim unformacija ka norim padaryt
                throw; //rethroeinam excepriona kad saukiantysis ir zinotu ir jei ka istirtu
                //throw ex; su ex geriau nenaudoti prarandama dalis duomenu perduodant
            }
          
        }
    }
}
