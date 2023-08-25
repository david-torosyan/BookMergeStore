using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookMergeStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        [DisplayName("Dispaly Order")]
        public int DisplayOrder { get; set; }

    }
}
