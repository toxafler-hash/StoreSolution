using Autofac;
using Autofac.Integration.WebApi;
using MediatR;
using MediatR.Configuration;
using Application.Abstractions;
using Application.Products.Commands;
using Infrastructure.Repositories;
using System.Reflection;
using System.Web.Http;

namespace Presentation
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

            // Настройка DI контейнера
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var mediatrConfiguration = MediatRConfigurationBuilder
                .Create(string.Empty, typeof(CreateProductCommand).Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(mediatrConfiguration);
            builder.RegisterType<JsonProductRepository>().As<IProductRepository>().SingleInstance();
            builder.RegisterType<JsonSaleRepository>().As<ISaleRepository>().SingleInstance();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}