using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutenticacaoNoAspNetMVC.Filters;
using AutenticacaoNoAspNetMVC.Models;

namespace AutenticacaoNoAspNetMVC.Controllers
{
    public class CadastroUsuarioController : Controller
    {
        [AutorizacaoTipo(new[] { TipoUsuario.Administrador })]
        public ActionResult Index()
        {
            return View();
        }
    }
}