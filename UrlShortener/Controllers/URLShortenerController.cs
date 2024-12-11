using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using UrlShortener.AppDbContext;
using UrlShortener.Classes;
using UrlShortener.DTOs.UrlItems;
using UrlShortener.Helpers;
using UrlShortener.Interfaces;
using UrlShortener.Models;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace UrlShortener.Controllers
{
    public class URLShortenerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IURLShortenerService _service;

        public URLShortenerController(ApplicationDbContext context, IURLShortenerService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()=>View(_service.Get());

        public IActionResult Create([FromForm] Create model) => Ok(_service.Create(model)); 
        public IActionResult RedirectToLongURL(string shortCode)
        {
            var url = _service.GetRedirectUrl(shortCode);

            if (url == null)
                return View("Error", "URL has expired or does not exist.");
            
            return Redirect(url);
        }
        public IActionResult Delete(string shortCode)
        {
            var result = _service.Delete(shortCode);
            if (!result)
                return View("Error", "Failed to delete the URL.");
           
            return RedirectToAction("Index");
        }
        

    }
}
