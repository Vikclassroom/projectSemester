namespace API.Entities
{
    public class Link
    {
        public int LinkId { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
        public List List { get; set; }
        public int ListId { get; set; }
    }
}
