using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCSample.Business.Entity;
using MVCSample.Business.IService;
using MVCSample.Entity;

namespace MVCSample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        private readonly IMapper mapper;

        public ProductController(IProductService service,
                                 IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var ls_Product = service.GetAll();
            var product = mapper.Map<IEnumerable<ProductPL>>(ls_Product);
            return View(product);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductPL entity) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = mapper.Map<ProductBL>(entity);
                    service.Add(product);

                    return RedirectToAction("Index");
                }
                else 
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}