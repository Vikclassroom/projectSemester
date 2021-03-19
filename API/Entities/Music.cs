namespace API.Entities
{
    public class Music
    {
        public int MusicId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public Link Link { get; set; }
        public int LinkId { get; set; }
    }
}
