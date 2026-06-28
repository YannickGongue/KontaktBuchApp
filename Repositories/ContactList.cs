using KontaktBuchApp.DBManager;
using KontaktBuchApp.Models;
using KontaktBuchApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Repositories
{
	public class ContactList : IContactList
	{
		//private DbContactContext _dbContext;
		public List<MContact> ltContact;
		public ContactList() {
		
			//this._dbContext = dbContext;
			this.ltContact = new List<MContact>();
		}
		
		public List<MContact> GetAll()
		{
			return this.ltContact.ToList();
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
			existing.addresses = contact.addresses;
			existing.kontaktTypes = contact.kontaktTypes;
		}

		public void Delete(string id)
		{
			var item = Get(id);
			if (item != null)
				this.ltContact.Remove(item);
		}
	}
}
