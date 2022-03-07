using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class ContactFormEntity
    {
        public ContactFormEntity(string name, string email, string message)
        {
            Name = name;
            Email = email;
            Message = message;
        }

        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
