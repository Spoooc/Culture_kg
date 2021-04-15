using Culture_kg.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Culture_kg.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager dataManager;

        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.ServiceItems.GetServiceItems());
        }

        //public IActionResult CategoryShow(Guid id)
        //{
        //    var cat=dataManager.ServiceItems.
        //    if()
        //}


    }
}
