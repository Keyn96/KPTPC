using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.DAO;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        WholesaleEntities we = new WholesaleEntities();
        AdminDAO adm = new AdminDAO();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Authorize(Roles = "Admin")]
        // GET: /Admin/
        public ActionResult Index()
        {
            logger.Debug("Debug Message 1");
            return View();
        }
        // GET: /Admin/

        public ActionResult SelectWorker()
        {
            logger.Debug("PLINQ");
            return View(adm.selectAllWorkers());
        }
        //
        // GET: /Admin/Details/5

        public ActionResult DetailsWorker(int IdWorker)
        {
            return View(adm.selectWorker(IdWorker));
        }


        //
        // GET: /Admin/Edit/5

        public ActionResult EditWorker(int IdWorker)
        {
            return View(adm.selectWorker(IdWorker));
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditWorker(Workers w)
        {
            try
            {
                if (adm.updateWorker(w))
                    return RedirectToAction("SelectWorker");
                else
                    return View("EditWorker");
            }
            catch
            {
                return View("EditWorker");
            }
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult DeleteWorker(int idWorker)
        {
            return View(adm.selectWorker(idWorker));
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult DeleteWorker(int idWorker, Workers w)
        {
            try
            {
                if (adm.deleteWorker(idWorker))
                    return RedirectToAction("SelectWorker");
                else
                    return View("DeleteWorker");
            }
            catch
            {
                return View("DeleteWorker");
            }
        }

        //Material
        public ActionResult SelectMaterial()
        {
            logger.Debug("LINQ");
            return View(adm.selectAllMaterial());
        }
        //
        // GET: /Admin/Details/5

        public ActionResult DetailsMaterial(int IdMaterial)
        {
            return View(adm.selectMaterial(IdMaterial));
        }

        //
        // GET: /Admin/Create

        public ActionResult CreateMaterial()
        {
            Material m = new Material();
            return View(m);
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult CreateMaterial(Material m, ICollection<Operation> Operation, ICollection<Orders> Orders)
        {
            try
            {
                if (adm.insertMaterial(m, Operation, Orders))
                {
                    return Redirect("SelectMaterial");
                }
                else
                    return RedirectToAction("CreateMaterial");
            }
            catch
            {
                return View("SelecMaterial");
            }
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult EditMaterial(int IdMaterial)
        {
            return View(adm.selectMaterial(IdMaterial));
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult EditMaterial(Material m)
        {
            try
            {
                if (adm.updateMaterial(m))
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
        // GET: /Admin/Delete/5

        public ActionResult DeleteMaterial(int IdMaterial)
        {
            return View(adm.selectMaterial(IdMaterial));
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult DeleteMaterial(int IdMaterial, Material m)
        {
            try
            {
                if (adm.deleteMaterial(IdMaterial))
                    return RedirectToAction("SelectMaterial");
                else
                    return View("DeleteMaterial");
            }
            catch
            {
                return View("DeleteMaterial");
            }
        }
    }
}
