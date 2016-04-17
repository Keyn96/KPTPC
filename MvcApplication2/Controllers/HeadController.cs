using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DAO;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class HeadController : Controller
    {
        WholesaleEntities we = new WholesaleEntities();
        HeadDAO head = new HeadDAO();
        //
        // GET: /Head/
        [Authorize(Roles = "Head")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Head/SelectOrders

        public ActionResult SelectOrders()
        {
            return View(head.selectAllOrders());
        }
        //
        // GET: /Head/SelectOperation

        public ActionResult SelectOperation()
        {
            return View(head.selectAllOperation());
        }
        //
        // GET: /Head/Details/5

        public ActionResult DetailsOrders(int IdOrder)
        {
            return View(head.selectOrders(IdOrder));
        }

        //
        // GET: /Head/Details/5

        public ActionResult DetailsOperation(int IdOperation)
        {
            return View(head.selectOperation(IdOperation));
        }



        //
        // GET: /Head/Edit/5

        public ActionResult EditOrder(int IdOrder)
        {
            return View(head.selectOrders(IdOrder));
        }

        //
        // POST: /Head/Edit/5

        [HttpPost]
        public ActionResult EditOrder(Orders order)
        {
            try
            {
                if (head.updateOrders(order))
                    return RedirectToAction("SelectOrders");
                else
                    return View("EditOrder");
            }
            catch
            {
                return View("EditOrder");
            }
        }
    }
}
