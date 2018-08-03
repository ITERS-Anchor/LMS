using Data.Database;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        LMSEntities Context { get; }
    }

}
