using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PROYECTOMVC.Models;

namespace PROYECTOMVC.Controllers
{
    public class VENTAsController : Controller
    {
        private NEGOCIOEntities db = new NEGOCIOEntities();

        // GET: VENTAs
        public ActionResult Index()
        {
            var vENTA = db.VENTA.Include(v => v.PRODUCTO);
            return View(vENTA.ToList());
        }

        // GET: VENTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // GET: VENTAs/Create
        public ActionResult Create()
        {
            ViewBag.REF_PRODUCTO1 = new SelectList(db.PRODUCTO, "REF_PRODUCTO", "NOM_PRODUCTO");
            return View();
        }

        // POST: VENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NUM_VENTA,REF_PRODUCTO1,MEDIO_PAGO")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.VENTA.Add(vENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.REF_PRODUCTO1 = new SelectList(db.PRODUCTO, "REF_PRODUCTO", "NOM_PRODUCTO", vENTA.REF_PRODUCTO1);
            return View(vENTA);
        }

        // GET: VENTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.REF_PRODUCTO1 = new SelectList(db.PRODUCTO, "REF_PRODUCTO", "NOM_PRODUCTO", vENTA.REF_PRODUCTO1);
            return View(vENTA);
        }

        // POST: VENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NUM_VENTA,REF_PRODUCTO1,MEDIO_PAGO")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.REF_PRODUCTO1 = new SelectList(db.PRODUCTO, "REF_PRODUCTO", "NOM_PRODUCTO", vENTA.REF_PRODUCTO1);
            return View(vENTA);
        }

        // GET: VENTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: VENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            db.VENTA.Remove(vENTA);
            db.SaveChanges();
            return RedirectToAction("Index");
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
