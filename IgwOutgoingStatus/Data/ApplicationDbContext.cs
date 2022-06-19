using IgwOutgoingStatus.Models;
using Microsoft.EntityFrameworkCore;

namespace IgwOutgoingStatus.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Igw_Loss_Record>().HasNoKey();
        //    modelBuilder.Entity<Igw_Prft_Record>().HasNoKey();
        //}

        public DbSet<Igw_Loss_Record> Igw_D_Stat_OG_Loss_Record { get; set; }
        public DbSet<Igw_Prft_Record> Igw_D_Stat_OG_Prft_Record { get; set; }
    }
}
