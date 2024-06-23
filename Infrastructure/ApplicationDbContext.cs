using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WorkerHub.Domain.Entities;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        /// <summary>
        /// Dbset is for the table 
        /// and the workuser is the class which cointains the attributes of the table with properties 
        /// </summary>
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<UserAcademic>  Academics { get; set; }
        public DbSet<UserSkills> SkillSets { get; set; }
        public DbSet<UserExperience> Experices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AmountBreakdown> AmountBreakdowns { get; set; }
        public DbSet<vw_EmployeeInfo> vw_EmployeeInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<vw_EmployeeInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_EmployeeInfo");

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Name).HasMaxLength(201);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            base.OnModelCreating(builder);
        }
    }
}
