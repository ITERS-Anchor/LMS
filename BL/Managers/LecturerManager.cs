using BL.Managers.Interfaces;
using Model.Model;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dto;
using AutoMapper;

namespace BL.Managers
{
    public class LecturerManager : ILecturerManager
    {
        private ILecturerRepository _lecturerRepository;

        public LecturerManager(ILecturerRepository LecturerRepository)
        {
            _lecturerRepository = LecturerRepository;
        }

        public Lecturer Create(Lecturer lecturer)
        {
            _lecturerRepository.Add(lecturer);
            return lecturer;
        }

        public bool Delete(int id)
        {
            _lecturerRepository.Delete(_lecturerRepository.GetById(id));
            return true;
        }

        public IEnumerable<LecturerDto> GetAll()
        {
            return (Mapper.Map<IEnumerable<Lecturer>, IEnumerable<LecturerDto>>(_lecturerRepository.GetAll()));
            
        }
       
        public LecturerDto GetById(int id)
        {
            return (Mapper.Map<Lecturer, LecturerDto>(_lecturerRepository.GetById(id)));
        }

        public Lecturer Update(Lecturer entity)
        {
            _lecturerRepository.Update(entity);
            return entity;
        }

        IEnumerable<Lecturer> IGenericManager<Lecturer>.GetAll()
        {
            return _lecturerRepository.Records.ToList();
        }

        Lecturer IGenericManager<Lecturer>.GetById(int id)
        {
            return _lecturerRepository.GetById(id);
        }
    }
}
