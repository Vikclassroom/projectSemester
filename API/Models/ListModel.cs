using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ListModel
    {
        [Key]
        public int ListId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Band { get; set; }
        [Required]
        public string Album { get; set; }
    }
}
