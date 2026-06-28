using KontakBuchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace KontaktBuchApp.Models
{
	public class MContactMethod
	{
		[Key]
		public int ContactTypeId { get; set; }
		public int ContactId { get; set; }
		public string Value { get; set; }

		public MContact mContact { get; set; }
		public MContactMethodType Type { get; set; }
	}
}
