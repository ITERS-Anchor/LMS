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
        //DbSet<Student> Students { get; set; }
        //IEnumerable<Student> GetAll();
        //Student GetById(int Id);
        //Student Add(Student student);
        //Student Update(Student student);
        //void Delete(Student student);
    }

}
