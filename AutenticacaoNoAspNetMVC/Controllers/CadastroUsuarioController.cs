using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoNoAspNetMVC.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }
    }
}