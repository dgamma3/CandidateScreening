using CandidateScreening.Data;
using CandidateScreening.Data.Entities;
using CandidateScreening.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateScreening.Controllers
{
    public class HomeController : Controller
    {
        public int PageSize = 100;
        static CandidateScreeningContext context;
        public HomeController()
        {
            HomeController.context = new CandidateScreeningContext();

        }

        public ActionResult Add()
        {
          
            return View(new PatientViewModel());
        }
      
        [HttpPost]
        public ViewResult Add(PatientViewModel patientDetails)
        {
            if (ModelState.IsValid)
            {
                var highestIndex = HomeController.context.Patients.Max(x => x.Index);
                HomeController.context.Patients.Add(new Patient() {
                   DateOfBirth = patientDetails.DateOfBirth,
                   Email = patientDetails.Email,
                   Gender = patientDetails.Gender,
                   Firstname = patientDetails.Firstname,
                   Surname = patientDetails.Surname,
                   Created = DateTime.Now,
                   Index = highestIndex+1
                });             
                
                context.SaveChanges();
          
                return View("Completed");
            }
            else
            {
                return View(patientDetails);
            }
        }

        public ViewResult List(int page = 1, string message =null, string search = null) 
        {
            var Patients = HomeController.context.Patients.ToArray();
            if(search != null)
            {
                Patients = Patients.Where(x => x.Firstname.Contains(search)).ToArray() ;
            }
            CandidateScreening.Models.ProductListViewModel model = new ProductListViewModel
            {
                Products = Patients.OrderBy(p => p.Id).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = Patients.Count()
                }
            };
            if(message != null)
            {
                ViewBag.Message = message;
            }
            return View(model);
        }

        public ActionResult PatientInfo(int id)
        {
            var patient = HomeController.context.Patients.SingleOrDefault(x => x.Id == id);

            if (patient == null)   return RedirectToAction("List", new { message = "Invalid patient ID" });

            return View(new PatientViewModel
            {
                Firstname = patient.Firstname,
                Surname = patient.Surname,
                DateOfBirth = patient.DateOfBirth,
                Email = patient.Email,
                Gender = patient.Gender
            });
        }
    }
}