using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entities
{
    public class ServiceEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required, Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Required, Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        [Required, Column(TypeName = "nvarchar(20)")]
        public string Icon { get; set; }
    }
}
