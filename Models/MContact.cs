using KontakBuchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace KontaktBuchApp.Models
{
	public class MContact
	{
		[Key]
		public string ContactId { get; set; }
		public Byte[]  Profilbild { get; set; } 
		public ImageSource ProfilbildImage { get; set; } 
		public int BildGroesse => Profilbild?.Length ?? 0;
		public string  Nachname { get; set; }
		public string Vorname { get; set; }
		public ICollection <MContactMethod> ContactMethods{ get; set; }
		public ICollection <MAddress> Addresses { get; set; }
	}
}
