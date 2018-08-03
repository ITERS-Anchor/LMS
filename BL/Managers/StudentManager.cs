using AutoMapper;
using BL.Managers.Interfaces;
using BL.Util;
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
    public class StudentManager : IStudentManager
    {
        private IStudentRepository _studentRepository;      

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
          
        }

       // Add new Student
        public Student Create(Student stu)
        {
            if (!_studentRepository.Records.Any(x => x.Email == stu.Email))
            {
                _studentRepository.Add(stu);
            }
            else
            {
                return _studentRepository.Records.FirstOrDefault
                    (x => x.Email == stu.Email);
            }

            return stu;
        }

        // Get all students 
        public IEnumerable<StudentDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(_studentRepository.GetAll());
        }

        // Get student by Id
        public StudentDto GetById(int id)
        {           
            return Mapper.Map<Student,StudentDto>(_studentRepository.GetById(id));
        }
        // Edit student info
        public Student Update(Student stu)
        {
            //Student student = _studentRepository.GetById(stu.Id);
            //student.FirstName = stu.FirstName;
            //student.LastName = stu.LastName;
            //student.Gender = stu.Gender;
            //student.DateOfBirth = stu.DateOfBirth;
            //student.Email = stu.Email;
            //student.Credit = stu.Credit;
            _studentRepository.Update(stu);
            return _studentRepository.GetById(stu.Id);
        }

        // Delete student by Id
        public bool Delete(int id)
        {
            Student s = _studentRepository.GetById(id);
            _studentRepository.Delete(s);
            return true;
        }           

        // Search students
        public StudentSearchDto SearchStudents(SearchAttribute search)
        {
            if (search.PageNumber == 0)
            {
                search.PageNumber = 1;
            }
            if (search.PageSize == 0)
            {
                search.PageSize = 10;
            }
            var students = _studentRepository.Records.Search(search.SearchValue);
            students = students.ApplySort(search.SortString, search.SortOrder);

            var SearchResult = new StudentSearchDto
            {
                PageSize = search.PageSize,
                TotalPage = students.Count() / search.PageSize + (students.Count() % search.PageSize == 0 ? 0 : 1)
            };

            SearchResult.PageNumber = search.PageNumber > SearchResult.TotalPage ? 1 : search.PageNumber;

            SearchResult.Students = Mapper.Map<List<Student>, List<StudentDto>>(students.Skip((SearchResult.PageNumber - 1) * SearchResult.PageSize).Take(SearchResult.PageSize).ToList());
            return SearchResult;
        }

        IEnumerable<Student> IGenericManager<Student>.GetAll()
        {
            return _studentRepository.Records.ToList();
        }

        Student IGenericManager<Student>.GetById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void EnrollCourse(int sid, int cid)
        {
            StudentCourse sc = new StudentCourse
            {
                StudentId = sid,
                CourseId = cid
            };
            if (!_studentRepository.Context.StudentCourses.Any(x => x.StudentId == sid && x.CourseId == cid))
            {
                _studentRepository.Context.StudentCourses.Add(sc);
                _studentRepository.Context.SaveChanges();
            }
           
        }

        public void CancleCourse(int sid, int cid)
        {
            var studentCourse = _studentRepository.Context.StudentCourses.FirstOrDefault(x => x.StudentId == sid && x.CourseId == cid);
            if (studentCourse != null)
            {
                _studentRepository.Context.StudentCourses.Remove(studentCourse);
                _studentRepository.Context.SaveChanges();
            }
        }
    }

}
