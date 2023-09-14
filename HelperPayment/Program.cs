using HelperPayment.Core;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer",
    });
    //x.OperationFilter<SecurityRequirementsOperationFilter>();
    x.SupportNonNullableReferenceTypes();
    x.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
            {   new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                Array.Empty<string>()
            }
    });
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "RealWorld API", Version = "v1" });
    x.CustomSchemaIds(y => y.FullName);
    x.DocInclusionPredicate((version, apiDescription) => true);
});

var app = builder.Build();

app.UseInfrastructure();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
