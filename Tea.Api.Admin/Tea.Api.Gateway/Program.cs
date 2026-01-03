using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");

// Add services to the container.
// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }); // use to same model name display in api



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tea.Api.Gateway", Version = "v1" });
    // 🔐 JWT Support in Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer {your JWT token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// 🔐 JWT Authentication for Gateway
builder.Services.AddAuthentication()
    .AddJwtBearer("GatewayAuthenticationScheme", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),

            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddOcelot();

// Register HttpClient with default SSL certificate validation
builder.Services.AddHttpClient("externalService", client =>
{
    client.DefaultRequestHeaders.Add("Accept", "application/json");
}).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
    {
        // Validate certificate as per your requirements
        return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
    }
});

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    var project = System.Reflection.Assembly.GetEntryAssembly().GetName().Name.Split(".");
    var name = project[project.Length - 1];

    // Route template change needed to keep everything under one path.
    app.UseSwagger(c => c.RouteTemplate = name + "/swagger/{documentName}/swagger.json");


    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/" + name + "/swagger/v1/swagger.json", "Tea.Api." + name + " v1");
        c.RoutePrefix = name + "/swagger";
    });

    app.UseHttpsRedirection();
    app.UseOcelot().Wait();

    // app.UseMiddleware<ExceptionHandler>();
 
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}