using Evolent.Web.Models;
using Evolent.Web.Services.Interface;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Evolent.Web.Controllers
{
    /// <summary>
    /// <see cref="HomeController"/> class which inherits <see cref="Controller"/> class.
    /// </summary>
    public class HomeController : Controller
    {

        #region Private variable
        private readonly IContactServices _contactServices;
        #endregion

        #region Constructor

        public HomeController(IContactServices contactServices)
        {
            _contactServices = contactServices;
        }
        #endregion


        #region Methods
        // GET: Home
        public ActionResult Contact()
        {
            List<VMContact> Contacts = _contactServices.GetContacts();
            return View(Contacts);

            //return View();
        }

        public ActionResult Add()
        {
            return PartialView();
        }

        // POST: Home/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(VMContact model)
        {
            if (ModelState.IsValid)
            {
                int result = _contactServices.CreateContact(model);
                if (result > 0)
                {
                    return Json(new { Status = "0", Message = "Data inserted  sucessfully." }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { Status = "1", Message = "Error Occur during processing." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                ModelState.AddModelError("", "");
                return Json(new { Status = "101", Message = "Enter Valid data" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            VMContact Contacts = null;
            try
            {
                Contacts = _contactServices.GetContactById(id);


            }
            catch (Exception)
            {

            }

            return PartialView(Contacts);

        }

        // POST: Home/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMContact model, int id)
        {
            if (ModelState.IsValid)
            {

                int result = _contactServices.UpdateContact(model);
                if (result > 0)
                {
                    return Json(new { Status = "0", Message = "Data inserted  sucessfully." }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { Status = "1", Message = "Error Occur during processing." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                ModelState.AddModelError("", "");
                return Json(new { Status = "101", Message = "Enter Valid data" }, JsonRequestBehavior.AllowGet);
            }
        }

        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int result = _contactServices.DeleteContact(id);

            if (result > 0)
            {
                return Json(new { Status = "0", Message = "Data deleted  sucessfully." }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { Status = "1", Message = "Error Occur during processing." }, JsonRequestBehavior.AllowGet);
            }
            
        }
        #endregion
    }
}