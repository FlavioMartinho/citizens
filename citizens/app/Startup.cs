using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Citizens.Repository;
using Citizens.Interface;
using Citizens.Context;
using Citizens.Seeder;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;


namespace Citizens
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddEntityFrameworkNpgsql()
          .AddDbContext<CitizensDbContext>(options =>
              options.UseNpgsql(Configuration["Data:DbContext:ConnectionString"]));

      services.AddMvc()
        .AddJsonOptions(
            options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

      services.AddScoped<IStatesRepository, StatesRepository>();
      services.AddScoped<ICitiesRepository, CitiesRepository>();
      services.AddScoped<IAdressesRepository, AdressesRepository>();
      services.AddScoped<IPersonsRepository, PersonsRepository>();
      services.AddScoped<ISexesRepository, SexesRepository>();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory log)
    {
      app.UseMiddleware<OptionsMiddleware>();
      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetRequiredService<CitizensDbContext>();
        context.Database.EnsureCreated();
      }

      var sexesDbSeeder = new SexesDbSeeder(log);
      sexesDbSeeder.SeedAsync(app.ApplicationServices).Wait();
      var statesDbSeeder = new StatesDbSeeder(log);
      statesDbSeeder.SeedAsync(app.ApplicationServices).Wait();
      var citiesDbSeeder = new CitiesDbSeeder(log);
      citiesDbSeeder.SeedAsync(app.ApplicationServices).Wait();
      var citizensDbSeeder = new CitizensDbSeeder(log);
      citizensDbSeeder.SeedAsync(app.ApplicationServices).Wait();

      app.UseCors(option => option.AllowAnyOrigin()
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials());
      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
  public class OptionsMiddleware
  {
    private readonly RequestDelegate _next;

    public OptionsMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public Task Invoke(HttpContext context)
    {
      return BeginInvoke(context);
    }

    private Task BeginInvoke(HttpContext context)
    {
      if (context.Request.Method == "OPTIONS")
      {
        context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });
        context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
        context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" });
        context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
        context.Response.StatusCode = 200;
        return context.Response.WriteAsync("OK");
      }

      return _next.Invoke(context);
    }
  }
}
