using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ElearningApi.DTOs.About
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
    
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly=true)]
        public string? Image { get; set; }

        public IFormFile UploadImage { get; set; }

    }

    public class  AboutCreateDtoValidator :AbstractValidator<AboutCreateDto>
    {
        public AboutCreateDtoValidator()
        {
            RuleFor(m => m.Title).NotNull().WithMessage("Titel cant be empty");
            RuleFor(m => m.Description).NotNull().MinimumLength(10);
            
        }

    }
}
