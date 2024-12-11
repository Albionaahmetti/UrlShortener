using AutoMapper;
using UrlShortener.Classes;
using UrlShortener.DTOs.UrlItems;

namespace UrlShortener.Profiles
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {

            CreateMap<Create, UrlItem>().ReverseMap();
            CreateMap<Item, UrlItem>().ReverseMap();
        }
    }
}
