using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TBDEPARTAMENTOesController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: TBDEPARTAMENTOes
        public ActionResult Index()
        {
            var tBDEPARTAMENTOes = db.TBDEPARTAMENTOes.Include(t => t.TBCOORDENADA).Include(t => t.TBESTADO).Include(t => t.TBPISO);
            return View(tBDEPARTAMENTOes.ToList());
        }

        // GET: TBDEPARTAMENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBDEPARTAMENTO tBDEPARTAMENTO = db.TBDEPARTAMENTOes.Find(id);
            if (tBDEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBDEPARTAMENTO);
        }

        // GET: TBDEPARTAMENTOes/Create
        public ActionResult Create()
        {
            ViewBag.IDCOORD = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE");
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE");
            ViewBag.IDPISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE");
            return View();
        }

        // POST: TBDEPARTAMENTOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDEPARTM,IDESTADO,IDPISO,IDCOORD,NOMBRE,DESCRIPCION")] TBDEPARTAMENTO tBDEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TBDEPARTAMENTOes.Add(tBDEPARTAMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCOORD = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE", tBDEPARTAMENTO.IDCOORD);
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBDEPARTAMENTO.IDESTADO);
            ViewBag.IDPISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE", tBDEPARTAMENTO.IDPISO);
            return View(tBDEPARTAMENTO);
        }

        // GET: TBDEPARTAMENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBDEPARTAMENTO tBDEPARTAMENTO = db.TBDEPARTAMENTOes.Find(id);
            if (tBDEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCOORD = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE", tBDEPARTAMENTO.IDCOORD);
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBDEPARTAMENTO.IDESTADO);
            ViewBag.IDPISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE", tBDEPARTAMENTO.IDPISO);
            return View(tBDEPARTAMENTO);
        }

        // POST: TBDEPARTAMENTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDEPARTM,IDESTADO,IDPISO,IDCOORD,NOMBRE,DESCRIPCION")] TBDEPARTAMENTO tBDEPARTAMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBDEPARTAMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCOORD = new SelectList(db.TBCOORDENADAs, "IDCOORDENADA", "NOMBRE", tBDEPARTAMENTO.IDCOORD);
            ViewBag.IDESTADO = new SelectList(db.TBESTADOes, "IDESTADO", "NOMBRE", tBDEPARTAMENTO.IDESTADO);
            ViewBag.IDPISO = new SelectList(db.TBPISOes, "IDPISO", "NOMBRE", tBDEPARTAMENTO.IDPISO);
            return View(tBDEPARTAMENTO);
        }

        // GET: TBDEPARTAMENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBDEPARTAMENTO tBDEPARTAMENTO = db.TBDEPARTAMENTOes.Find(id);
            if (tBDEPARTAMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tBDEPARTAMENTO);
        }

        // POST: TBDEPARTAMENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBDEPARTAMENTO tBDEPARTAMENTO = db.TBDEPARTAMENTOes.Find(id);
            db.TBDEPARTAMENTOes.Remove(tBDEPARTAMENTO);
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
