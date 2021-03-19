using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class Music
    {
        public int MusicId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}
