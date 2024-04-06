using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sigapsWeb.Models;
using sigapsWeb.Shareds;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using sigapsWeb.Core.Response;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace sigapsWeb.Controllers
{
    public class AlertController : Controller
    {

        private readonly SigApsV2Context db;
        private GetFuncion fc;

        public AlertController(SigApsV2Context db)
        {
            this.db = db;
            fc = new GetFuncion();
        }


        public IActionResult Index()
        {
            if (Shared.verificarSession(HttpContext) == 0) { return RedirectToAction("login"); }
            return View();
        }
        public async Task<IActionResult> DataJson(int start = 0, int length = 2, string search = "", int draw = 1)
        {
            IQueryable<IsSegAlertas> query = db.IsSegAlertas;

            if (search != "" && search != null)
            {
                query = query.Where(x => x.Id.Contains(search));
            };

            GenericResponsePagination<IsSegAlertas> paginationFile = await GenericResponsePagination<IsSegAlertas>.CreateAsync(
                query
                , start, length, draw);

            return new JsonResult(paginationFile)
            {
                StatusCode = StatusCodes.Status201Created
            };
        }

        public async Task<IActionResult> Lista()
        {
            return PartialView();
        }
        public async Task<IActionResult> add()
        {
            return PartialView();
        }
        public IActionResult Create()
        {
            String[] Municipalityalert = SharedUser.Municipalities(HttpContext, db);


            var listUserAlert = (from pe in db.ConsultaAlertasCuidadoses
                                 where
                                 Municipalityalert.Contains(pe.IdMunicipio) &&
                               pe.AltTipoIdentificacion != "N" ||
                               pe.PlanTipoIdentificacion != "N" ||
                               pe.AltRegimenSaludPertenece != "N" ||
                               pe.PlanRegimenSaludPertenece != "N" ||
                               pe.AltVictAtnPsc != "N" ||
                               pe.PlanVictAtnPsc != "N" ||
                               pe.AltVictAtnSald != "N" ||
                               pe.PlanVictAtnSald != "N" ||
                               pe.AltDiscapacidad != "N" ||
                               pe.PlanDiscapacidad != "N" ||
                               pe.AltCerDiscapacidad != "N" ||
                               pe.PlanCerDiscapacidad != "N" ||
                               pe.AltSistemaRiesgo != "N" ||
                               pe.PlanSistemaRiesgo != "N" ||
                               pe.AltHoraTrabajo != "N" ||
                               pe.PlanHoraTrabajo != "N" ||
                               pe.AltInterfiereEscolar != "N" ||
                               pe.PlanInterfiereEscolar != "N" ||
                               pe.AltActividadExpFisico != "N" ||
                               pe.PlanActividadExpFisico != "N" ||
                               pe.AltActividadExpPsico != "N" ||
                               pe.PlanActividadExpPsico != "N" ||
                               pe.AltActividadExpBiolog != "N" ||
                               pe.PlanActividadExpBiolog != "N" ||
                               pe.AltActividadExpBiomec != "N" ||
                               pe.PlanActividadExpBiomec != "N" ||
                               pe.AltActividadExpQuimi != "N" ||
                               pe.PlanActividadExpQuimi != "N" ||
                               pe.AltActividadExpAltur != "N" ||
                               pe.PlanActividadExpAltur != "N" ||
                               pe.AltActividadExpLocat != "N" ||
                               pe.PlanActividadExpLocat != "N" ||
                               pe.AltActividadExpFennat != "N" ||
                               pe.PlanActividadExpFennat != "N" ||
                               pe.AltActividadElemento != "N" ||
                               pe.PlanActividadElemento != "N" ||
                               pe.AltProtCabeza != "N" ||
                               pe.PlanProtCabeza != "N" ||
                               pe.AltActuarEmergen != "N" ||
                               pe.PlanActuarEmergen != "N" ||
                               pe.AltDxOcupacion != "N" ||
                               pe.PlanDxOcupacion != "N" ||
                               pe.AltAccResOcupacion != "N" ||
                               pe.PlanAccResOcupacion != "N" ||
                               pe.AltMascotaVacunada != "N" ||
                               pe.PlanMascotaVacunada != "N" ||
                               pe.AltAlimCantAsucar != "N" ||
                               pe.PlanAlimCantAsucar != "N" ||
                               pe.AltBebCantAsucar != "N" ||
                               pe.PlanBebCantAsucar != "N" ||
                               pe.AltAlimCantSal != "N" ||
                               pe.PlanAlimCantSal != "N" ||
                               pe.AltAddSal != "N" ||
                               pe.PlanAddSal != "N" ||
                               pe.AltLactancia != "N" ||
                               pe.PlanLactancia != "N" ||
                               pe.AltDesparacitado != "N" ||
                               pe.PlanDesparacitado != "N" ||
                               pe.AltDxDiabetes != "N" ||
                               pe.PlanDxDiabetes != "N" ||
                               pe.AltDiabetesTratamiento != "N" ||
                               pe.PlanDiabetesTratamiento != "N" ||
                               pe.AltDiabetesControl != "N" ||
                               pe.PlanDiabetesControl != "N" ||
                               pe.AltDxHta != "N" ||
                               pe.PlanDxHta != "N" ||
                               pe.AltHtaTratamiento != "N" ||
                               pe.PlanHtaTratamiento != "N" ||
                               pe.AltHtaControl != "N" ||
                               pe.PlanHtaControl != "N" ||
                               pe.AltPresArResultado != "N" ||
                               pe.PlanPresArResultado != "N" ||
                               pe.AltAntCancer != "N" ||
                               pe.PlanAntCancer != "N" ||
                               pe.AltDxCancerTipo != "N" ||
                               pe.PlanDxCancerTipo != "N" ||
                               pe.AltDxCanLinfomas != "N" ||
                               pe.PlanDxCanLinfomas != "N" ||
                               pe.AltTiempoDxCan != "N" ||
                               pe.PlanTiempoDxCan != "N" ||
                               pe.AltDxCanTratamiento != "N" ||
                               pe.PlanDxCanTratamiento != "N" ||
                               pe.AltDxCanControl != "N" ||
                               pe.PlanDxCanControl != "N" ||
                               pe.AltDxImc != "N" ||
                               pe.PlanDxImc != "N" ||
                               pe.AltDxPerimetro != "N" ||
                               pe.PlanDxPerimetro != "N" ||
                               pe.AltFuma != "N" ||
                               pe.PlanFuma != "N" ||
                               pe.AltAntTabaco != "N" ||
                               pe.PlanAntTabaco != "N" ||
                               pe.AltExfumador != "N" ||
                               pe.PlanExfumador != "N" ||
                               pe.AltTiempoExfumador != "N" ||
                               pe.PlanTiempoExfumador != "N" ||
                               pe.AltActFisica != "N" ||
                               pe.PlanActFisica != "N" ||
                               pe.AltAcudeOdontologo != "N" ||
                               pe.PlanAcudeOdontologo != "N" ||
                               pe.AltIntercamCepillo != "N" ||
                               pe.PlanIntercamCepillo != "N" ||
                               pe.AltCepillaDia != "N" ||
                               pe.PlanCepillaDia != "N" ||
                               pe.AltIngiereCrema != "N" ||
                               pe.PlanIngiereCrema != "N" ||
                               pe.AltSaludBucal != "N" ||
                               pe.PlanSaludBucal != "N" ||
                               pe.AltFaltaDiente != "N" ||
                               pe.PlanFaltaDiente != "N" ||
                               pe.AltLimpiaProtesis != "N" ||
                               pe.PlanLimpiaProtesis != "N" ||
                               pe.AltTiempoProtesis != "N" ||
                               pe.PlanTiempoProtesis != "N" ||
                               pe.AltZonasEndemicas != "N" ||
                               pe.PlanZonasEndemicas != "N" ||
                               pe.AltPresentoTos != "N" ||
                               pe.PlanPresentoTos != "N" ||
                               pe.AltAntDxTuberculosis != "N" ||
                               pe.PlanAntDxTuberculosis != "N" ||
                               pe.AltDxTuberculosis != "N" ||
                               pe.PlanDxTuberculosis != "N" ||
                               pe.AltDxTbMenorFiebre != "N" ||
                               pe.PlanDxTbMenorFiebre != "N" ||
                               pe.AltTbDxTratamiento != "N" ||
                               pe.PlanTbDxTratamiento != "N" ||
                               pe.AltTdDxEgreso != "N" ||
                               pe.PlanTdDxEgreso != "N" ||
                               pe.AltTbDxVih != "N" ||
                               pe.PlanTbDxVih != "N" ||
                               pe.AltTbTratDxVih != "N" ||
                               pe.PlanTbTratDxVih != "N" ||
                               pe.AltContDxLepra != "N" ||
                               pe.PlanContDxLepra != "N" ||
                               pe.AltLesionPiel != "N" ||
                               pe.PlanLesionPiel != "N" ||
                               pe.AltLepraDiscapacidad != "N"
                                 select new
                                 {
                                     Id = pe.Id,
                                     NroIdentificacion = pe.NroIdentificacion + " " + pe.Nombre
                                 }).ToList();

            ViewData["listCompany"] = new SelectList(listUserAlert, "Id", "NroIdentificacion");

            return PartialView();
        }

        public async Task<IActionResult> AlertsAndIntegrativeCarePlan(string id)
        {
            try
            {
                ConsultaAlertasCuidadosI dato = await db.ConsultaAlertasCuidadoses.Where(X => X.NroIdentificacion == id).FirstOrDefaultAsync();

                Type tipoConsulta = dato.GetType();
                var propiedades = tipoConsulta.GetProperties();

                foreach (var propiedad in propiedades)
                {
                    var nombrePropiedad = propiedad.Name;
                    var valorPropiedad = propiedad.GetValue(dato);

                    if (valorPropiedad == null)
                    {
                        if (valorPropiedad == null)
                        {
                            if (propiedad.PropertyType == typeof(string))
                            {
                                propiedad.SetValue(dato, "N.A");
                            }
                        }
                    }
                }
                if (dato == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return PartialView(dato);
            }
            catch (Exception e)
            {
                Log.CrearLog("AlertaCuidados", e.ToString());
            }
            return new ContentResult() { Content = "Error Integrante" };
        }

        public IActionResult list()
        {
            String[] Municipalityalert = SharedUser.Municipalities(HttpContext, db);

            List<string> listUserAlert = (from pe in db.ConsultaAlertasCuidadoses
                                          where
                                          Municipalityalert.Contains(pe.IdMunicipio) &&
                                        pe.AltTipoIdentificacion != "N" ||
                                        pe.PlanTipoIdentificacion != "N" ||
                                        pe.AltRegimenSaludPertenece != "N" ||
                                        pe.PlanRegimenSaludPertenece != "N" ||
                                        pe.AltVictAtnPsc != "N" ||
                                        pe.PlanVictAtnPsc != "N" ||
                                        pe.AltVictAtnSald != "N" ||
                                        pe.PlanVictAtnSald != "N" ||
                                        pe.AltDiscapacidad != "N" ||
                                        pe.PlanDiscapacidad != "N" ||
                                        pe.AltCerDiscapacidad != "N" ||
                                        pe.PlanCerDiscapacidad != "N" ||
                                        pe.AltSistemaRiesgo != "N" ||
                                        pe.PlanSistemaRiesgo != "N" ||
                                        pe.AltHoraTrabajo != "N" ||
                                        pe.PlanHoraTrabajo != "N" ||
                                        pe.AltInterfiereEscolar != "N" ||
                                        pe.PlanInterfiereEscolar != "N" ||
                                        pe.AltActividadExpFisico != "N" ||
                                        pe.PlanActividadExpFisico != "N" ||
                                        pe.AltActividadExpPsico != "N" ||
                                        pe.PlanActividadExpPsico != "N" ||
                                        pe.AltActividadExpBiolog != "N" ||
                                        pe.PlanActividadExpBiolog != "N" ||
                                        pe.AltActividadExpBiomec != "N" ||
                                        pe.PlanActividadExpBiomec != "N" ||
                                        pe.AltActividadExpQuimi != "N" ||
                                        pe.PlanActividadExpQuimi != "N" ||
                                        pe.AltActividadExpAltur != "N" ||
                                        pe.PlanActividadExpAltur != "N" ||
                                        pe.AltActividadExpLocat != "N" ||
                                        pe.PlanActividadExpLocat != "N" ||
                                        pe.AltActividadExpFennat != "N" ||
                                        pe.PlanActividadExpFennat != "N" ||
                                        pe.AltActividadElemento != "N" ||
                                        pe.PlanActividadElemento != "N" ||
                                        pe.AltProtCabeza != "N" ||
                                        pe.PlanProtCabeza != "N" ||
                                        pe.AltActuarEmergen != "N" ||
                                        pe.PlanActuarEmergen != "N" ||
                                        pe.AltDxOcupacion != "N" ||
                                        pe.PlanDxOcupacion != "N" ||
                                        pe.AltAccResOcupacion != "N" ||
                                        pe.PlanAccResOcupacion != "N" ||
                                        pe.AltMascotaVacunada != "N" ||
                                        pe.PlanMascotaVacunada != "N" ||
                                        pe.AltAlimCantAsucar != "N" ||
                                        pe.PlanAlimCantAsucar != "N" ||
                                        pe.AltBebCantAsucar != "N" ||
                                        pe.PlanBebCantAsucar != "N" ||
                                        pe.AltAlimCantSal != "N" ||
                                        pe.PlanAlimCantSal != "N" ||
                                        pe.AltAddSal != "N" ||
                                        pe.PlanAddSal != "N" ||
                                        pe.AltLactancia != "N" ||
                                        pe.PlanLactancia != "N" ||
                                        pe.AltDesparacitado != "N" ||
                                        pe.PlanDesparacitado != "N" ||
                                        pe.AltDxDiabetes != "N" ||
                                        pe.PlanDxDiabetes != "N" ||
                                        pe.AltDiabetesTratamiento != "N" ||
                                        pe.PlanDiabetesTratamiento != "N" ||
                                        pe.AltDiabetesControl != "N" ||
                                        pe.PlanDiabetesControl != "N" ||
                                        pe.AltDxHta != "N" ||
                                        pe.PlanDxHta != "N" ||
                                        pe.AltHtaTratamiento != "N" ||
                                        pe.PlanHtaTratamiento != "N" ||
                                        pe.AltHtaControl != "N" ||
                                        pe.PlanHtaControl != "N" ||
                                        pe.AltPresArResultado != "N" ||
                                        pe.PlanPresArResultado != "N" ||
                                        pe.AltAntCancer != "N" ||
                                        pe.PlanAntCancer != "N" ||
                                        pe.AltDxCancerTipo != "N" ||
                                        pe.PlanDxCancerTipo != "N" ||
                                        pe.AltDxCanLinfomas != "N" ||
                                        pe.PlanDxCanLinfomas != "N" ||
                                        pe.AltTiempoDxCan != "N" ||
                                        pe.PlanTiempoDxCan != "N" ||
                                        pe.AltDxCanTratamiento != "N" ||
                                        pe.PlanDxCanTratamiento != "N" ||
                                        pe.AltDxCanControl != "N" ||
                                        pe.PlanDxCanControl != "N" ||
                                        pe.AltDxImc != "N" ||
                                        pe.PlanDxImc != "N" ||
                                        pe.AltDxPerimetro != "N" ||
                                        pe.PlanDxPerimetro != "N" ||
                                        pe.AltFuma != "N" ||
                                        pe.PlanFuma != "N" ||
                                        pe.AltAntTabaco != "N" ||
                                        pe.PlanAntTabaco != "N" ||
                                        pe.AltExfumador != "N" ||
                                        pe.PlanExfumador != "N" ||
                                        pe.AltTiempoExfumador != "N" ||
                                        pe.PlanTiempoExfumador != "N" ||
                                        pe.AltActFisica != "N" ||
                                        pe.PlanActFisica != "N" ||
                                        pe.AltAcudeOdontologo != "N" ||
                                        pe.PlanAcudeOdontologo != "N" ||
                                        pe.AltIntercamCepillo != "N" ||
                                        pe.PlanIntercamCepillo != "N" ||
                                        pe.AltCepillaDia != "N" ||
                                        pe.PlanCepillaDia != "N" ||
                                        pe.AltIngiereCrema != "N" ||
                                        pe.PlanIngiereCrema != "N" ||
                                        pe.AltSaludBucal != "N" ||
                                        pe.PlanSaludBucal != "N" ||
                                        pe.AltFaltaDiente != "N" ||
                                        pe.PlanFaltaDiente != "N" ||
                                        pe.AltLimpiaProtesis != "N" ||
                                        pe.PlanLimpiaProtesis != "N" ||
                                        pe.AltTiempoProtesis != "N" ||
                                        pe.PlanTiempoProtesis != "N" ||
                                        pe.AltZonasEndemicas != "N" ||
                                        pe.PlanZonasEndemicas != "N" ||
                                        pe.AltPresentoTos != "N" ||
                                        pe.PlanPresentoTos != "N" ||
                                        pe.AltAntDxTuberculosis != "N" ||
                                        pe.PlanAntDxTuberculosis != "N" ||
                                        pe.AltDxTuberculosis != "N" ||
                                        pe.PlanDxTuberculosis != "N" ||
                                        pe.AltDxTbMenorFiebre != "N" ||
                                        pe.PlanDxTbMenorFiebre != "N" ||
                                        pe.AltTbDxTratamiento != "N" ||
                                        pe.PlanTbDxTratamiento != "N" ||
                                        pe.AltTdDxEgreso != "N" ||
                                        pe.PlanTdDxEgreso != "N" ||
                                        pe.AltTbDxVih != "N" ||
                                        pe.PlanTbDxVih != "N" ||
                                        pe.AltTbTratDxVih != "N" ||
                                        pe.PlanTbTratDxVih != "N" ||
                                        pe.AltContDxLepra != "N" ||
                                        pe.PlanContDxLepra != "N" ||
                                        pe.AltLesionPiel != "N" ||
                                        pe.PlanLesionPiel != "N" ||
                                        pe.AltLepraDiscapacidad != "N"
                                          select new
                                          {
                                              NroIdentificacion = pe.NroIdentificacion,
                                              Nombre = pe.Nombre
                                          }).ToList().ConvertAll<String>(item => item.NroIdentificacion);

            return Json(listUserAlert);
        }

        public IActionResult listAlertas(string id)
        {

            var query = (from pe in db.ConsultaAlertasCuidadoses
                         where pe.Id == id
                         select new
                         {
                             AltTipoIdentificacion = pe.AltTipoIdentificacion,
                             AltRegimenSaludPertenece = pe.AltRegimenSaludPertenece,
                             AltVictAtnPsc = pe.AltVictAtnPsc,
                             AltVictAtnSald = pe.AltVictAtnSald,
                             AltDiscapacidad = pe.AltDiscapacidad,
                             AltCerDiscapacidad = pe.AltCerDiscapacidad,
                             AltSistemaRiesgo = pe.AltSistemaRiesgo,
                             AltHoraTrabajo = pe.AltHoraTrabajo,
                             AltInterfiereEscolar = pe.AltInterfiereEscolar,
                             AltActividadExpFisico = pe.AltActividadExpFisico,
                             AltActividadExpPsico = pe.AltActividadExpPsico,
                             AltActividadExpBiolog = pe.AltActividadExpBiolog,
                             AltActividadExpBiomec = pe.AltActividadExpBiomec,
                             AltActividadExpQuimi = pe.AltActividadExpQuimi,
                             AltActividadExpAltur = pe.AltActividadExpAltur,
                             AltActividadExpLocat = pe.AltActividadExpLocat,
                             AltActividadExpFennat = pe.AltActividadExpFennat,
                             AltActividadElemento = pe.AltActividadElemento,
                             AltProtCabeza = pe.AltProtCabeza,
                             AltActuarEmergen = pe.AltActuarEmergen,
                             AltDxOcupacion = pe.AltDxOcupacion,
                             AltAccResOcupacion = pe.AltAccResOcupacion,
                             AltMascotaVacunada = pe.AltMascotaVacunada,
                             AltAlimCantAsucar = pe.AltAlimCantAsucar,
                             AltBebCantAsucar = pe.AltBebCantAsucar,
                             AltAlimCantSal = pe.AltAlimCantSal,
                             AltAddSal = pe.AltAddSal,
                             AltLactancia = pe.AltLactancia,
                             AltDesparacitado = pe.AltDesparacitado,
                             AltDxDiabetes = pe.AltDxDiabetes,
                             AltDiabetesTratamiento = pe.AltDiabetesTratamiento,
                             AltDiabetesControl = pe.AltDiabetesControl,
                             AltHtaTratamiento = pe.AltHtaTratamiento,
                             AltDxHta = pe.AltDxHta,
                             AltHtaControl = pe.AltHtaControl,
                             AltPresArResultado = pe.AltPresArResultado,
                             AltAntCancer = pe.AltAntCancer,
                             AltDxCancerTipo = pe.AltDxCancerTipo,
                             AltDxCanLinfomas = pe.AltDxCanLinfomas,
                             AltTiempoDxCan = pe.AltTiempoDxCan,
                             AltDxCanTratamiento = pe.AltDxCanTratamiento,
                             AltDxCanControl = pe.AltDxCanControl,
                             AltDxImc = pe.AltDxImc,
                             AltDxPerimetro = pe.AltDxPerimetro,
                             AltFuma = pe.AltFuma,
                             AltAntTabaco = pe.AltAntTabaco,
                             AltExfumador = pe.AltExfumador,
                             AltTiempoExfumador = pe.AltTiempoExfumador,
                             AltActFisica = pe.AltActFisica,
                             AltAcudeOdontologo = pe.AltAcudeOdontologo,
                             AltIntercamCepillo = pe.AltIntercamCepillo,
                             AltCepillaDia = pe.AltCepillaDia,
                             AltIngiereCrema = pe.AltIngiereCrema,
                             AltSaludBucal = pe.AltSaludBucal,
                             AltFaltaDiente = pe.AltFaltaDiente,
                             AltLimpiaProtesis = pe.AltLimpiaProtesis,
                             AltTiempoProtesis = pe.AltTiempoProtesis,
                             AltZonasEndemicas = pe.AltZonasEndemicas,
                             AltPresentoTos = pe.AltPresentoTos,
                             AltAntDxTuberculosis = pe.AltAntDxTuberculosis,
                             AltDxTuberculosis = pe.AltDxTuberculosis,
                             AltDxTbMenorFiebre = pe.AltDxTbMenorFiebre,
                             AltTbDxTratamiento = pe.AltTbDxTratamiento,
                             AltTdDxEgreso = pe.AltTdDxEgreso,
                             AltTbDxVih = pe.AltTbDxVih,
                             AltTbTratDxVih = pe.AltTbTratDxVih,
                             AltContDxLepra = pe.AltContDxLepra,
                             AltLesionPiel = pe.AltLesionPiel,
                             AltLepraDiscapacidad = pe.AltLepraDiscapacidad,
                             AltLepraTratamiento = pe.AltLepraTratamiento,
                             AltLepraValoracion = pe.AltLepraValoracion,
                             AltLepraControl = pe.AltLepraControl,
                             AltLepraConviviente = pe.AltLepraConviviente,
                             AltDiarrea = pe.AltDiarrea,
                             AltDiarreaTratamiento = pe.AltDiarreaTratamiento,
                             AltSintomaEda = pe.AltSintomaEda,
                             AltSintomaIra = pe.AltSintomaIra,
                             AltSintomaCovid19 = pe.AltSintomaCovid19,
                             AltVacunadoCovid19 = pe.AltVacunadoCovid19,
                             AltDosisCovid19 = pe.AltDosisCovid19,
                             AltTiempoAplCovid19 = pe.AltTiempoAplCovid19,
                             AltNinoDuermMal = pe.AltNinoDuermMal,
                             AltNinoConvulsion = pe.AltNinoConvulsion,
                             AltNinoDolorCabeza = pe.AltNinoDolorCabeza,
                             AltNinoLengAnorm = pe.AltNinoLengAnorm,
                             AltNinoHuido = pe.AltNinoHuido,
                             AltNinoRobo = pe.AltNinoRobo,
                             AltNinoNervioso = pe.AltNinoNervioso,
                             AltNinoRetardo = pe.AltNinoRetardo,
                             AltNinoNoJuega = pe.AltNinoNoJuega,
                             AltNinoOrinaRopa = pe.AltNinoOrinaRopa,
                             AltDxMental = pe.AltDxMental,
                             AltNumRiesgoPs = pe.AltNumRiesgoPs,
                             AltTratadoHerirlo = pe.AltTratadoHerirlo,
                             AltSienteImportante = pe.AltSienteImportante,
                             AltRarosPensamientos = pe.AltRarosPensamientos,
                             AltOyeVoces = pe.AltOyeVoces,
                             AltConvulsion = pe.AltConvulsion,
                             AltBebeMuchoLicor = pe.AltBebeMuchoLicor,
                             AltDejarBeberNoPuede = pe.AltDejarBeberNoPuede,
                             AltProblemasBebidaEntorno = pe.AltProblemasBebidaEntorno,
                             AltPeleasBorracho = pe.AltPeleasBorracho,
                             AltPiensaBebeDemasiado = pe.AltPiensaBebeDemasiado,
                             AltUtilzaDrogaPsa = pe.AltUtilzaDrogaPsa,
                             AltAbusaDroga = pe.AltAbusaDroga,
                             AltNoPuedeDejarDroga = pe.AltNoPuedeDejarDroga,
                             AltUsoDrogaDesvancimiento = pe.AltUsoDrogaDesvancimiento,
                             AltCulpableUsoDroga = pe.AltCulpableUsoDroga,
                             AltAfecFamiliaUsoDroga = pe.AltAfecFamiliaUsoDroga,
                             AltAbandonoFamiliaUsoDroga = pe.AltAbandonoFamiliaUsoDroga,
                             AltIlegalidadObtenerDroga = pe.AltIlegalidadObtenerDroga,
                             AltViolenciaEconomicaDroga = pe.AltViolenciaEconomicaDroga,
                             AltProblemasMedUsoDroga = pe.AltProblemasMedUsoDroga,
                             AltProblemasDejarDroga = pe.AltProblemasDejarDroga,
                             AltViolenciaPatrimonial = pe.AltViolenciaPatrimonial,
                             AltViolenciaEmocional = pe.AltViolenciaEmocional,
                             AltViolenciaEconomica = pe.AltViolenciaEconomica,
                             AltViolenciaFisica = pe.AltViolenciaFisica,
                             AltViolenciaFisicaEscolar = pe.AltViolenciaFisicaEscolar,
                             AltViolenciaPsicologicaEscolar = pe.AltViolenciaPsicologicaEscolar,
                             AltViolenciaSexualEscolar = pe.AltViolenciaSexualEscolar,
                             AltDerechoReproductivo = pe.AltDerechoReproductivo,
                             AltEdadInicioSexualidad = pe.AltEdadInicioSexualidad,
                             AltPlaneaEmbarazo = pe.AltPlaneaEmbarazo,
                             AltDeseaUltilAnticoncepcion = pe.AltDeseaUltilAnticoncepcion,
                             AltContinuarEmbarazo = pe.AltContinuarEmbarazo,
                             AltAsisteControlEmbarazo = pe.AltAsisteControlEmbarazo,
                             AltNoAsisteControlEmbarazo = pe.AltNoAsisteControlEmbarazo,
                             AltEnfTrasSexTratamiento = pe.AltEnfTrasSexTratamiento,
                             AltViolenciaSexual = pe.AltViolenciaSexual,
                             AltDenunciadoViolencia = pe.AltDenunciadoViolencia,
                             AltActivoRuta = pe.AltActivoRuta,
                             AltNoDenuncioDesconocimiento = pe.AltNoDenuncioDesconocimiento,
                             AltExamenMama = pe.AltExamenMama,
                             AltFrecuenciaExamenMama = pe.AltFrecuenciaExamenMama,
                             AltPuntajeApgar = pe.AltPuntajeApgar,
                             AltPuntajeApgarMen = pe.AltPuntajeApgarMen

                         }).ToList();
            List<string> valoresPropiedades = new List<string>();

            foreach (var item in query)
            {
                Type type = item.GetType();
                foreach (var property in type.GetProperties())
                {
                    //result +=( property.GetValue(item) );
                    if (property.GetValue(item).ToString() != "N")
                    {
                        valoresPropiedades.Add(property.GetValue(item).ToString());
                    }
                }
            }
            return Json(valoresPropiedades);
        }


        public IActionResult listAlertasdos(string id)
        {

            List<string> listUserAlert = (from pe in db.EstCuidados
                                          where pe.Alerta.Contains(id)
                                          select new
                                          {
                                              Plancuidado = pe.Plancuidado
                                          }).ToList().ConvertAll<String>(item => item.Plancuidado);

            return Json(listUserAlert);
        }

        [HttpPost]
        public IActionResult CreateData(IsSegAlertas alert, string fecuno, string fecdos, string integrante)
        {
            try
            {

                int startIndex = 0;
                int endIndex = 9;
/*
                List<string> Userid = (from pe in db.Integrantes
                                       where pe.NroIdentificacion == alert.IdIntegrante
                                       select new
                                       {
                                           NroIdentificacion = pe.Id
                                       }).ToList().ConvertAll<String>(item => item.NroIdentificacion);
*/
                alert.Id = System.Guid.NewGuid().ToString().Substring(startIndex, endIndex);
                int id;
                bool conversionExitosa = int.TryParse(HttpContext.Session.GetString("Id"), out id);
                alert.IdUserSistem = id;
                if (conversionExitosa)
                {
                    // la conversión se realizó correctamente, y el valor entero está en la variable "id"
                    String[] municipalities = SharedUser.Municipalities(HttpContext, db);
                    string municipio = municipalities[0];
                    alert.IdMunicipio = municipio;
                    alert.FechaIntervencion = DateOnly.ParseExact(fecdos, "yyyy-MM-dd", null);
                    alert.FechaSeguimiento = DateOnly.ParseExact(fecuno, "yyyy-MM-dd", null);
                    alert.IdIntegrante = integrante;
                    if (!ModelState.IsValid)
                    {
                        return BadRequest("Enter required fields");
                    }
                    db.IsSegAlertas.Add(alert);
                    var r = db.SaveChanges();

                    return this.Ok($"Form Data received!");
                }
                else
                {
                    // la conversión falló, y "id" tiene un valor predeterminado de 0
                    return BadRequest("Error fields");
                }

            }
            catch (Exception e)
            {
                Log.CrearLog("alert", e.ToString());
            }
            return new ContentResult() { Content = "Error" };

        }
        public IActionResult listEstado(string id)
        {
            /*var Userid = (from pe in db.Integrantes
                                          where pe.NroIdentificacion == id
                                          select new
                                          {
                                              NroIdentificacion = pe.Id
                                          }).FirstAsync();
*/
            List<string> opciones = new List<string> { "Ejecutada", "En ejecucion", "Pendiente en ejecucion" };
            List<string> listUserAlert = (from pe in db.IsSegAlertas
                                          join e in db.Integrantes on pe.IdIntegrante equals e.Id
                                          where e.NroIdentificacion == id

                                          select new
                                          {
                                              Estado = pe.Estado
                                          }).ToList().ConvertAll<String>(item => item.Estado);

            if (listUserAlert.Count > 0)
            {
                foreach (string opcion in listUserAlert)
                {
                    if (opcion == "Ejecutada")
                    {
                        opciones.Remove(opcion);
                    }
                    else if (opcion == "En ejecucion")
                    {
                        opciones.Remove(opcion);

                    }
                    else if (opcion == "Pendiente en ejecucion")
                    {
                        opciones.Remove(opcion);

                    }
                }
            }

            return Json(opciones);

            //}
            //return Json(opciones);

        }
        public async Task<IActionResult> Edit(string id)
        {
            IsSegAlertas querys = await db.IsSegAlertas.Where(X => X.Id == id).FirstOrDefaultAsync();
            Integrante muni = await db.Integrantes.Where(x => x.Id == querys.IdIntegrante).FirstOrDefaultAsync();
            string nombreMunicipio = muni.NroIdentificacion;
            querys.IdIntegrante = nombreMunicipio;


            List<IsSegAlertas> listCompany = db.IsSegAlertas.Where(X => X.Id == id).ToList();
            List<string> opciones = new List<string> { "Ejecutada", "En ejecucion", "Pendiente en ejecucion" };

            ViewData["listCompany"] = new SelectList(opciones, querys.Estado);


            return PartialView(querys);
        }

        [HttpPost]
        public IActionResult EditData(IsSegAlertas alert, string Estadoalert, string fecuno, string fecdos)
        {
            try
            {


                List<string> Userid = (from pe in db.Integrantes
                                       where pe.NroIdentificacion == alert.IdIntegrante
                                       select new
                                       {
                                           NroIdentificacion = pe.Id
                                       }).ToList().ConvertAll<String>(item => item.NroIdentificacion);

                int id;
                bool conversionExitosa = int.TryParse(HttpContext.Session.GetString("Id"), out id);
                alert.IdUserSistem = id;

                if (conversionExitosa)
                {
                    // la conversión se realizó correctamente, y el valor entero está en la variable "id"
                    var alerts = db.IsSegAlertas.Find(alert.Id);

                    String[] municipalities = SharedUser.Municipalities(HttpContext, db);

                    string municipio = municipalities[0];

                    alerts.IdIntegrante = alert.IdIntegrante;
                    alerts.IdMunicipio = municipio;
                    alerts.FechaSeguimiento = DateOnly.ParseExact(fecuno, "yyyy-MM-dd", null); ;
                    alerts.Alerta = alert.Alerta;
                    alerts.Plan = alert.Plan;
                    alerts.Estado = Estadoalert;
                    alerts.FechaIntervencion = DateOnly.ParseExact(fecdos, "yyyy-MM-dd", null);
                    alerts.DesIntervencion = alert.DesIntervencion;

                    db.SaveChanges();
                    return this.Ok($"Form Data received!");

                }
                else
                {
                    // la conversión falló, y "id" tiene un valor predeterminado de 0
                    return BadRequest("Error fields");

                }

            }
            catch (Exception e)
            {
                Log.CrearLog("alert", e.ToString());
            }
            return new ContentResult() { Content = "Error" };
        }
        public async Task<IActionResult> Details(string id)
        {
            try
            {
                IsSegAlertas querys = await db.IsSegAlertas.Where(X => X.Id == id).FirstOrDefaultAsync();
                Integrante muni = await db.Integrantes.Where(x => x.Id == querys.IdIntegrante).FirstOrDefaultAsync();
                string nombreMunicipio = muni.NroIdentificacion + " " + muni.Nombre + " " + muni.Apellido;
                querys.IdIntegrante = nombreMunicipio;
                ListaMunicipio munis = await db.ListaMunicipios.Where(x => x.Id == querys.IdMunicipio).FirstOrDefaultAsync();
                string nombreMunicipios = munis.NomMunicipio;
                querys.IdMunicipio = nombreMunicipios;

                List<IsSegAlertas> listCompany = db.IsSegAlertas.Where(X => X.Id == id).ToList();
                List<string> opciones = new List<string> { "Ejecutada", "En ejecucion", "Pendiente en ejecucion" };

                ViewData["listCompany"] = new SelectList(opciones, querys.Estado);


                if (querys == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return PartialView(querys);
            }
            catch (Exception e)
            {
                Log.CrearLog("Empresa", e.ToString());
            }
            return new ContentResult() { Content = "Error" };
        }
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                IsSegAlertas querys = await db.IsSegAlertas.Where(X => X.Id == id).FirstOrDefaultAsync();
                Integrante muni = await db.Integrantes.Where(x => x.Id == querys.IdIntegrante).FirstOrDefaultAsync();
                string nombreMunicipio = muni.NroIdentificacion;
                querys.IdIntegrante = nombreMunicipio;


                List<IsSegAlertas> listCompany = db.IsSegAlertas.Where(X => X.Id == id).ToList();
                List<string> opciones = new List<string> { "Ejecutada", "En ejecucion", "Pendiente en ejecucion" };

                ViewData["listCompany"] = new SelectList(opciones, querys.Estado);


                if (querys == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return PartialView(querys);

            }
            catch (Exception e)
            {
                Log.CrearLog("Empresa", e.ToString());
            }
            return new ContentResult() { Content = "Error" };
        }
        public async Task<IActionResult> DeleteData(string id)
        {
            try
            {
                string valueReturn = "La alerta gestionada no se puede eliminar";
                IsSegAlertas query = await db.IsSegAlertas.FindAsync(id);

                if (query == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                db.IsSegAlertas.Remove(query);
                db.SaveChanges();
                db.Dispose();

                valueReturn = "Alerta gestionada eliminada exitosamente";

                return new ContentResult() { Content = valueReturn }; ;


            }
            catch (Exception e)
            {
                Log.CrearLog("Alerta", e.ToString());
            }
            return new ContentResult() { Content = "Error" };
        }


    }
}