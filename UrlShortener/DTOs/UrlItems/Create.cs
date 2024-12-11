using System.ComponentModel.DataAnnotations;

namespace UrlShortener.DTOs.UrlItems
{
    public class Create
    {
        public string? LongUrl { get; set; }
      
        public int Minutes { get; set; }
    }
}
