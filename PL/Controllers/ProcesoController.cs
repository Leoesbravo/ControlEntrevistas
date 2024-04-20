using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    [Authorize]
    public class ProcesoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ML.Result resultRecurso = BL.Recurso.GetByIdUsuario(User.Identity.GetUserId());
            ML.Recurso recurso = (ML.Recurso)resultRecurso.Object;
            HttpContext.Session.Add("Recurso", recurso.IdRecurso);
            ML.Result result = BL.Proceso.GetAllByIdRecurso(recurso.IdRecurso);
            ML.Result resultFiltro = BL.Filtro.GetAll();
            if (result.Correct)
            {
                ML.Proceso proceso = new ML.Proceso()
                {
                    Procesos = new List<object>()
                };
                proceso.Historico = new ML.Historico();
                proceso.Historico.Filtro = new ML.Filtro(resultFiltro.Objects);
                proceso.Procesos = result.Objects;

                //Cargar ddl del form
                ML.Result resultEstatus = BL.Estatus.GetAll();
                ML.Result resultBolsa = BL.BolsaTrabajo.GetAll();
                proceso.Estatus = new ML.Estatus(resultEstatus.Objects);
                proceso.BolsaTrabajo = new ML.BolsaTrabajo(resultBolsa.Objects);
                return View(proceso);
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error";
                return PartialView("Modal");
            }

        }
        //[HttpGet]
        //public ActionResult AddProceso()
        //{
        //    ML.Result resultEstatus = BL.Estatus.GetAll();
        //    ML.Result resultBolsa = BL.BolsaTrabajo.GetAll();

        //    ML.Proceso proceso = new ML.Proceso();
        //    proceso.Estatus = new ML.Estatus(resultEstatus.Objects);
        //    proceso.BolsaTrabajo = new ML.BolsaTrabajo(resultBolsa.Objects);

        //    return View(proceso);
        //}
        [HttpPost]
        public ActionResult AddProceso(ML.Proceso proceso)
        {
            proceso.Recurso = new ML.Recurso()
            {
                IdRecurso = (int)HttpContext.Session["Recurso"]
            };
            ML.Result result = BL.Proceso.Add(proceso);
            if (result.Correct)
            {
                return RedirectToAction("Index", "Proceso");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult UpdateProceso(ML.Proceso proceso)
        {
            proceso.Recurso = new ML.Recurso()
            {
                IdRecurso = (int)HttpContext.Session["Recurso"]
            };
            ML.Result result = BL.Proceso.Add(proceso);
            if (result.Correct)
            {
                return RedirectToAction("Home", "Index");
            }
            else
            {
                return View();
            }

        }
        [HttpPost]
        public ActionResult AddFiltro(ML.Proceso proceso)
        {
            ML.Result result = BL.Historico.Add(proceso);
            if (result.Correct)
            {
                return RedirectToAction("Home", "Index");
            }
            else
            {
                return View();
            }
        }

        public JsonResult GetById(int idProceso)
        {
            ML.Result result = BL.Proceso.GetById(idProceso);
            if (result.Correct)
            {
                ML.Proceso proceso = (ML.Proceso)result.Object;
                return Json(proceso, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}