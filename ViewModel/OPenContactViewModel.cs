using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace KontaktBuchApp.ViewModel
{
    public class OPenContactViewModel : ViewModelBase
	 {
		public IRelayCommand SaveCommand { get; }

		public OPenContactViewModel()
		{
			SaveCommand = new RelayCommand(SaveContact);
		}

		

		private void SaveContact()
		{
			MessageBox.Show("Save wurde ausgeführt");
		}
	}
}
