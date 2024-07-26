using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess.DbAccess
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
	{
		public DbSet<EquipmentDetail> EquipmentDetails { get; set; }
		//public DbSet<SuperMaster> SuperMasters { get; set; }
		public DbSet<ZirconMaster> ZirconMasters { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EquipmentDetail>().ToTable("EquipmentDetailsTable");

			//modelBuilder.Entity<SuperMaster>().ToTable("SuperMasterDetailsTable");

			modelBuilder.Entity<ZirconMaster>().ToTable("ZirconMasterDetailsTable");
		}
	}
}
