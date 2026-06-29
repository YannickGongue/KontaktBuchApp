using KontakBuchApp.Models;
using KontaktBuchApp.DBManager;
using KontaktBuchApp.Models;
using KontaktBuchApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Repositories
{
	public class ContactList : IContactList
	{
		//private DbContactContext _dbContext;
		public ObservableCollection<MContact> ltContact;
		public ContactList() {

			string base64 =
	 "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO5W5r8AAAAASUVORK5CYII=";
			//this._dbContext = dbContext;
			this.ltContact = new ObservableCollection<MContact>();
			ltContact.Add(new MContact
			{
				ContactId = "01",
				Vorname = "Yannick Clement",
				Nachname = "Gongue Gongue",
				Profilbild = File.ReadAllBytes(@"C:\Temp\Testbild.jpg"),
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
		}
		
		public ObservableCollection<MContact> GetAll()
		{
			return new ObservableCollection<MContact>(ltContact);
		}

		public MContact? Get(string id)
		{
			return this.ltContact.FirstOrDefault(c => c.ContactId == id);
		}

		public void Add(MContact contact)
		{
			this.ltContact.Add(contact);
		}

		public void Update(MContact contact)
		{
			var existing = Get(contact.ContactId);
			if (existing == null) return;
			existing.Nachname = contact.Nachname;
			existing.Vorname = contact.Vorname;
			existing.Profilbild = contact.Profilbild;
			existing.Addresses = contact.Addresses;
			existing.ContactMethods = contact.ContactMethods;
		}

		public void Delete(string id)
		{
			var item = Get(id);
			if (item != null)
				this.ltContact.Remove(item);
		}
	}
}
