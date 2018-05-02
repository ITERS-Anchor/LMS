using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface ICourseRepository:IGenericRepository<Course>
    {
        //DbSet<Course> Courses { get; set; }
        //IEnumerable<Course> GetAll();
        //Course GetById(int Id);
        //Course Add();
        //Course Update(Course Course);
        //void Delete(Course Course);
    }

}
