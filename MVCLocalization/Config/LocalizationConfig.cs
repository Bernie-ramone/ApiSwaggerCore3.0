using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLocalization.Config
{
    public class LocalizationConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resource");
            services.Configure<RequestLocalizationOptions>(options => {
                var supportedCulture = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-ES")
                };

                options.DefaultRequestCulture = new RequestCulture(culture:"es-ES", uiCulture: "en-US");
                options.SupportedCultures = supportedCulture;
                options.SupportedUICultures = supportedCulture;
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
        }
    }
}
