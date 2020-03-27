using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoNoAspNetMVC.Filters
{
    public class AutorizacaoTipo : AuthorizeAttribute
    {
        private AutorizacaoTipo[] tiposAutorizados;

        public AutorizacaoTipo(AutorizacaoTipo[] tipoUsuariosAutorizados)
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