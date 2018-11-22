using Kendo.Mvc.Extensions;
using StazTestApp.DAL;
using StazTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StazTestApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            DBContext tmpDB = Session["DB"] as DBContext;
            if (Session["DB"] == null)
            {
                Session["DB"] = new DBContext();
                tmpDB = Session["DB"] as DBContext;
            }
            return View(tmpDB.GetList());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Przedmiot newPrzedmiot)
        {
            DBContext tmpDB = Session["DB"] as DBContext;
            if (ModelState.IsValid)
            {
                tmpDB.AddToList(newPrzedmiot);
                RouteValueDictionary rV = this.GridRouteValues();
                return RedirectToAction("Index", rV);
            }
            Session["DB"] = tmpDB;
            return View("Index", tmpDB.GetList());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update(Przedmiot newPrzedmiot)
        {
            DBContext tmpDB = Session["DB"] as DBContext;
            if (ModelState.IsValid)
            {
                tmpDB.UpdateExisting(newPrzedmiot);
                RouteValueDictionary rV = this.GridRouteValues();

                return RedirectToAction("Index", rV);
            }
            Session["DB"] = tmpDB;
            return View("Index", tmpDB.GetList());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Destroy(Przedmiot tmpPrzedmiot)
        {
            DBContext tmpDB = Session["DB"] as DBContext;
            tmpDB.RemoveFromList(tmpPrzedmiot.ItemID);

            RouteValueDictionary routeValues = this.GridRouteValues();
            Session["DB"] = tmpDB;
            return RedirectToAction("Index", routeValues);
        }
    }
}