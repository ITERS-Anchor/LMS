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

        private ILecturerCourseRepository _lecturerCourseRepository;

        private ICourseRepository _courseRepository;

        public LecturerManager(ILecturerRepository lecturerRepository, ILecturerCourseRepository lecturerCourseRepository, ICourseRepository courseRepository)
        {
            _lecturerRepository = lecturerRepository;
            _lecturerCourseRepository = lecturerCourseRepository;
            _courseRepository = courseRepository;
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


        public LecturerDto GetByIdWithDetails(int id)
        {
            LecturerDto lecturer = Mapper.Map<Lecturer, LecturerDto>(_lecturerRepository.GetById(id));
            var query = from c in _courseRepository.Records
                        join lc in _lecturerCourseRepository.Records
                        on c.Id equals lc.CourseId
                        where lc.LecturerId == id
                        select c;
            lecturer.Courses = Mapper.Map <List<Course>, List<CourseDto>>(query.ToList());
            return lecturer;
        }

        public void TeachCourse(int lecturerId, int courseId)
        {
            if (!_lecturerCourseRepository.Records.Any(x=>x.CourseId==courseId && x.LecturerId==lecturerId))
            {
                _lecturerCourseRepository.Add(new LecturerCourse
                {
                    LecturerId = lecturerId,
                    CourseId = courseId
                });
            }                       
        }

        public void UnteachCourse(int lecturerId, int courseId)
        {
            var lc = _lecturerCourseRepository.Records.FirstOrDefault(x => x.LecturerId == lecturerId && x.CourseId == courseId);
            if (lc!=null)
            {
                _lecturerCourseRepository.Delete(lc);
            }
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
