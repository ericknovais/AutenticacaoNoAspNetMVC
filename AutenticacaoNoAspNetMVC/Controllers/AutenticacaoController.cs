﻿using AutenticacaoNoAspNetMVC.Models;
using AutenticacaoNoAspNetMVC.ViewModels;
using System.Web.Mvc;
using AutenticacaoNoAspNetMVC.Utils;

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

            Usuario novoUsuario = new Usuario
            {
                Nome = viewModel.Nome,
                Login = viewModel.Login,
                Senha = Hash.GerarHash(viewModel.Senha)
            };

            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}