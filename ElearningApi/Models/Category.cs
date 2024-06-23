using System.ComponentModel.DataAnnotations;

namespace ElearningApi.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        
        public string Image { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
