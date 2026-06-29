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
		public DbSet<MContactMethod> ContactMethods { get; set; }

		public List<MAddress> _ltAddresses { get; set; } 
		public List<MContact> ltContact { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure domain classes using modelBuilder here.

			_ltAddresses = new List<MAddress>
			{
				new MAddress { AddressId = "1", ContactId = "1", Plz = "12345", Ort = "City1", Strasse = "Street1", strasseNr = "1", Land = "Country1" },
				new MAddress { AddressId = "2", ContactId = "1", Plz = "67890", Ort = "City2", Strasse = "Street2", strasseNr = "2", Land = "Country2" },
				new MAddress { AddressId = "3", ContactId = "2", Plz = "54321", Ort = "City3", Strasse = "Street3", strasseNr = "3", Land = "Country3" }
			};


			ltContact = new List<MContact>();
			ltContact.Add(new MContact
			{
				ContactId = "01",
				Vorname = "Yannick Clement",
				Nachname = "Gongue Gongue",
				Profilbild = null,
				Addresses = new List<MAddress>
				{
					new MAddress
					{
						AddressId = "01",
						Strasse = "Landwehrstr",
						Ort = "Salzgitter",
						Plz = "38245",
						Land = "Deutschland",
						strasseNr="46"
					}
				},
				ContactMethods = new List<MContactMethod>
				{
					new MContactMethod
					{
						ContactTypeId = "01",
						Value = "gonguegongueyannick@yahoo.fr",
						Type = MContactMethodType.Email

					},

					new MContactMethod
					{
						ContactTypeId = "02",
						Value = "01761234567",
						Type = MContactMethodType.Phone
					}
				}
			});

			modelBuilder.Entity<MContactMethod>()
				  .HasOne<MContact>(c => c.mContact)
				  .WithMany(sp => sp.ContactMethods)
				  .HasForeignKey(s => s.ContactId);


			modelBuilder.Entity<MContact>()
				 .HasKey(ad => ad.ContactId);

			modelBuilder.Entity<MAddress>()
				 .HasOne(st => st.mContact)
				 .WithMany(u => u.Addresses)
				 .HasForeignKey(st => st.ContactId);

		}
	}
}
