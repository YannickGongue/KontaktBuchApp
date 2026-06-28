using KontakBuchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace KontaktBuchApp.Models
{
	public class MContact
	{
		[Key]
		public string ContactId { get; set; }
		public Byte[]  Profilbild { get; set; }
      public string  Nachname { get; set; }
		public string Vorname { get; set; }
		public ICollection <MContactMethod> kontaktMethods{ get; set; }
		public ICollection <MAddress> addresses { get; set; }
	}
}
