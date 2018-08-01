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

        public IHttpActionResult Get()
        {
            return Ok(_lecturerManager.GetAll());
        }

        public IHttpActionResult GetById(int id)
        {
            return Ok(_lecturerManager.GetById(id));
        }

        [HttpPost]
        [Route("api/lectures/createlecturer")]
        public IHttpActionResult Post(Lecturer l)
        {
            return Ok(_lecturerManager.Create(l));
        }

        [HttpPut]
        [Route("api/lectures/updatelecture")]
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
    }
}
