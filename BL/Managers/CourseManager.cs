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
            _courseRepository.Add(AutoMapper.Mapper.Map<CourseDto, Course>(course));
            return course;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_courseRepository.GetAll());
        }

        public CourseDto GetById(int id)
        {
            return Mapper.Map<Course, CourseDto>(_courseRepository.GetById(id));
        }

        public CourseDto Update(CourseDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
