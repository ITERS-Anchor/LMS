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
        //[BasicAuthentication]
        public IHttpActionResult Get()
        {          
            return Ok(_studentManager.GetAll());
        }
        public IHttpActionResult GetStudentById(int id)
        {
            return Ok(_studentManager.GetById(id));
        }
        //[HttpGet]
        //[Route("api/students/search")]
        //public IHttpActionResult Get(string sortString="id",string sortOrder="asc",string searchValue="",int pageSize=10,int pageNumber=1)//asc
        //{
        //    SearchAttribute searchCondition = new SearchAttribute()
        //    {
        //        SearchValue = searchValue,
        //        SortOrder=sortOrder,
        //        SortString=sortString,
        //        PageNumber=pageNumber,
        //        PageSize=pageSize
        //    };
        //    StudentSearchDto students = _studentManager.SearchStudent(searchCondition);
        //    return Ok(students);
        //}

        [HttpPost]
        [Route("api/students/creatstudent")]
        public IHttpActionResult Post(Student student)
        {
            return Ok(_studentManager.Create(student));
        }
        [HttpPut]
        [Route("api/students/updatestudent")]
        public IHttpActionResult Put(Student student)
        {
            return Ok(_studentManager .Update(student));
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
        //[HttpPost]
        //[Route("api/students/addToCourse")]
        //public IHttpActionResult AddToCourse(int sid, int cid)
        //{
        //    _studentManager.AddToCourse(sid,cid);
        //    return Ok();
        //}
    }
}
