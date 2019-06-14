using AtheepIntergraphTask.Models;
using AtheepIntergraphTask.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtheepIntergraphTask.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService _companyService;
        public CompanyController()
        {
            _companyService = new CompanyService();
        }
        // GET: Company
        public ActionResult Index()
        {
            var companies = _companyService.FindAll();
            return View(companies);
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            var company = _companyService.GetById(id);
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CompanyModel company)
        {
            try
            {

                var x = company.ImageFile.InputStream;
                byte[] b = System.IO.File.ReadAllBytes(company.ImageFile.FileName);
            

                // TODO: Add insert logic here
                _companyService.Add(company);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            var company = _companyService.GetById(id);
            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CompanyModel company)
        {
            try
            {
                // TODO: Add update logic here
                _companyService.Update(company);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            var company = _companyService.GetById(id);
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _companyService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
