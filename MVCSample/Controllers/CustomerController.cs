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

        [HttpGet]
        public IActionResult Edit(int Id) 
        {
            try
            {
                var CustomerEntity = service.FindById(Id);
                var Customer = mapper.Map<CustomerPL>(CustomerEntity);
                return View(Customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Edit(CustomerPL customer) 
        {
            if (ModelState.IsValid)
            {
                var CustomerEntity = mapper.Map<CustomerBL>(customer);
                service.UpdateCustomer(CustomerEntity);

                return RedirectToAction("Index");
            }
            else 
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id) 
        {
            try
            {
                var CustomerEntity = service.FindById(Id);
                var Customer = mapper.Map<CustomerPL>(CustomerEntity);

                return View(Customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public IActionResult Delete(CustomerPL customer) 
        {
            return View();
        }
    }
}