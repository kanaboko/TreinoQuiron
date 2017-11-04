using QuironLojaVirtual.Domain.Entities;
using QuironLojaVirtual.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QuironLojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradorRepository _repository = new AdministradorRepository();
        // GET: Autenticacao
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var admin = _repository.ObterAdministrador(administrador);
                if (admin != null)
                {
                    if (!Equals(admin.Senha, administrador.Senha))
                    {
                        ModelState.AddModelError("", "Senha não confere");
                        return View(administrador);
                       
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);
                        if (Url.IsLocalUrl(returnUrl)
                           && returnUrl.StartsWith("/")
                           && !returnUrl.StartsWith("//")
                           && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Administrador não cadastrado");
                    return View();
                }
            }
            return View();


        }
    }
}