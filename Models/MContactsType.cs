using KontaktBuchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KontakBuchApp.Models
{
	public class MContactType
	{
		[Key]
		public int ContactTypeId { get; set; }
		public int ContactId { get; set; }	
		public ContactType Type { get; set; }
		public string Value { get; set; }

		public MContact mContact { get; set; }
	}

	public enum ContactType
	{
		Email,
		Phone,
		Fax,
		Mobile,
		Website
	}
}
