using System;
using System.Linq;
using Bikeshop.Models;
using Bikeshop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bikeshop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET
        public IActionResult Index()
        {
            ViewBag.title = "Welcome to the Biksehop";
            ViewBag.bikeImage = _productRepository.GetBikeById(new Random().Next(1, 5)).Image;
            return View();
        }
    }
}