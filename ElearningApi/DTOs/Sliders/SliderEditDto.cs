using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ElearningApi.DTOs.Sliders
{
    public class SliderEditDto
    {
       
        public string Title { get; set; }
        
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
