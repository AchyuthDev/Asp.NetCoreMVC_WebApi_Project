using Microsoft.EntityFrameworkCore;
using RestuarentComplent.API.Models.DomineModels;
namespace RestuarentComplent.API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }

        //here creating Database Tables
       public DbSet<CountyTbModel> CountryTb { get; set; }
       public DbSet<CityTbModel> CityTb { get; set; }
       public DbSet<CustomerTbModel> CustomerTb { get; set; }
       public DbSet<EstablismentTbModel> EstablismentTb { get;set; }

    }
}
