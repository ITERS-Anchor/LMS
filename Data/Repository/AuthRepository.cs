using Data.Database;
using Data.Repository.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public User FindUser(string userName, string passwordHash)
        {
            using (LMSEntities context = new LMSEntities())
            {
                return context.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == passwordHash);
            }
        }
    }

}
