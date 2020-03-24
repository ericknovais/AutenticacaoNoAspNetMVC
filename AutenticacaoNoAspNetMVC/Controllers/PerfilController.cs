using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoNoAspNetMVC.Controllers
{
    public class PerfilController : Controller
    {
        [Authorize]
        // GET: Perfil
        public ActionResult AlterarSenha()
        {
            return View();
        }
    }
}