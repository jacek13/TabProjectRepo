using DataBaseAccess.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabPizzaRestaurant.Data;
using Repository.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;
using Repository.Services;

namespace TabPizzaRestaurant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContextFactory<RestaurantDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddDbContext<RestaurantDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default")));


            services.AddScoped<IRepository<Account>, AccountRepository>();
            services.AddScoped<AccountService>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ClientService>();

            services.AddScoped<AccountManagmentService>();

            services.AddScoped<IRepository<Dishes>, DishesRepository>();
            services.AddScoped<DishesService>();

            services.AddScoped<IRepository<ManagerAssignment>, ManagerAssignmentRepository>();
            services.AddScoped<ManagerAssigmentService>();

            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<OrderService>();

            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<PizzaService>();

            services.AddScoped<IRepository<Reservation>, ReservationRepository>();
            services.AddScoped<ReservationService>();

            services.AddScoped<IRepository<Table>, TableRepository>();
            services.AddScoped<TableService>();

            services.AddBlazoredSessionStorage();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
