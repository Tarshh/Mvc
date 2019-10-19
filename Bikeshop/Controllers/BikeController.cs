using System;
using System.Collections.Generic;
using System.Linq;
using Bikeshop.Extensions;
using Bikeshop.Models;
using Bikeshop.Models.Repositories.Interfaces;
using Bikeshop.ViewModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bikeshop.Controllers
{
    public class BikeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IShoppingItemRepository _shoppingItemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShoppingBagRepository _shoppingBagRepository;

        public BikeController(IProductRepository productRepository, IShoppingItemRepository shoppingItemRepository, ICustomerRepository customerRepository, IShoppingBagRepository shoppingBagRepository)
        {
            _productRepository = productRepository;
            _shoppingItemRepository = shoppingItemRepository;
            _customerRepository = customerRepository;
            _shoppingBagRepository = shoppingBagRepository;
        }
        // GET
        public IActionResult Index()
        {
            var bikeViewModel = new IndexBikeViewModel()
            {
                Title = "Click on button to see details",
                Products = _productRepository.GetAllBikes().ToList(),
            };
            return View(bikeViewModel);
        }

        public IActionResult Details(int bikeId)
        {
            var bike = _productRepository.GetBikeById(bikeId);
            if (bike == null)
            {
                return NotFound();
            }

            var detailPageModel = new DetailPageModel
            {
                Product = bike,
                ShoppingItem = new ShoppingItem()
            };

            //var image = detailPageModel.Product.Image;
            return View(detailPageModel);
        }

        [HttpPost]
        public IActionResult AddToShoppingBag([FromForm]DetailPageModel model)
        {
            //Create the customer
            var customer = GetCustomer();

            //Get the bike
            var bike = GetProduct(model.Product.Id);

            //Create the shoppingBag if it not exists
            var shoppingBag = GetShoppingBag(customer.Id);

            var shoppingItem = _shoppingItemRepository.GetItem(model.Product.Id, shoppingBag.Id);

            if (shoppingItem == null)
            {
                shoppingItem = CreateShoppingItem(bike, model.ShoppingItem.Quantity, shoppingBag);
                _shoppingItemRepository.AddItem(shoppingItem);
            }
            else
            {
                shoppingItem.Quantity += model.ShoppingItem.Quantity;
                _shoppingItemRepository.UpdateShoppingItem(shoppingItem);
            }

            //TempData.Put("_ShoppingBag", shoppingBag);

            return RedirectToAction("Index", "ShoppingBag");
        }

        private ShoppingItem CreateShoppingItem(Product bike, int shoppingItemQuantity, ShoppingBag shoppingBag)
        {
            var shoppingItem = new ShoppingItem
            {
                Product = bike,
                Quantity = shoppingItemQuantity,
                Bag = shoppingBag
            };
            return shoppingItem;
        }

        private Customer GetCustomer()
        {
            var customer = _customerRepository.GetCustomer("1");
            if (customer == null)
            {
                var newCustomer = new Customer
                {
                    FirstName = "Roni",
                    Name = "Size",
                    Bags = new List<ShoppingBag>()
                };
                _customerRepository.AddCustomer(newCustomer);
                customer = newCustomer;
            }
            return customer;
        }

        private Product GetProduct(int productId)
        {
            return _productRepository.GetBikeById(productId);
        }

        private ShoppingBag GetShoppingBag(string customerId)
        {
            var shoppingBag = _shoppingBagRepository.GetShoppingBag(customerId);
            if (shoppingBag == null)
            {
                var newShoppingBag = new ShoppingBag
                {
                    Customer = _customerRepository.GetCustomer(customerId),
                    Date = DateTime.Now,
                    Items = new List<ShoppingItem>()
                };
                shoppingBag = newShoppingBag;
                _shoppingBagRepository.AddItem(shoppingBag);
            }
            return shoppingBag;
        }
    }
}