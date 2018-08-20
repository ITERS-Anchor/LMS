using BL.Managers.Interfaces;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class LecturersController : ApiController
    {
        private readonly ILecturerManager _lecturerManager;
        public LecturersController(ILecturerManager lecturerManager)
        {
            _lecturerManager = lecturerManager;
        }

        [HttpGet]
        [Route("api/lecturers")]
        public IHttpActionResult Get()
        {
            return Ok(_lecturerManager.GetAll());
        }

        public IHttpActionResult GetById(int id)
        {
            var lecturer = _lecturerManager.GetById(id);
            if (lecturer==null)
            {
                return NotFound();
            }
            return Ok(lecturer);
        }

        [HttpPost]
        [Route("api/lecturers/createlecturer")]
        public IHttpActionResult Post(Lecturer l)
        {
            return Ok(_lecturerManager.Create(l));
        }

        [HttpPut]
        [Route("api/lecturers/updatelecture")]
        public IHttpActionResult Put(Lecturer c)
        {
            _lecturerManager.Update(c);
            return Ok($"Update lecture Id:{c.Id} is sucessful!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (_lecturerManager.Delete(id))
            {
                return Ok($"The lecture with Id:{id} is deleted!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/lecturers/teachCourse")]
        public IHttpActionResult TeachCourse(int lecturerId,int courseId)
        {
            _lecturerManager.TeachCourse(lecturerId, courseId);
            return Ok();
        }

        [HttpDelete]
        [Route("api/lecturers/unteachCourse")]
        public IHttpActionResult UnteachCourse(int lecturerId, int courseId)
        {
            _lecturerManager.UnteachCourse(lecturerId, courseId);
            return Ok();
        }

        [HttpGet]
        [Route("api/lecturers/getwithDetails/{id}")]
        public IHttpActionResult GetWithDetails(int id)
        {
            var lecturer = _lecturerManager.GetByIdWithDetails(id);
            if (lecturer == null)
            {
                return NotFound();
            }
            return Ok(lecturer);
        }
    }
}
