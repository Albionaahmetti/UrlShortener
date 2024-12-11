using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UrlShortener.DTOs;
using UrlShortener.DTOs.UrlItems;

namespace UrlShortener.Interfaces
{
    public interface IURLShortenerService
    {
        public Response<List<Item>> Get();
        public Response<dynamic> Create(Create model);
        public bool Delete(string shortCode);
        public string? GetRedirectUrl(string shortCode);
    }
}
