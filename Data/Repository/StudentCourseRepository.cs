using Data.Database;
using Data.Repository.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class StudentCourseRepository : GenericRepository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(LMSEntities context) : base(context)
        {

        }

        public void AddStuToCourse(Student s, Course c)
        {
            StudentCourse sc = new StudentCourse();
            sc.CourseId = c.Id;
            sc.StudentId = s.Id;
            sc.Course = c;
            sc.Student = s;
            Records.Add(sc);
            _context.SaveChanges();
        }
        //public void AddStuToCourse(Student s, Course c)
        //{
        //    StudentCourse sc = new StudentCourse();
        //    sc.CourseId = c.Id;
        //    sc.StudentId = s.Id;
        //    sc.Course = c;
        //    sc.Student = s;
        //    Records.Add(sc);
        //    _context.SaveChanges();
        //}
    }
}
