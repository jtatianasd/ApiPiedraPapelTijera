using ApiPiedraPapelTijera.Data;
using ApiPiedraPapelTijera.Repository;
using ApiPiedraPapelTijera.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiPiedraPapelTijera.JuegoMappers;
using AutoMapper;
using System;
using System.Reflection;
using System.IO;

namespace ApiPiedraPapelTijera
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
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexion")));
			services.AddScoped<IPartidaRepository, PartidaRepository>();
			services.AddScoped<IJugadorRepository, JugadorRepository>();
			services.AddControllers();
			services.AddAutoMapper(typeof(ApiPiedraPapelTijera.JuegoMappers.JuegoMappers));

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("ApiPiedraPapelTijera", new Microsoft.OpenApi.Models.OpenApiInfo()
				{
					Title = "API Piedra papel o Tijera",
					Version = "1",
					Description = "Backend  Piedra papel o Tijera",
					Contact = new Microsoft.OpenApi.Models.OpenApiContact()
					{
						Email = "jtatianasd@gmail.com",
						Name = "Tatiana Salamanca",
		
					},
					License = new Microsoft.OpenApi.Models.OpenApiLicense()
					{
						Name = "MIT License",
						Url = new Uri("https://es.wikipedia.org/wiki/Licencia_MIT")
					}
				}); ;
				var archivoXmlComentarios = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var rutaApiComentarios = Path.Combine(AppContext.BaseDirectory, archivoXmlComentarios);
				options.IncludeXmlComments(rutaApiComentarios);
			}
);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/ApiPiedraPapelTijera/swagger.json", "API Piedra papel o Tijera");
				options.RoutePrefix = "";
			});
			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
