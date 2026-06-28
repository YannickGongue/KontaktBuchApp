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

		//public List<MContact> ltContact { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure domain classes using modelBuilder here.

			//ltContact = new List<MContact>();
			//ltContact.Add(new MContact
			//{
			//	ContactId = "1",
			//	Vorname = "Yannick Clement",
			//	Nachname = "Gongue Gongue",
			//	Profilbild = null,
			//	addresses = new List<MAddress>
			//	{
			//		new MAddress
			//		{
			//			AddressId = 1,
			//			Strasse = "Landwehrstr",
			//			Ort = "Salzgitter",
			//			Plz = "38245",
			//			Land = "Deutschland",
			//			strasseNr="46"
			//		}
			//	},
			//	kontaktTypes = new List<MContactType>
			//	{
			//		new MContactType
			//		{
			//			ContactTypeId = 01,
			//			Value = "gonguegongueyannick@yahoo.fr",
			//			Type = ContactType.Email

			//		},

			//		new MContactType
			//		{
			//			ContactTypeId = 02,
			//			Value = "01761234567",
			//			Type = ContactType.Phone
			//		}
			//	}
			//});

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
