using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuironLojaVirtual.Web.Models;

namespace QuironLojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //1 - url NomeDoSite/
            routes.MapRoute(
                null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = 1
                });

            //2 - url NomeDoSite/pagina
            routes.MapRoute(
                null,
                "Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null},
                    new { pagina = @"\d+"}
                );

            //3 - url NomeDoSite/Categoria
            routes.MapRoute(
                null,
                "{categoria}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = 1
                });
            //4 - url NomeDoSite/Categoria/Pagina
            routes.MapRoute(
                null,
                "{categoria}/Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                },
                new { pagina = @"\d+" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );
        }
    }
}
