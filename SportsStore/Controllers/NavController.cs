﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;

namespace SportsStore.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            
            IEnumerable<string> categories = repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p);

            return PartialView(categories);
        }
    }
}