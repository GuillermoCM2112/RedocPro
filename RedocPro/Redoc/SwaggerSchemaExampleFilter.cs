using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace RedocPro.Redoc
{
    public class SwaggerSchemaExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.MemberInfo is not null)
            {
                var schemmaAttribute = context.MemberInfo.GetCustomAttributes<SwaggerSchemaExampleAttribute>().FirstOrDefault();
                if (schemmaAttribute is not null)
                {
                    ApplySchemaAttribute(schema, schemmaAttribute);
                }
            }
        }

        private void ApplySchemaAttribute(OpenApiSchema schema, SwaggerSchemaExampleAttribute swaggerSchemaAttribute)
        {
            if (!string.IsNullOrEmpty(swaggerSchemaAttribute.Example))
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiString(swaggerSchemaAttribute.Example);
            }
        }
    }

    public class SwaggerSchemaExampleAttribute : Attribute
    {
        public SwaggerSchemaExampleAttribute(string example)
        {
            Example = example;
        }
        public string Example { get; set; }
    }
}
