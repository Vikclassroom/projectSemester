using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class DeleteModel
    {
        [Key]
        public int DeleteId { get; set; }
        
        public int AccountId { get; set; }
        public AccountModel AccountModel { get; set; }
        
        public DateTime Date { get; set; }
    }
}
