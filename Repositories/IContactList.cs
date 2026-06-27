using KontaktBuchApp.Models;
using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Services
{
	public interface IContactList
	{
		IEnumerable<MContact> GetAll();
		MContact? Get(string id);
		void Add(MContact contact);
		void Update(MContact contact);
		void Delete(string id);
	}
}
