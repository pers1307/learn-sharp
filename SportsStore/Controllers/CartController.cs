using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    // [RoutePrefix("Users")]
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController(
            IProductRepository repo,
            IOrderProcessor orderProc)
        {
            repository     = repo;
            orderProcessor = orderProc;
        }

        [Route("Test")]
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel()
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }


        [Route("Users/Add/{user}/{id:int}")]
        // [Route("Users/Add/{user}/{password:alpha:length(6)}")]
        public string Index(string user, int id)
        {
            return "";
        }


        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            
            return RedirectToAction("Index", new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}