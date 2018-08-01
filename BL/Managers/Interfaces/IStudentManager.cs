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
        IEnumerable<StudentDto> GetAll();

        StudentDto GetById(int id);
       
        //void AddToCourse(int sid, int cid);
        //StudentSearchDto SearchStudent(SearchAttribute search);

    }

}
