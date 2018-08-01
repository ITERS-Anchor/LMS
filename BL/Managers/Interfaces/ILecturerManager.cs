using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces
{
    public interface ILecturerManager: IGenericManager<Lecturer>
    {
         new IEnumerable<LecturerDto> GetAll();

         new LecturerDto GetById(int id);
    }
}
