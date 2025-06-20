using Microsoft.OpenApi.Models;
using Tea.Api.Data.DbHandler;
using Tea.Api.Data.MiddleWare;
using Tea.Api.Data.Repository.MessageBroker;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Service.MessageBroker;
using Tea.Api.Service.SignalR;

var builder = WebApplication.CreateBuilder(args);
var connectionStringsSection = builder.Configuration.GetSection("ConnectionStrings");

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                }); // use to same model name display in api

builder.Services.AddSignalR();
builder.Services.AddScoped<IDataHandler, DataHandler>();
builder.Services.AddScoped<IMessageBrokerService, MessageBrokerService>();
//builder.Services.AddTransient<IMessageHubClient, MessageHubClient>();
builder.Services.AddScoped<IRabitMQProducer, RabbitMQProducer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tea.Api.Messaging", Version = "v1" });
});
//builder.Services.AddCors(policyBuilder =>
//    policyBuilder.AddDefaultPolicy(policy =>
//        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
//);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
        .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
               .SetIsOriginAllowed(hosts => true); // Allows any origin
    });
});

var app = builder.Build();

app.UseCors("CorsPolicy");

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

app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandler>();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<MessageHubClient>("/notify");
});

app.Run();

