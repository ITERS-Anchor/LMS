using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IAuthRepository
    {
        User FindUser(string userName, string passwordHash);
    }

}
