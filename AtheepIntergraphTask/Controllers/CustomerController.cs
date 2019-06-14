using AtheepIntergraphTask.Models;
using AtheepIntergraphTask.Repositories;
using AtheepIntergraphTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtheepIntergraphTask.Controllers
{
    public class CustomerController : Controller
    {
        CustomerService _customerService;
        CompanyService _companyService;
        public CustomerController()
        {
            _customerService = new CustomerService();
            _companyService = new CompanyService();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _customerService.FindAll();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerService.GetById(id);
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var customer = new CustomerModel();
            var companies = _companyService.FindAll();

            List<SelectListItem> items = companies.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.ID.ToString(),
                    Selected = false
                };
            });
            customer.Companies = items;
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerModel customer)
        {
            try
            {
                // TODO: Add insert logic here
                _customerService.Add(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetById(id);
            var companies = _companyService.FindAll();

        List<SelectListItem> items = companies.ConvertAll(a =>
        {
            return new SelectListItem()
            {
                Text = a.Name,
                Value = a.ID.ToString(),
                Selected = false
            };
        });
            customer.Companies = items;
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerModel customer)
        {
            try
            {
                // TODO: Add update logic here
                _customerService.Update(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _customerService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
