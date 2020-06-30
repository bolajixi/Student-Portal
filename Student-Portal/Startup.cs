using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Student_Portal.Startup))]
namespace Student_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();
        //    services.AddRazorPages();
        //    services.AddAuthorization(options =>
        //    {
        //        options.AddPolicy("AtLeast21", policy =>
        //            policy.Requirements.Add(new MinimumAgeRequirement(21)));
        //    });
        //}
    }
}
