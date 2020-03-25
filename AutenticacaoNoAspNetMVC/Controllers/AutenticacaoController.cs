using AutenticacaoNoAspNetMVC.Models;
using AutenticacaoNoAspNetMVC.ViewModels;
using System.Web.Mvc;
using AutenticacaoNoAspNetMVC.Utils;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System;

namespace AutenticacaoNoAspNetMVC.Controllers
{
    public class AutenticacaoController : Controller
    {
        UsuariosContext ctx = new UsuariosContext();

        // GET: Autenticacao
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (ctx.Usuarios.Count(x => x.Login == viewModel.Login) > 0)
            {
                ModelState.AddModelError("Login", "Esse login já esta em uso");
                return View(viewModel);
            }

            Usuario novoUsuario = new Usuario
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
            };

            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue login.";
            return RedirectToAction("Login");
        }

        public ActionResult Login(string ReturnUrl)
        {
            LoginViewModel viewModel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var usuario = ctx.Usuarios.FirstOrDefault(x => x.Login == viewModel.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login incorreto");
                return View(viewModel);
            }

            if (usuario.Senha != Hash.GerarHash(viewModel.Senha))
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login),
            }, "ApplicationCookie");
            
            Request.GetOwinContext().Authentication.SignIn(identity);
            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
                return Redirect(viewModel.UrlRetorno);
            else
                return RedirectToAction("Index", "Painel");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}