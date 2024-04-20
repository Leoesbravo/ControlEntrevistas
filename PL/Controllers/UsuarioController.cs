using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin, Colocacion")]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Form()
        {
            
            return View();
        }
    }
}