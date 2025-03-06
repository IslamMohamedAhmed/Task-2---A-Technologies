using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IStudentServices
    {
        IEnumerable<StudentRequestDto> GetAllStudents();
        StudentRequestDto GetStudentById(int id);
        void AddStudent(int id, Student entity);
        void UpdateStudent(int id, Student entity);
        void DeleteStudent(int id);
    }
}
