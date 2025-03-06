using Contracts;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validations
{

    public class  StudentValidator : AbstractValidator<Student>
    {
        private readonly IGenericRepository<Student> genericRepository;

        public StudentValidator(IGenericRepository<Student> genericRepository)
        {
            this.genericRepository = genericRepository;
            RuleFor(u => u.Id).Must(id => genericRepository.GetAll().FirstOrDefault(f => f.Id == id)
            == null ? true:false) // Sync validation
            .WithMessage("The ID is already taken. Please choose a unique ID.");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(u => u.Age).NotEmpty().WithMessage("age is required").GreaterThan(0).WithMessage("age should " +
                "be positive");

            
        }
      

    }
}
