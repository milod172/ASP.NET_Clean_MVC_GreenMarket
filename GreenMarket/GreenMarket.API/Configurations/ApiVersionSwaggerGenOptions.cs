using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace GreenMarket.API.Configurations
{
    public class ApiVersionSwaggerGenOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider = provider;

        public void Configure(Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenOptions options) {
            foreach (var description in _provider.ApiVersionDescriptions) {
                options.SwaggerDoc(
                    description.GroupName,
                    CreateVersionInfo(description)
                );
            }
        }

        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description) {

            var info = new OpenApiInfo()
            {
                Title = "GreenMarket API",
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated) {
                info.Description = "This API version has been deprecated.";
            }

            return info;
        }
    }
}
