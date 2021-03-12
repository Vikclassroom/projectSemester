using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class DeleteModel
    {
        [Key]
        public int DeleteId { get; set; }
        [Required]
        public AccountModel AccountId { get; set; }
        [Required]
        public ListModel ListId { get; set; }
        public DateTime Date { get; set; }
    }
}
