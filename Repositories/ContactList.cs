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
		
		public IEnumerable<MContact> GetAll()
		{
			throw new NotImplementedException();
		}

		public MContact? Get(string id)
		{
			throw new NotImplementedException();
		}

		public void Add(MContact contact)
		{
			throw new NotImplementedException();
		}

		public void Update(MContact contact)
		{
			throw new NotImplementedException();
		}

		public void Delete(string id)
		{
			throw new NotImplementedException();
		}
	}
}
