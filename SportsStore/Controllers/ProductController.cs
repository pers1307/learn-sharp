using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = repository.Products
                    .Where(product => category == null || product.Category == category)
                    .OrderBy(product => product.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage =  PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(product => product.Category == category).Count()
                },
                CurrentCategory = category
            };
            
            return View("List", model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }

            return null;
        }
    }
}