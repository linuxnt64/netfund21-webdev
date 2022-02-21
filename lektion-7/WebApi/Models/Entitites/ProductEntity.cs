using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required, Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Required, Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
