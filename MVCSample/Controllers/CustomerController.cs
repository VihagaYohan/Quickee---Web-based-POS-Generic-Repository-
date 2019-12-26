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
    public class CustomerController : Controller
    {
        private readonly ICustomerService service;
        private readonly IMapper mapper;

        public CustomerController(ICustomerService service,
                                  IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var ls_Customer = service.GetAll();
            var customers = mapper.Map<IEnumerable<CustomerPL>>(ls_Customer);
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerPL entity) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = mapper.Map<CustomerBL>(entity);
                    service.AddCustomer(customer);

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