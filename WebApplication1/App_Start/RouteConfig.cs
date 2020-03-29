using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


//Depois de configurar a controlador você precisa especificar as 
//chamadas de cada um aqui nas rotas

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "EditarWin",
            //    "Editar/{id}",
            //    new { controle = "Registro", Action = "Editar" }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Registro", action = "SetDatainDataBase", id = UrlParameter.Optional } 
            );

            //routes.MapRoute(
            //  name: "Default",
            //  url: "{controller}/{action}/{id}",
            //  defaults: new { controller = "Registro", action = "SetDatainDataBase", id = UrlParameter.Optional }
            //);
        }
    }
}
