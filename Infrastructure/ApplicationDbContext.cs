using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkerHub.Domain.Entities;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Dbset is for the table 
        /// and the workuser is the class which cointains the attributes of the table with properties 
        /// </summary>
        public DbSet<ApplicationUser> applicationUser { get; set; }
        public DbSet<UserAcademic> Academics { get; set; }
        public DbSet<UserSkills> SkillSets { get; set; }
        public DbSet<UserExperience> Experices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AmountBreakdown> AmountBreakdowns { get; set; }
        public DbSet<vw_EmployeeInfo> vw_EmployeeInfo { get; set; }
        public DbSet<vw_EmployeeList> vw_EmployeeLists { get; set; }
        public DbSet<vw_HiringMangersList> vw_HiringMangersLists { get; set; }
        public DbSet<sp_GetTotalCount> sp_GetTotalCount { get; set; }

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

            builder.Entity<vw_EmployeeList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_EmployeeList");

                entity.Property(e => e.Bloodgroup)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bloodgroup");

                entity.Property(e => e.Citizenship)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("citizenship");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Descripition).HasMaxLength(255);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Name).HasMaxLength(201);

                entity.Property(e => e.PermanentAddress).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(256);

                entity.Property(e => e.Sex).HasMaxLength(10);

                entity.Property(e => e.States)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("states");

                entity.Property(e => e.Streetname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("streetname");

                entity.Property(e => e.TemporaryAddress).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            builder.Entity<vw_HiringMangersList>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_HiringMangersList");

                entity.Property(e => e.Bloodgroup)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("bloodgroup");

                entity.Property(e => e.Citizenship)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("citizenship");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("country");

                entity.Property(e => e.Descripition).HasMaxLength(255);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Id).HasMaxLength(450);

                entity.Property(e => e.Img)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.Name).HasMaxLength(201);

                entity.Property(e => e.PermanentAddress).HasMaxLength(255);

                entity.Property(e => e.Role).HasMaxLength(256);

                entity.Property(e => e.Sex).HasMaxLength(10);

                entity.Property(e => e.States)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("states");

                entity.Property(e => e.Streetname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("streetname");

                entity.Property(e => e.TemporaryAddress).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            builder.Entity<sp_GetTotalCount>(entity =>
            {
                entity.HasNoKey();
            });

            base.OnModelCreating(builder);
        }
    }
}
