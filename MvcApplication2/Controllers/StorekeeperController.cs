using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DAO;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class StorekeeperController : Controller
    {
        WholesaleEntities we = new WholesaleEntities();
        StorekeeperDAO store = new StorekeeperDAO();
        //
        // GET: /Storekeeper/
        [Authorize(Roles = "Storekeeper")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Storekeeper/SelectMaterial
        public ActionResult SelectMaterial()
        {
            return View(store.selectAllMaterial());
        }
        //
        // GET: /Storekeeper/Edit/5

        public ActionResult EditMaterial(int IdMaterial)
        {
            return View(store.selectMaterial(IdMaterial));
        }

        //
        // POST: /Storekeeper/Edit/5

        [HttpPost]
        public ActionResult EditMaterial(int IdMaterial, Material material)
        {
            try
            {
                if (store.updateMaterial(material))
                    return RedirectToAction("SelectMaterial");
                else
                    return View("EditMaterial");
            }
            catch
            {
                return View("EditMaterial");
            }
        }
        //
        // GET: /Storekeeper/CreateOrders
        public ActionResult CreateOrders()
        {
            Orders or = new Orders();
            ViewBag.Material = we.Material.ToList();
            return View(or);
        }

        //
        // POST: /Storekeeper/CreateOrders

        [HttpPost]
        public ActionResult CreateOrders(Orders or, int[] mat)
        {
            try
            {
                if (store.insertOrders(or, mat))
                {
                    return Redirect("SelectMaterial");
                }
                else
                    return RedirectToAction("CreateOrders");
            }
            catch
            {
                return View("SelectMaterial");
            }
        }

        //
        // GET: /Storekeeper/CreateOperation
        public ActionResult CreateOperation()
        {
            Operation op = new Operation();
            ViewBag.Material = we.Material.ToList();
            return View(op);
        }

        //
        // POST: /Storekeeper/CreateOperation

        [HttpPost]
        public ActionResult CreateOperation(Operation op, int[] ma)
        {
            try
            {
                if (store.insertOperation(op, ma))
                {
                    return Redirect("SelectMaterial");
                }
                else
                { return RedirectToAction("CreateOperation"); }
            }
            catch
            {
                return View("SelectMaterial");
            }
        }
    }
}
