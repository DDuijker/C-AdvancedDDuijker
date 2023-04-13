using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AirBnB.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {

        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;


        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                // check if the Swagger document key already exists
                if (!options.SwaggerGeneratorOptions.SwaggerDocs.ContainsKey(description.GroupName))
                {
                    options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
                }
            }
        }

        private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "AirBnB API",
                Description = description.ApiVersion.ToString()
            };

            return info;
        }
    }
}
