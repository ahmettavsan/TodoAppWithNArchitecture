using ABC.TODOAPP.DTOs.WorkDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.BUSİNESS.ValidationRules
{
    public class WorkCreateDtoValidator:AbstractValidator<WorkCreateDto>
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x=>x.Definition).NotEmpty().WithMessage("Defination is required!!!!");

        }
    }
}
