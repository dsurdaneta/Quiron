using Quiron_Medical.Models.DAL;
using Quiron_Medical.Models.Geography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Quiron_Medical.Controllers
{
    public class CitiesController : Controller
    {
        QuironContext context = new QuironContext();
        // GET: Cities
        [ChildActionOnly()]
        public PartialViewResult _GetForState(long StateID)
        {
            ViewBag.StateID = StateID;
            List<City> cities = context.Cities.Where(x => x.StateID == StateID).ToList();
            return PartialView("_GetForState", cities);
        }

        // GET: Cities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = context.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        public ActionResult BackToState(long? StateID)
        {
            return Redirect("~/States/Details/" + StateID);
        }
    }
}