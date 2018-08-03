using AutoMapper;
using BL.Managers.Interfaces;
using Data.Repository.Interfaces;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    public class CourseManager : ICourseManager
    {
        private ICourseRepository _courseRepository;
        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public CourseDto Create(CourseDto course)
        {
            _courseRepository.Add(Mapper.Map<CourseDto, Course>(course));
            return course;
        }

        public bool Delete(int id)
        {
            _courseRepository.Delete(_courseRepository.GetById(id));
            return true;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_courseRepository.GetAll());
        }

        public CourseDto GetById(int id)
        {
            return Mapper.Map<Course, CourseDto>(_courseRepository.GetById(id));
        }

        public CourseDto Update(CourseDto course)
        {
            _courseRepository.Update(Mapper.Map<CourseDto, Course>(course));
            return Mapper.Map<Course, CourseDto>(_courseRepository.GetById(course.Id));
        }
    }
}
