using System.Web.Routing;

namespace Presentation
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Перенаправление корневого URL на Swagger
            routes.MapPageRoute("Swagger", "", "~/Swagger");
        }
    }
}