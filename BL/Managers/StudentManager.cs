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

        public IEnumerable<StudentDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(_studentRepository.GetAll());
        }

        public StudentDto GetById(int id)
        {           
            return Mapper.Map<Student,StudentDto>(_studentRepository.GetById(id));
        }

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

        public bool Delete(int id)
        {
            Student s = _studentRepository.GetById(id);
            _studentRepository.Delete(s);
            return true;
        }           

        IEnumerable<Student> IGenericManager<Student>.GetAll()
        {
            return _studentRepository.Records.ToList();
        }

        Student IGenericManager<Student>.GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
    }

}
