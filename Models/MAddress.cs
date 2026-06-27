using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontakBuchApp.Models
{
	public class MAddress
	{		
		[Key]
		public int AddressId { get; set; }
		public int ContactId { get; set; }
		public string Plz { get; set; }
		public string Ort { get; set; }
		public string Strasse { get; set; }
		public string strasseNr { get; set; }
		public string Land { get; set; }

		public MContact mContact { get; set; }
	}
}
