using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface IStudentManager:IGenericManager<Student>
    {
        new IEnumerable<StudentDto> GetAll();

        new StudentDto GetById(int id);

        StudentSearchDto SearchStudents(SearchAttribute value);

        void EnrollCourse(int sid, int cid);

        void CancleCourse(int sid, int cid);

    }

}
