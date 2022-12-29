using System.ComponentModel.DataAnnotations;

namespace OuglaWebApp.Models
{
    public class testModel
    {
        public string Name { get; set; }
        [Key]
        public string sitename { get; set; }
        public string password { get; set; }
    }
}
