using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Payohtee.Models.Customer;
using PayohteeWebApp.Properties;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Payohtee.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Lookup(string charinput)
        {
            var result = new Company().GetAsyncListCompanyName(charinput);
            var client = new RestClient
            {
                BaseUrl = new Uri(Resources.baseurlremote)

            };
            var request = new RestRequest
            {
                Resource = "/company/getlookup/" + charinput,
                Method = Method.GET

            };
            //request.AddParameter("charinput", charinput);
            IRestResponse Iresponse = client.Execute(request);
            var response = Iresponse.Content;
            //var result = JsonConvert.DeserializeObject<List<String>>(response);


            //return Content(result.ToString());
            //return Content("Hi There");
            return Json(result);
        }

        // GET: Admin/Details/5
        public ActionResult Details(string companyname)
        {
            Company company = new Company();
            //var result = company.GetCompany("");

            //return Content(result.ToString());
            //return Content("Hi There");
            //return Json(result);
            return null;
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}