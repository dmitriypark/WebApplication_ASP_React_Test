using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using React.AspNet;
using WebApplication_ASP_React_Test.Models;


namespace WebApplication_ASP_React_Test
{
	public class Startup
	{
		public Startup(IWebHostEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}
		public IConfigurationRoot Configuration { get; }		
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:FormForTest:ConnectionString"]));
			services.AddTransient<ApplicationDbContext>();
			services.AddTransient<IOrderRepository, EFOrderRepository>();
			services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
				.AddChakraCore();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddReact();			
			services.AddMvc(opt => opt.EnableEndpointRouting = false);
			
		}		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();				
			}			
			app.UseReact(config =>
			{
				config
				  .AddScript("~/js/orderData.jsx")
				  .AddScript("~/js/orderForm.jsx")
				  .SetJsonSerializerSettings(new JsonSerializerSettings
				  {
					  StringEscapeHandling = StringEscapeHandling.EscapeHtml,
					  ContractResolver = new CamelCasePropertyNamesContractResolver()
				  });

			});
			app.UseStaticFiles();
			app.UseRouting();			
			app.UseMvc(routes =>
			{
				routes.MapRoute(
						  name: null,
						  template: "",
						  defaults: new { controller = "Order", action = "Index" }
				);
				routes.MapRoute(
							name: null,
							template: "{controller}/{action}/{id?}",
							defaults: new { controller = "Order", action = "Index" }
				);
			});				
			SeedData.EnsurePopulated(app);
		}
	}
}