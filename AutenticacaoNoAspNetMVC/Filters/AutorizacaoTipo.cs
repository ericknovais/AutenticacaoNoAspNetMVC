using AutenticacaoNoAspNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoNoAspNetMVC.Filters
{
    public class AutorizacaoTipo : AuthorizeAttribute
    {
        private TipoUsuario[] tiposAutorizados;

        public AutorizacaoTipo(TipoUsuario[] tipoUsuariosAutorizados)
        {
            tiposAutorizados = tipoUsuariosAutorizados;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            bool autorizado = tiposAutorizados.Any(t => filterContext.HttpContext.User.IsInRole(t.ToString()));

            if (!autorizado)
            {
                filterContext.Result = new RedirectResult("Painel");
            } 
        }
    }
}