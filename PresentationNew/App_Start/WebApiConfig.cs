using System.Web.Http;
using System.Net.Http.Headers;

namespace PresentationNew
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Маршруты
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Принудительный возврат JSON вместо XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(
                new MediaTypeHeaderValue("application/json"));
        }
    }
}