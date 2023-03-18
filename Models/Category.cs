using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStore.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}