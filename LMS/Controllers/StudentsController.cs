using BL.Managers;
using BL.Managers.Interfaces;
using LMS.Filters;
using Model.Dto;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LMS.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IStudentManager _studentManager;
        public StudentsController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        [Route("api/students/all")]
        public IHttpActionResult Get()
        {          
            return Ok(_studentManager.GetAll());
        }

        public IHttpActionResult GetStudentById(int id)
        {
            var stu = _studentManager.GetById(id);
            if (stu==null)
            {
                return NotFound();
            }
            return Ok(stu);
        }
        
        public IHttpActionResult Get(string sortString = "id", string sortOrder = "asc", string searchValue = "", int pageSize = 10, int pageNumber = 1)//asc
        {
            SearchAttribute searchCondition = new SearchAttribute()
            {
                SearchValue = searchValue,
                SortOrder = sortOrder,
                SortString = sortString,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            StudentSearchDto students = _studentManager.SearchStudents(searchCondition);
            if (students.Students.Count==0)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpPost]
        [Route("api/students/createstudent")]
        public IHttpActionResult Post(Student student)
        {
            return Ok(_studentManager.Create(student));
        }
        [HttpPut]
        [Route("api/students/updatestudent")]
        public IHttpActionResult Put(Student student)
        {
            _studentManager.Update(student);
            return Ok($"Update Id:{student.Id} is sucessful!");
        }

        [HttpDelete]        
        public IHttpActionResult Delete(int id)
        {
            if (_studentManager.Delete(id))
            {
                return Ok($"The student with Id:{id} is deleted!");
            }
            else
            {
                return BadRequest();
            }         
        }

        [HttpPost]
        [Route("api/students/enrollCourse")]
        public IHttpActionResult EnrollCourse(int sid, int cid)
        {
            _studentManager.EnrollCourse(sid, cid);
            return Ok($"You are enrolled in Course: {cid}");
        }

        [HttpDelete]
        [Route("api/students/dropCourse")]
        public IHttpActionResult DropCourse(int sid, int cid)
        {
            _studentManager.DropCourse(sid, cid);
            return Ok();
        }

        [HttpGet]
        [Route("api/students/getwithDetails/{id}")]
        public IHttpActionResult GetWithDetails(int id)
        {
            var stu = _studentManager.GetByIdWithDetail(id);
            if (stu==null)
            {
                return NotFound();
            }
            return Ok(stu);
        }
    }
}
