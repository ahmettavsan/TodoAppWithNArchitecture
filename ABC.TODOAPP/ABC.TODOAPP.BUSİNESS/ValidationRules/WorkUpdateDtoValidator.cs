using ABC.TODOAPP.DTOs.WorkDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.BUSİNESS.ValidationRules
{
    public class WorkUpdateDtoValidator:AbstractValidator<WorkUpdateDTos>

    {
        public WorkUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Defination cant be null");
            RuleFor(x => x.Definition).NotEmpty().When(x => x.IsCompleted == true).WithMessage("when iscomplated is true you must entry defination");
        }
    }
}
