using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OIDCAppSSO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            string clientID = Configuration.GetSection("OIDCConfig").GetSection("ClientId").Value;
            string clientSecret = Configuration.GetSection("OIDCConfig").GetSection("ClientSecret").Value;
            string authority = Configuration.GetSection("OIDCConfig").GetSection("Authority").Value;

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                }).AddCookie("Cookies")


                      .AddOpenIdConnect("oidc", options =>
                       {
                           options.SignInScheme = "Cookies";
                           options.Authority = Configuration.GetSection("OIDCConfig").GetSection("Authority").Value;
                           options.ClientId = Configuration.GetSection("OIDCConfig").GetSection("ClientId").Value; ;
                           options.ResponseType = "code id_token";
                           options.Scope.Add("openid");
                           options.Scope.Add("profile");
                           options.SaveTokens = true;
                           options.RequireHttpsMetadata = true;
                           options.ClientSecret = Configuration.GetSection("OIDCConfig").GetSection("ClientSecret").Value;
                           options.GetClaimsFromUserInfoEndpoint = true;
                       });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
