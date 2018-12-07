using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OIDCSampleApplication.Utilities;

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

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = Constants.Cookies;
                    options.DefaultChallengeScheme = Constants.Oidc;
                }).AddCookie(Constants.Cookies)


                      .AddOpenIdConnect(Constants.Oidc, options =>
                       {
                           options.SignInScheme = Constants.Cookies;
                           options.Authority = Configuration.GetSection(Constants.OIDCConfig).GetSection(Constants.Authority).Value;
                           options.ClientId = Configuration.GetSection(Constants.OIDCConfig).GetSection(Constants.ClientId).Value;
                           options.ResponseType = Configuration.GetSection(Constants.OIDCConfig).GetSection(Constants.ResponseType).Value;
                           options.Scope.Add(Constants.Openid);
                           options.Scope.Add(Constants.Profile);
                           options.SaveTokens = true;
                           options.RequireHttpsMetadata = true;
                           options.ClientSecret = Configuration.GetSection(Constants.OIDCConfig).GetSection(Constants.ClientSecret).Value;
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
