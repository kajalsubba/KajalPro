using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tea.Api.Data.DbHandler;
using Tea.Api.Data.MiddleWare;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Service.Admin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }); // use to same model name display in api


builder.Services.AddScoped<IDataHandler, DataHandler>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
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
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tea.Api.Admin", Version = "v1" });

    // JWT Bearer configuration
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("https://www.glsportals.com") // Replace with your frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // If you need credentials (e.g., cookies)
        });
});
var app = builder.Build();
app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    var project = System.Reflection.Assembly.GetEntryAssembly().GetName().Name.Split(".");
    var name = project[project.Length - 1];
    app.UseSwagger(c => c.RouteTemplate = name + "/swagger/{documentName}/swagger.json");
 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/" + name + "/swagger/v1/swagger.json", "Tea.Api." + name + " v1");
        c.RoutePrefix = name + "/swagger";
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

