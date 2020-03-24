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
            return View();
        }
    }
}