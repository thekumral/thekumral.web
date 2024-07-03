using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using thekumral.Core.DTOs.Posts;

namespace thekumral.Service.Validations
{
    public class PostDtoValidator : AbstractValidator<PostDto>
    {
        public PostDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Null olamazlar Title is required {PropertyName}")
                .NotEmpty()
                .WithMessage("{PropertyName} is Required");
        }
    }
}
