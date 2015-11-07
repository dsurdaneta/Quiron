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
    public class StatesController : Controller
    {
        QuironContext context = new QuironContext();

        // GET: States
        [ChildActionOnly()]
        public PartialViewResult _GetForCountry(long CountryID)
        {
            ViewBag.CountryID = CountryID;
            List<State> states = context.States.Where(x => x.CountryID == CountryID).ToList();
            return PartialView("_GetForCountry", states);
        }

        // GET: States/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            State state = context.States.Find(id);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        public ActionResult BackToCountry(long? CountryID)
        {
            return Redirect("~/Countries/Details/" + CountryID);
        }
    }
}