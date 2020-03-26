using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoNoAspNetMVC.Controllers
{
    public class PainelController : Controller
    {
        [Authorize]
        // GET: Painel
        public ActionResult Index()
        {
            if (User.IsInRole("Padrao"))
            {
                ViewBag.Mensagem = "Você é um usuário padrão e não poderá alterar dados do sistema";
            }
            return View();
        }

        [Authorize]
        // GET: Painel
        public ActionResult Mensagens()
        {
            return View();
        }
    }
}