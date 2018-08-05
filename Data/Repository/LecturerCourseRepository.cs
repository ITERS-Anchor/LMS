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
    public class LecturerCourseRepository : GenericRepository<LecturerCourse>, ILecturerCourseRepository
    {
        public LecturerCourseRepository(LMSEntities context) : base(context)
        {

        }
    }
}
