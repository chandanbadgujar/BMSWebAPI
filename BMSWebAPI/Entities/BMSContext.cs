using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BMSWebAPI.Entities
{
    public partial class BMSContext : DbContext
    {
        public BMSContext()
        {
        }

        public BMSContext(DbContextOptions<BMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccountDetail> UserAccountDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BRDIB2H\\SQLEXPRESS;Database=BMS;User Id=sa;Password=Anvi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.AnnualIncome).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.Course).HasMaxLength(50);

                entity.Property(e => e.CourseFee).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.FatherOccupation).HasMaxLength(50);

                entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LoanApplyDate).HasColumnType("date");

                entity.Property(e => e.LoanIssueDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.RationCardNo).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserAccountDetail>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.IdentityProofDocNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InitialDeposit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.ReferanceName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReferenceAccountNo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReferenceAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.GuardianName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.InitialDeposit).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserId).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
