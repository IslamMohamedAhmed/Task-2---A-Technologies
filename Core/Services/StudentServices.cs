using Contracts;
using Domain.Models;
using FluentValidation;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IGenericRepository<Student> genericRepository;
        private readonly IValidator<Student> validator;

        public StudentServices(IGenericRepository<Student> genericRepository,IValidator<Student> validator)
        {
            this.genericRepository = genericRepository;
            this.validator = validator;
        }
        public void AddStudent(int id, Student entity)
         {
            var validationResult = validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            
            genericRepository.Add(id,entity);
        }

        public void DeleteStudent(int id)
        {
            if(genericRepository.GetAll().FirstOrDefault(u=> u.Id == id) == null)
            {
                throw new KeyNotFoundException("id is not found");
            }
            genericRepository.Delete(id);
            
        }

        public IEnumerable<StudentRequestDto> GetAllStudents()
        {
            
        }

        public StudentRequestDto GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(int id, StudentRequestDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
