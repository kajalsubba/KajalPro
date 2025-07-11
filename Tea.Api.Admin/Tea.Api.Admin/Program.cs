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

//Adding Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})

// Adding Jwt Bearer
//.AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = configuration["JWT:ValidAudience"],
//        ValidIssuer = configuration["JWT:ValidIssuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
//    };
//});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tea.Api.Admin", Version = "v1" });
});

//builder.Services.AddCors(policyBuilder =>
//    policyBuilder.AddDefaultPolicy(policy =>
//        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
//);
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
if (app.Environment.IsDevelopment()|| app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    var project = System.Reflection.Assembly.GetEntryAssembly().GetName().Name.Split(".");
    var name = project[project.Length - 1];

    // Route template change needed to keep everything under one path.
    app.UseSwagger(c => c.RouteTemplate = name + "/swagger/{documentName}/swagger.json");

    // Makes the assumption that where FlipPos.Api.N is the project name and N 
    // is the microservice name, N is also the name of the primary controller 
    // so both Swagger and the actual endpoints both end up under /N.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/" + name + "/swagger/v1/swagger.json", "Tea.Api." + name + " v1");
        c.RoutePrefix = name + "/swagger";
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandler>();
app.UseAuthorization();

app.MapControllers();

app.Run();

