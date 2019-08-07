using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Template.Authorization.Roles;
using Template.Authorization.Users;
using Template.MultiTenancy;
using Template.Employees;
using Template.Departments;

namespace Template.EntityFrameworkCore
{
    public class TemplateDbContext : AbpZeroDbContext<Tenant, Role, User, TemplateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            //Address Value Object configuration
            modelBuilder.Entity<Employee>().OwnsOne(m => m.Address, a =>
            {
                a.Property(p => p.FullAddress).HasMaxLength(600).IsRequired()
                    .HasColumnName("FullAddress");
                a.Property(p => p.AppartmentNumber)
                    .HasColumnName("AppartmentNumber");
            });
            //Location Value Object configuration
            modelBuilder.Entity<Department>().OwnsOne(m => m.Location, a =>
            {
                a.Property(p => p.Building).HasMaxLength(50).IsRequired()
                    .HasColumnName("Building");
                a.Property(p => p.Floor)
                    .HasColumnName("Floor");
            });
            
        }
    }
}
