using PlanetaApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace PlanetaApp.Controllers
{
    public class ActividadController : Controller
    {

        private ModelPlanetaApp db = new ModelPlanetaApp();

        public ActionResult Index()
        {
            if (verificar() == 0)
            { return RedirectToAction("Login", "Home"); }

            return View();
        }

        public ActionResult Lista()
        {
            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }

            return PartialView(db.ACTIVIDADs.ToList());
        }




  
        public ActionResult Details(decimal? id)
        {
            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }


            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
               ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);

                if (aCTIVIDAD == null)
                {
                    return HttpNotFound();
                }

                return PartialView(aCTIVIDAD);

            }
            catch (Exception e)
            {
                Log log = new Log("Actividad-Details", e.ToString());
                log.CrearLog();
            }
            return new ContentResult() { Content = "Error" };
        }



        public ActionResult Estructura()
        {
            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }
            return View();
        }



        public ActionResult Create()
        {
            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }

            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDACTIVIDAD,DESCRIPCION,NOMBRE,PRESUPUESTO,ESTADO,FECHA_INICIAL,FECHA_FINAL")] ACTIVIDAD aCTIVIDAD)
        {

            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }


            try
            {
                if (ModelState.IsValid)
                {
                    aCTIVIDAD.ESTADO = 1;
                    db.ACTIVIDADs.Add(aCTIVIDAD);
                    db.SaveChanges();
                    return new ContentResult() { Content = "Creado" };
                }
            }
            catch (Exception e)
            {
                Log log = new Log("Actividad-Create", e.ToString());
                log.CrearLog();
            }
            return new ContentResult() { Content = "Error" };

        }


        public ActionResult Edit(decimal? id)
        {
            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ACTIVIDAD aCTIVIDAD = db.ACTIVIDADs.Find(id);

                if (aCTIVIDAD == null)
                {
                    return HttpNotFound();
                }

                return PartialView(aCTIVIDAD);

            }
            catch (Exception e)
            {
                Log log = new Log("Actividad-Edit", e.ToString());
                log.CrearLog();
            }
            return new ContentResult() { Content = "Error" };
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDACTIVIDAD,DESCRIPCION,NOMBRE,PRESUPUESTO,ESTADO,FECHA_INICIAL,FECHA_FINAL")] ACTIVIDAD aCTIVIDAD)
        {

            if (verificar() == 0)
            { return new ContentResult() { Content = "Error" }; }


            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(aCTIVIDAD).State = EntityState.Modified;
                    db.SaveChanges();
                    return new ContentResult() { Content = "Editado" };
                }
            }
            catch (Exception e)
            {
                Log log = new Log("Actividad-Edit", e.ToString());
                log.CrearLog();
            }
            return new ContentResult() { Content = "Error" };
        }


        public int verificar()
        {
            if (Session["USUARIO"] == null)
            { return 0; }
            else
            { return 1; }

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
