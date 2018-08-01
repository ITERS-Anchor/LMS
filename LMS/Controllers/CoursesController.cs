using BL.Managers.Interfaces;
using Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly ICourseManager _courseManager;
        public CoursesController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }

        public IHttpActionResult Get()
        {
            return Ok(_courseManager.GetAll());
        }

        public IHttpActionResult GetStudentById(int id)
        {
            return Ok(_courseManager.GetById(id));
        }

        [HttpPost]
        [Route("api/courses/creatcourse")]
        public IHttpActionResult Post(CourseDto student)
        {
            return Ok(_courseManager.Create(student));
        }
    }
}
