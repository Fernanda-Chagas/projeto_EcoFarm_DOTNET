using EcoFarmAPI.Src.Contextos;
using EcoFarmAPI.Src.Repositorios;
using EcoFarmAPI.Src.Repositorios.Implementacoes;
using EcoFarmAPI.Src.Servicos;
using EcoFarmAPI.Src.Servicos.Implementacoes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoFarmAPI
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
            // Configuração de Banco de dados
            services.AddDbContext<EcoFarmContexto>(opt => opt.UseSqlServer(Configuration["ConnectionStringsDev:DefaultConnection"]));

            //Repositorios
            services.AddScoped<IEstoque, EstoqueRepositorio>();
            services.AddScoped<ICarrinho, CarrinhoRepositorio>();
            services.AddScoped<IUsuario, UsuarioRepositorio>();

            // Controladores
            services.AddCors();
            services.AddControllers();

            // Configuração de Serviços
            services.AddScoped<IAutenticacao, AutenticacaoServicos>();

            // Configuração do Token Autenticação JWTBearer
            var chave = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            services.AddAuthentication(a =>
            {
                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                b.RequireHttpsMetadata = false;
                b.SaveToken = true;
                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(chave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            }
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EcoFarmContexto contexto)
        {
            // Ambiente de Desenvolvimento
            if (env.IsDevelopment())
            { 
                contexto.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
            }

            // Ambiente de produção
            contexto.Database.EnsureCreated();

            //Rotas
            app.UseRouting();

            app.UseCors(c => c
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               );

            // Autenticação e Autorização
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
