using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Services.Catalog.Application;
using Services.Catalog.Application.Mapping;
using Services.Catalog.Core.Interfaces;
using Services.Catalog.Grpc.Services;
using Services.Catalog.Infrastructure;
using Services.Catalog.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Catalog.Grpc
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
			services.AddSingleton<IDatabaseSettings>(provider =>
			{
				return provider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
			});
			services.AddScoped<ICatalogContext, CatalogContext>();
			services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddAutoMapper((typeof(CatalogMapping).Assembly));
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Services.Catalog.Grpc", Version = "v1" });
			});
			services.AddGrpc(options =>
			{
				options.EnableDetailedErrors = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Services.Catalog.Grpc v1"));
			}
			app.UseExceptionHandler(c => c.Run(async context =>
			{
				var exception = context.Features
					.Get<IExceptionHandlerPathFeature>()
					.Error;
				var response = new { error = exception.Message };
				await context.Response.WriteAsJsonAsync(response);
			}));
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<ProductService>();
				endpoints.MapControllers();
			});
		}
	}
}
