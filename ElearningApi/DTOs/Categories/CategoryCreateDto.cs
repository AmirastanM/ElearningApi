using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ElearningApi.DTOs.Categories
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }

        public IFormFile UploadImage { get; set; }
    }
}
