namespace UrlShortener.Classes
{
    public class UrlItem
    {
        public int Id { get; set; }
        public string? LongUrl { get; set; }
        public string? ShortCode { get; set; }
        public int ClickCounter{ get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
