using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyChat.Server.Infrastructure;
using MyChat.Domain.Repository;
using MyChat.Server.Repository;
using MyChat.Domain.Service.chime;
using MyChat.Domain.Service.room;
using MyChat.Domain.Service.message;
using MyChat.Domain.Service.user;
using MyChat.Domain.Service.common;
using MyChat.Server.Repository.message;
using MyChat.Server.Repository.room;
using MyChat.Server.Repository.user;
using MyChat.Server.Hub;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;

namespace MyChat.Server
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
            services.AddControllersWithViews();

            services.AddRazorPages();
            services.AddSignalR()
            .AddNewtonsoftJsonProtocol(options =>
              {
                  options.PayloadSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                  options.PayloadSerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
              });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:8081")
                 .SetIsOriginAllowed((host) => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
            });
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "dist"; });

            /*
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("UserDatabase"))); */

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("UserDatabase")));


            // =======================
            // # INJECT REPOSITORIES #
            // =======================
            services.AddScoped<IUnitOfWork, UnitOfWork>();
                services.AddScoped<IMessageRepository, MessageRepository>();
                services.AddScoped<IRoomRepository, RoomRepository>();
                services.AddScoped<IUserRepository, UserRepository>();

                // ===================
                // # INJECT SERVICES #
                // ===================
                services.AddScoped<IMessageService, MessageService>();
                services.AddScoped<IRoomService, RoomService>();
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IChimeService, ChimeService>();
                services.AddScoped<ICommonService, CommonService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // WebRootPath == null workaround. - from https://github.com/aspnet/Mvc/issues/6688
            if (string.IsNullOrWhiteSpace(env.WebRootPath))
            {
                env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "dist");
            }

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                FileProvider = new PhysicalFileProvider(env.WebRootPath) // important or it doesn't know where to look for
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                },
                FileProvider = new PhysicalFileProvider(env.WebRootPath) // same as UseDefaultFiles
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
                endpoints.MapHub<ChatHub>("/chathub");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "dist";
            });

        }



    }
}
