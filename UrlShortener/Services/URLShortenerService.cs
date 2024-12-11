using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrlShortener.AppDbContext;
using UrlShortener.Classes;
using UrlShortener.DTOs;
using UrlShortener.DTOs.UrlItems;
using UrlShortener.Helpers;
using UrlShortener.Interfaces;

namespace UrlShortener.Services
{
    public class URLShortenerService : IURLShortenerService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public URLShortenerService(ApplicationDbContext context,IMapper mapper)
        {
             _context = context;
             _mapper = mapper;

        }
        public Response<List<Item>> Get()
        {
            try
            {
                var item = _context.UrlItems.OrderByDescending(i => i.Id).ToList();
                return new Response<List<Item>>(false,_mapper.Map<IList<Item>>(item).ToList());
            }
            catch (Exception)
            {
                return new Response<List<Item>>(true, "Something went wrong. Please try again later!");
            }
        }
        public Response<dynamic> Create(Create model)
        {
			try
			{
                if (string.IsNullOrEmpty(model.LongUrl) || model.Minutes <= 0)
                    return new Response<dynamic>(true, "Invalid URL or expiration time.");
                  
                string shortUrlCode = string.Empty;
                bool exists;

                do
                {
                    shortUrlCode = new ShortURLGenerator().Generate();
                    exists = _context.UrlItems.Any(entity => entity.ShortCode == shortUrlCode);
                } while (exists);
                var expirationDate = DateTime.Now.AddMinutes(model.Minutes);

                var newUrl = new UrlItem();
                _mapper.Map(model, newUrl);
                newUrl.ExpirationTime = expirationDate;
                newUrl.ShortCode = shortUrlCode;
               
                  _context.UrlItems.Add(newUrl);
                 _context.SaveChanges();
                return new Response<dynamic>(false,new { shortUrlCode });
            }
			catch (Exception)
			{
                return new Response<dynamic>(true, "Something went wrong. Please try again later!");
			}
        }
        public bool Delete(string shortCode)
        {
            var url = _context.UrlItems.FirstOrDefault(u => u.ShortCode == shortCode);

            if (url == null)
                return false; 
           
            _context.UrlItems.Remove(url);
            _context.SaveChanges();

            return true;
        }

        public string? GetRedirectUrl(string shortCode)
        {
            var url = _context.UrlItems.FirstOrDefault(u => u.ShortCode == shortCode);

            if (url == null || url.ExpirationTime < DateTime.Now)
                return null; 

            url.ClickCounter++;
            _context.SaveChanges();

            return url.LongUrl;
        }

    }
}
