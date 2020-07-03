using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Student_Portal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public string DateOfBirth { get; set; }
        //public Gender gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Institution { get; set; }
        public string Program { get; set; }
        public string YearOfJoining { get; set; }


        //public enum Gender
        //{
        //    Male,
        //    Female
        //}

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string rolename) : base(rolename) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<RegisterCourse> RegisterCourse { get; set; }

        public DbSet<FacultyAndRank> facultyAndRanks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Student_Portal.Models.ViewUserGrid> ViewUserGrids { get; set; }

        public System.Data.Entity.DbSet<Student_Portal.Models.FacultyRank> FacultyRanks { get; set; }

        //public System.Data.Entity.DbSet<Student_Portal.Models.ViewUserGrid> ViewUserGrids { get; set; }


        //public System.Data.Entity.DbSet<Student_Portal.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}