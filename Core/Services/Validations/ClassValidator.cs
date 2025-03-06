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
    class ClassValidator : AbstractValidator<Class>
    {
        private readonly IGenericRepository<Class> genericRepository;

        public ClassValidator(IGenericRepository<Class> genericRepository)
        {
            this.genericRepository = genericRepository;
            RuleFor(u => u.Id).Must(id => genericRepository.GetAll().FirstOrDefault(f => f.Id == id)
           == null ? true : false) // Sync validation
           .WithMessage("The ID is already taken. Please choose a unique ID.");
            RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(u => u.Teacher).NotEmpty().WithMessage("teacher is required");
            RuleFor(u => u.Description).NotEmpty().WithMessage("description is required");
        }
       
    }
}
