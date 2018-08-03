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
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(LMSEntities context) : base(context)
        {
            //Context = context;
        }

        public LMSEntities Context => _context;
    }
}
