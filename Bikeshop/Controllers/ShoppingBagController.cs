using Bikeshop.Models;
using Bikeshop.Models.Repositories.Interfaces;
using Bikeshop.ViewModels;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bikeshop.Controllers
{
    public class ShoppingBagController : Controller
    {
        private readonly IShoppingBagRepository _shoppingBagRepository;
        public UserManager<Customer> _userManager;

        public ShoppingBagController(IShoppingBagRepository shoppingBagRepository, UserManager<Customer> userManager)
        {
            _shoppingBagRepository = shoppingBagRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var shoppingBag = _shoppingBagRepository.GetShoppingBag(userId);


            ShoppingBagViewModel shoppingBagViewModel = new ShoppingBagViewModel
            {
                ShoppingItems = shoppingBag.Items,
            };
            if (shoppingBagViewModel.ShoppingItems.Count == 0)
            {
                ViewBag.Empty = "No items added yet.";
            }
            return View(shoppingBagViewModel);
        }


    }
}