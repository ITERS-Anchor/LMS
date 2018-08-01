using AutoMapper;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.App_Start
{
    public class AutomapperConfig
    {
        public static void Initialize()
        {//initialize only one place
            Mapper.Initialize(config =>
            {
                config.CreateMap<Student, StudentDto>();
                config.CreateMap<StudentDto, Student>();
                config.CreateMap<User, UserDisplayDto>();
                config.CreateMap<Course, CourseDto>();
                config.CreateMap<CourseDto, Course>();
            });
        }
    }

}