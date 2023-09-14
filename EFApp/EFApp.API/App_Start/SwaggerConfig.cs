using System.Web.Http;
using WebActivatorEx;
using EFApp.API;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace EFApp.API
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "EFApp API");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\EFApp.API.xml",
                                         System.AppDomain.CurrentDomain.BaseDirectory));
                })
              .EnableSwaggerUi();        
        }
    }
}
