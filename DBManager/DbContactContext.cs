using KontakBuchApp.Models;
using KontaktBuchApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.DBManager
{
	public class DbContactContext : DbContext
	{
		public DbContactContext(DbContextOptions<DbContactContext> options) : base(options)
		{
		}
		public DbSet<MContact> Contacts { get; set; }
		public DbSet<MAddress> Addresses { get; set; }	
		public DbSet<MContactType> ContactTypes { get; set; }

		public List<MContact> ltContact { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure domain classes using modelBuilder here.
			

			modelBuilder.Entity<MContactType>()
				  .HasOne<MContact>(c => c.mContact)
				  .WithMany(sp => sp.kontaktTypes)
				  .HasForeignKey(s => s.ContactId);


			modelBuilder.Entity<MContact>()
				 .HasKey(ad => ad.ContactId);

			modelBuilder.Entity<MAddress>()
				 .HasOne(st => st.mContact)
				 .WithMany(u => u.addresses)
				 .HasForeignKey(st => st.ContactId);

		}
	}
}
