using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstCore_webapp.Models
{
    public partial class CompanyDBContext : DbContext
    {
        public CompanyDBContext()
        {
        }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmpDepartment> EmpDepartment { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
      

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CompanyDB;Integrated Security=True");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpDepartment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Emp_Department");

                entity.Property(e => e.Department)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Employee");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Designation)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
