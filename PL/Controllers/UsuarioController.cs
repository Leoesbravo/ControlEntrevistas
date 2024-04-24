using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAllRecursos()
        {

            ML.Recurso recurso = new ML.Recurso();

            ML.Result resultGeneracion = BL.Generacion.GetAll();
            recurso.Generacion = new ML.Generacion();
            recurso.Generacion.Generaciones = resultGeneracion.Objects;

            ML.Result resultEmpres = BL.Empresa.GetAll();
            recurso.Empresa = new ML.Empresa();
            recurso.Empresa.Empresas = resultEmpres.Objects;
            return View(recurso);

        }
        [HttpPost]
        public ActionResult GetAllRecursos(ML.Recurso recurso)
        {
            ML.Result result = BL.Recurso.GetAll(0, recurso.Generacion.IdGeneracion);
            if (result.Correct)
            {
                recurso = new ML.Recurso();
                recurso.Recursos = result.Objects;

                ML.Result resultGeneracion = BL.Generacion.GetAll();
                recurso.Generacion = new ML.Generacion();
                recurso.Generacion.Generaciones = resultGeneracion.Objects;

                ML.Result resultEmpres = BL.Empresa.GetAll();
                recurso.Empresa = new ML.Empresa();
                recurso.Empresa.Empresas = resultEmpres.Objects;

                return View(recurso);
            }
            else
            {
                return View();
            }
        }
    }
}