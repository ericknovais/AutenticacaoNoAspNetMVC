using AutenticacaoNoAspNetMVC.Models;
using AutenticacaoNoAspNetMVC.Utils;
using AutenticacaoNoAspNetMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoNoAspNetMVC.Controllers
{
    public class PerfilController : Controller
    {
        UsuariosContext ctx = new UsuariosContext();

        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(x => x.Type == "Login").Value;

            var usuario = ctx.Usuarios.FirstOrDefault(x => x.Login == login);

            if (Hash.GerarHash(viewModel.SenhaAtual) != usuario.Senha)
            {
                ModelState.AddModelError("SenhaAtual", "Senha Incorreta");
                return View();
            }
            usuario.Senha = Hash.GerarHash(viewModel.NovaSenha);
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();

            TempData["Mensagem"] = "Senha alterada com sucesso";

            return RedirectToAction("Index", "Painel");
        }
    }
}