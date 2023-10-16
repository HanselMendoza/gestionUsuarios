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
    public class TBENTRADAsController : Controller
    {
        private DBENTRYTRAKYNGEntities db = new DBENTRYTRAKYNGEntities();

        // GET: TBENTRADAs
        public ActionResult Index()
        {
            var tBENTRADAs = db.TBENTRADAs.Include(t => t.TBDEPARTAMENTO).Include(t => t.TBMOTIVOENTRADA).Include(t => t.TBOCUPACION);
            return View(tBENTRADAs.ToList());
        }

        // GET: TBENTRADAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            if (tBENTRADA == null)
            {
                return HttpNotFound();
            }
            return View(tBENTRADA);
        }

        // GET: TBENTRADAs/Create
        public ActionResult Create()
        {
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE");
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION");
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE");
            return View();
        }

        // POST: TBENTRADAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDENTRADA,IDDEPART,IDOCUPACION,IDMOTIVOENTRADA,CEDULA,NOMBRES,APELLIDOS,FECHAENTRADA,TiempoESTIMADO,TENIACITA")] TBENTRADA tBENTRADA)
        {
            if (ModelState.IsValid)
            {
                db.TBENTRADAs.Add(tBENTRADA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE", tBENTRADA.IDDEPART);
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION", tBENTRADA.IDMOTIVOENTRADA);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            return View(tBENTRADA);
        }

        // GET: TBENTRADAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            if (tBENTRADA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE", tBENTRADA.IDDEPART);
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION", tBENTRADA.IDMOTIVOENTRADA);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            return View(tBENTRADA);
        }

        // POST: TBENTRADAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDENTRADA,IDDEPART,IDOCUPACION,IDMOTIVOENTRADA,CEDULA,NOMBRES,APELLIDOS,FECHAENTRADA,TiempoESTIMADO,TENIACITA")] TBENTRADA tBENTRADA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBENTRADA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDEPART = new SelectList(db.TBDEPARTAMENTOes, "IDDEPARTM", "NOMBRE", tBENTRADA.IDDEPART);
            ViewBag.IDMOTIVOENTRADA = new SelectList(db.TBMOTIVOENTRADAs, "IDMOTIVOENTRADA", "DESCRIPCION", tBENTRADA.IDMOTIVOENTRADA);
            ViewBag.IDOCUPACION = new SelectList(db.TBOCUPACIONs, "IDOCUPACION", "NOMBRE", tBENTRADA.IDOCUPACION);
            return View(tBENTRADA);
        }

        // GET: TBENTRADAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            if (tBENTRADA == null)
            {
                return HttpNotFound();
            }
            return View(tBENTRADA);
        }

        // POST: TBENTRADAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBENTRADA tBENTRADA = db.TBENTRADAs.Find(id);
            db.TBENTRADAs.Remove(tBENTRADA);
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
