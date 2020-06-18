using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserServices.Models
{
	public partial class ApiDemoContext : DbContext
	{
		public ApiDemoContext()
		{
		}

		public ApiDemoContext(DbContextOptions<ApiDemoContext> options)
			: base(options)
		{
		}

		public virtual DbSet<TblUser> TblUser { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=DESKTOP-EHKPLN2;Database=ApiDemo;Trusted_Connection=True;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TblUser>(entity =>
			{
				entity.ToTable("tbl_User");

				entity.Property(e => e.Address).IsRequired();

				entity.Property(e => e.DateOfBirth).HasColumnType("date");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Name).IsRequired();
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
