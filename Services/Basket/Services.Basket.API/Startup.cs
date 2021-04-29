using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Services.Basket.Application;
using Services.Basket.Application.Interfaces;
using Services.Basket.Application.Mapping;
using Services.Basket.Application.Services;
using Services.Basket.Core;
using Services.Catalog.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Basket.API
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
			services.Configure<RedisSettings>(Configuration.GetSection("RedisSettings"));
			services.AddScoped<IBasketService, BasketService>();
			services.AddSingleton<RedisService>(sp =>
			{
				var redisSettings = sp.GetRequiredService<IOptions<RedisSettings>>().Value;
				var redis = new RedisService(redisSettings.Host, redisSettings.Port);
				redis.Connect();
				return redis;
			});
			services.AddAutoMapper((typeof(MappingProfile).Assembly));
			services.AddGrpcClient<ProductProtoService.ProductProtoServiceClient>
					  (o => o.Address = new Uri(Configuration["GrpcSettings:Url"]));
			services.AddScoped<ProductGrpcService>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Services.Basket.API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Services.Basket.API v1"));
			}
			app.UseExceptionHandler(c => c.Run(async context =>
			{
				var exception = context.Features
					.Get<IExceptionHandlerPathFeature>()
					.Error;
				var response = new { error = exception.Message };
				await context.Response.WriteAsJsonAsync(response);
			}));
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
