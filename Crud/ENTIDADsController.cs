using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MensajeriaTexto.Models;

namespace MensajeriaTexto.Controllers
{
    public class ENTIDADsController : Controller
    {
        private ModelMensajeTexto db = new ModelMensajeTexto();

        // GET: ENTIDADs
        public ActionResult Index()
        {
            try
            {   //pasa                
                if (Session["Id"] != null)
                    return View();
                else
                    return RedirectToAction("Login", "Home");
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Index", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }

        public ActionResult Lista()
        {
            try
            {   //pasa                
                return PartialView("Lista", db.ENTIDAD.Where(x => x.IDENTIDAD != 5).ToList());
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Lista", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }
        public ActionResult ListaEntidadesVer(decimal? tipo)
        {
            try
            {
                List<ENTIDAD> listaEntidad = null;

                if (tipo == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                ViewBag.VISTA = null;

                if (tipo == 1)
                {
                    ViewBag.VISTA = 1;
                }

                listaEntidad = db.ENTIDAD.Where(x => x.ESTADO == 1 && x.IDENTIDAD != 5).ToList();

                //pasa                
                return PartialView("ListaEntidadesVer", listaEntidad);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-ListaEntidadesVer", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }

        public ActionResult ListaEntidadesPantalla(decimal? id)
        {
            try
            {
                List<ENTIDAD> listaEntidad = null;

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                listaEntidad = db.ENTIDAD.Where(x => x.CONFIGURACIONPUBLICIDAD.Where(p => p.IDPANTALLA == id).Count() != 0).ToList();
               
                return PartialView("ListaEntidadesPantalla", listaEntidad);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-ListaEntidadesPantalla", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }
        // GET: ENTIDADs/Details/5
        public ActionResult Details(decimal? id)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                return PartialView("Details", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Details", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }
        public ActionResult sidebar(decimal? id)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                return PartialView("sidebar", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-sidebar", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }

        public ActionResult Paute()
        {
                return View();
        }


        public ActionResult topBar(decimal? id, int mostrar)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                ViewBag.mostrar = mostrar;
                return PartialView("topBar", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-topBar", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }
        public ActionResult Logo(decimal? id)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                return PartialView("Logo", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Logo", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }

        public ActionResult LogoTablet(decimal? id)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                return PartialView("LogoTablet", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Logo", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }


        public ActionResult ProductoEntidad(decimal? id)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                decimal idPantalla = this.veificarIdpantalla();

                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }


                CONFIGURACIONPUBLICIDAD objConfi = db.CONFIGURACIONPUBLICIDAD.Where(x => x.CENTRO == 1 && x.IDENTIDAD == id && x.ESTADO == 1 && x.IDPANTALLA == idPantalla).FirstOrDefault();

                int tipoVista = objConfi.TIPOVISTA.Value;

                switch (tipoVista)
                {
                    case 1: return PartialView("Vista1E", objConfi);
                    case 2: return PartialView("Vista2E", objConfi);
                    case 4: return PartialView("Vista4E", objConfi);
                }

                return PartialView("Vista6E", objConfi);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Logo", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }


        public ActionResult LogosEntidad()
        {
            decimal idPantalla = this.veificarIdpantalla();
            if (idPantalla == 0)
            {
                return new ContentResult() { Content = "Error" };
            }

            var Entidad = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.ESTADO == 1 && x.IDENTIDAD != 5 && x.IDPANTALLA == idPantalla).ToList();

            return PartialView("LogosEntidad", Entidad);
        }



        public ActionResult VistaProd(List<EFECTOPUBLICIDAD> lista, decimal id)
        {
            ViewBag.IDENTIDAD = id;

            return PartialView("VistaProd", lista);
        }

        public ActionResult CargarLogica(decimal? id, int Index)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }

                decimal idPantalla = this.veificarIdpantalla();
                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }


                string efectoCentro = "";
                int tiempo = 10, tipoAR = 0, fullPantalla = 0,bonos=0 ;

                try
                {
                    try
                    {
                        efectoCentro = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id).FirstOrDefault().EFECTO.DESCRIPCION;
                    }
                    catch (Exception e) { }
                    try
                    {
                        tiempo = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id).FirstOrDefault().TIEMPO.Value;
                    }
                    catch (Exception e) { }

                    int OBJAR = 0, PRODAR = 0, FACEAR = 0;

                    try
                    {
                        OBJAR = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla &&  x.IDENTIDAD == id && x.AROBJ3D == 1 && x.EFECTOPUBLICIDAD.Where(a => a.ESTADO == 1 && a.TIPOPRODUCTO == 4).Count() > 0).FirstOrDefault().AROBJ3D.Value;
                    }
                    catch (Exception e) { }
                    try
                    {
                        PRODAR = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id && x.ARPRODUCTO == 1 && x.EFECTOPUBLICIDAD.Where(a => a.ESTADO == 1 && a.TIPOPRODUCTO == 2).Count() > 0).FirstOrDefault().ARPRODUCTO.Value;
                    }
                    catch (Exception e) { }
                    try
                    {
                        FACEAR = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id && x.ARFACE == 1 && x.EFECTOPUBLICIDAD.Where(a => a.ESTADO == 1 && a.TIPOPRODUCTO == 3).Count() > 0).FirstOrDefault().ARFACE.Value;
                    }
                    catch (Exception e) { }


                    try
                    {
                        fullPantalla = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id ).FirstOrDefault().FULLPANTALLA.Value;
                    }
                    catch (Exception e) { }


                    try
                    {
                        bonos = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id).FirstOrDefault().BONOS.Value;
                    }
                    catch (Exception e) { }


                    if (PRODAR == 1)
                    {
                        tipoAR = 2;
                    }
                    if (FACEAR == 1)
                    {
                        tipoAR = 3;
                    }
                    if (OBJAR == 1)
                    {
                        tipoAR = 4;
                    }
                    if (bonos==1)
                    {
                        tipoAR = 5;
                    }
                }
                catch (Exception e) { }

     
                ViewBag.FULLPANTALLA = fullPantalla;
                ViewBag.Index = Index;
                ViewBag.EFECCEN = efectoCentro;
                ViewBag.TIEMPO = tiempo;
                ViewBag.TIPOAR = tipoAR;

                return PartialView("CargarLogica", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Logo", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }



        public ActionResult FaceAR(decimal? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }

                decimal idPantalla = this.veificarIdpantalla();
                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }




                return PartialView("FaceAR", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-FaceAR", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }


        public ActionResult ProdAR(decimal? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }

                decimal idPantalla = this.veificarIdpantalla();
                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }

                List<EFECTOPUBLICIDAD> ListaItemPro = new List<EFECTOPUBLICIDAD>();
                try
                {
                  var  ListaCofig = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id && x.ARPRODUCTO == 1).FirstOrDefault().EFECTOPUBLICIDAD.ToList();

                    ListaItemPro = ListaCofig.Where(a => a.ESTADO == 1 && a.TIPOPRODUCTO == 2).ToList();
                }
                catch (Exception e) { }

 
                return PartialView("ProdAR", ListaItemPro);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-ProdAR", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }

        public ActionResult Obj3D(decimal? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }

                decimal idPantalla = this.veificarIdpantalla();
                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }

                List<EFECTOPUBLICIDAD> ListaItemPro = new List<EFECTOPUBLICIDAD>();
                try
                {
                    var ListaCofig = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.IDPANTALLA == idPantalla && x.IDENTIDAD == id && x.AROBJ3D==1).FirstOrDefault().EFECTOPUBLICIDAD.ToList();

                    ListaItemPro = ListaCofig.Where(a => a.ESTADO == 1 && a.TIPOPRODUCTO == 4).ToList();
                }
                catch (Exception e) { }


                return PartialView("Obj3D", ListaItemPro);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Obj3D", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }


        public ActionResult Bonos(decimal? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }

                decimal idPantalla = this.veificarIdpantalla();
                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }
                return PartialView();
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Bonos", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }

        public ActionResult LogicaNueva(int id)
        {
            try
            {
                decimal idPantalla = this.veificarIdpantalla();
                if (idPantalla == 0)
                {
                    return new ContentResult() { Content = "Error" };
                }

                var Entidad = db.CONFIGURACIONPUBLICIDAD.Where(x => x.ESTADO == 1 && x.CENTRO == 1 && x.ESTADO == 1 && x.IDENTIDAD != 5 && x.IDPANTALLA == idPantalla).ToList();

                id++;
                if (id >= Entidad.Count())
                    id = 0;
                return this.CargarLogica(Entidad[id].IDENTIDAD, id);

            }
            catch (Exception e)
            {
                return new ContentResult() { Content = "Error" };
            }
        }



        public ActionResult LogicaPlantillaTablet(int id)
        {
            try
            {
                var Entidad = db.ENTIDAD.Where(x => x.ESTADO == 1 && x.IDENTIDAD != 5).ToList();
                id++;
                if (id == Entidad.Count())
                    id = 0;
                return this.CargarLogicaTablet(Entidad[id].IDENTIDAD, id);
            }
            catch (Exception e)
            {
                return RedirectToAction("tienda", "Home");
            }
        }

        public ActionResult CargarLogicaTablet(decimal? id, int Index)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Index = Index;
                return PartialView("CargarLogicaTablet", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Logo", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }
        }

        public ActionResult Create()
        {
            try
            {   //pasa                        
                return PartialView("Create");
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Create", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDENTIDAD,RAZONSOCIAL,NIT,DIRECCION,TELEFONO,CORREOELECTRONICO,ESTADO,TIEMPO,CODIGOCOLOR,CODIGOCOLORLETRA")] ENTIDAD eNTIDAD, double Membresia, int Mensajes)
        {
            try
            {   //pasa                
                if (ModelState.IsValid)
                {
                    db.ENTIDAD.Add(eNTIDAD);
                    db.SaveChanges();
                    AFILIACION Afi = new AFILIACION();
                    Afi.IDENTIDAD = eNTIDAD.IDENTIDAD;
                    Afi.ESTADO = 0;
                    Afi.VALOR = Membresia;
                    db.AFILIACION.Add(Afi);
                    PAQUETEMENSAJE paquete = new PAQUETEMENSAJE();
                    paquete.CANTIDAD = Mensajes;
                    paquete.CANTIDADVARIABLE = Mensajes;
                    paquete.IDENTIDAD = eNTIDAD.IDENTIDAD;
                    paquete.ESTADO = 0;
                    paquete.IDPLAN = 9;
                    paquete.FECHACOMPRA = DateTime.Now;
                    db.PAQUETEMENSAJE.Add(paquete);
                    db.SaveChanges();
                    return new ContentResult() { Content = "Creado" };
                }
                return PartialView("Create", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Create", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Paute([Bind(Include = "IDENTIDAD,RAZONSOCIAL,NIT,DIRECCION,TELEFONO,CORREOELECTRONICO,ESTADO,TIEMPO,CODIGOCOLOR,CODIGOCOLORLETRA")] ENTIDAD eNTIDAD)
        {
            try
            {   //pasa                
                if (ModelState.IsValid)
                {
                    db.ENTIDAD.Add(eNTIDAD);
                    db.SaveChanges();
                }

                ViewBag.ALERTA = "Creado exitosamente! pronto nos comunicaremos contigo";
                return PartialView("Create", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Create", e.ToString());
                log.CrearLog();
                ViewBag.ALERTA = "Error!!";
                return PartialView("Create", eNTIDAD);
            }

        }

        public ActionResult Edit(decimal? id)
        {
            try
            {   //pasa                
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
                if (eNTIDAD == null)
                {
                    return HttpNotFound();
                }
                return PartialView("Edit", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Edit", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDENTIDAD,RAZONSOCIAL,NIT,DIRECCION,TELEFONO,CORREOELECTRONICO,ESTADO,TIEMPO,CODIGOCOLOR,CODIGOCOLORLETRA")] ENTIDAD eNTIDAD)
        {
            try
            {   //pasa                
                if (ModelState.IsValid)
                {
                    db.Entry(eNTIDAD).State = EntityState.Modified;
                    db.SaveChanges();
                    return new ContentResult() { Content = "Editado" };
                }
                return PartialView("Edit", eNTIDAD);
            }
            catch (Exception e)
            {
                Log log = new Log("ENTIDADsController-Edit", e.ToString());
                log.CrearLog();
                return new ContentResult() { Content = "Error" };
            }

        }


        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
            if (eNTIDAD == null)
            {
                return HttpNotFound();
            }
            return View(eNTIDAD);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ENTIDAD eNTIDAD = db.ENTIDAD.Find(id);
            db.ENTIDAD.Remove(eNTIDAD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public decimal veificarIdpantalla()
        {
            decimal idPantalla = 0;

            if (Session["IDPANTALLA"] != null)
            {
                idPantalla = (decimal)Session["IDPANTALLA"];
            }
            return idPantalla;
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
