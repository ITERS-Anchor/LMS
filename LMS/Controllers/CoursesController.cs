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

        [HttpGet]
        [Route("api/courses")]
        public IHttpActionResult Get()
        {
            return Ok(_courseManager.GetAll());
        }

        public IHttpActionResult GetStudentById(int id)
        {
            return Ok(_courseManager.GetById(id));
        }

        [HttpPost]
        [Route("api/courses/createcourse")]
        public IHttpActionResult Post(CourseDto course)
        {
            return Ok(_courseManager.Create(course));
        }

        [HttpPut]
        [Route("api/courses/updatecourse")]
        public IHttpActionResult Put(CourseDto c)
        {
            _courseManager.Update(c);
            return Ok($"Update Course Id:{c.Id} is sucessful!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (_courseManager.Delete(id))
            {
                return Ok($"The course with Id:{id} is deleted!");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
