using System.ComponentModel.DataAnnotations;

namespace OuglaWebApp.Models
{
    public class BlogModel
    {
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
