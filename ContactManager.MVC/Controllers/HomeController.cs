using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using ContactManager.MVC.Models;
using Demo.Model;

namespace ContactManager.MVC.Controllers
{
    public class HomeController : Controller
    {
        ContactManagerDBEntities db = new ContactManagerDBEntities();
       

        public ActionResult Index()
        {
           

             List<ContactsDetailsModel> listContactsDetailsModels = new List<ContactsDetailsModel>();
            var result = (
                from x in db.Contacts
                join y in db.ContactTypes on x.ContactTypeID equals y.ContactTypeID
                select new ContactsDetailsModel
                {
                    Ime = x.Ime,
                    LastName = x.LastName,
                    Address = x.Address,
                    InsertDate = x.InsertDate,
                    caption = y.Caption
                }).ToList();

            foreach (var item in result)
                listContactsDetailsModels.Add(new ContactsDetailsModel
                {
                    Ime = item.Ime,
                    LastName = item.LastName,
                    Address = item.Address,
                    InsertDate = item.InsertDate,
                    caption = item.caption
                });
            return View(listContactsDetailsModels);
        }




       //ZA CREATE NEW DA VRATI VIEW *GET*
       [HttpGet]
       public ActionResult Create()
       {
            
           return View();
       }
        //da posalje napravljen model *POST*
        [HttpPost]
        public ActionResult Create([Bind (Include = "ContactId,Ime,LastName,Address,InserDate,caption")]ContactsDetailsModel contact)
        {


            if (ModelState.IsValid)
            {
                
            }
            return View();

        }






        public ActionResult Details()
        {
            
            return View();
        }





        //EDIT *GET*
        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(id);
        }
        //EDIT *POST*
        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }



        public ActionResult Delete(string id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            return View();
        }

        public ActionResult DeleteConfirmed()
        {
            return RedirectToAction("Index");
        }











        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}