using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Link
    {
        public int LinkId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        [ForeignKey("Music")]
        public int MusicId { get; set; }
        public Music Music { get; set; } 
    }
}
