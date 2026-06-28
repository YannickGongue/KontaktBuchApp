using KontakBuchApp.Models;
using KontaktBuchApp.Services;
using KontaktBuchApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;

namespace KontaktBuchApp.ViewModel
{
	public class ContactListViewModel : ViewModelBase
	{
		private string searchText;
		private string contactId;
		private string vorname;
		private string nachname;
		private IContactList _IcontactList;
		private ImageSource imagePath;
		private ObservableCollection<MAddress> addresses;
		private ObservableCollection<MContactType> contactTypes;
		private IMessageService _Imessageservice;
		private IImagesService _IimageService;
		private IFileDialogService _fileDialogService;
		private ContactDetailViewModel _vmContactDetail;
		private ContactDetailView ContactDetailView;

		private UcOpenContact ucOpenContact;
		private OPenContactViewModel _vmOpenContact;


		public string SearchText
		{
			get { return searchText; }
			set { searchText = value; 
			      OnPropertyChanged(nameof(this.SearchText)); }
		}

		public string ContactId
		{
			get { return contactId; }
			set
			{
				contactId = value;
				OnPropertyChanged(nameof(this.ContactId));
			}
		}

		public string Vorname
		{
			get { return vorname; }
			set
			{
				vorname = value;
				OnPropertyChanged(nameof(this.Vorname));
			}
		}

		public string Nachname
		{
			get { return nachname; }
			set
			{
				nachname = value;
				OnPropertyChanged(nameof(this.Nachname));
			}
		}

		public ImageSource ImagePath
		{
			get { return imagePath; }
			set
			{
				imagePath = value;
				OnPropertyChanged(nameof(this.ImagePath));
			}
		}

		public ObservableCollection<MAddress> Addresses
		{
			get { return addresses; }
			set
			{
				addresses = value;
				OnPropertyChanged(nameof(this.Addresses));
			}
		}

		public ObservableCollection<MContactType> ContactTypes
		{
			get { return contactTypes; }
			set
			{
				contactTypes = value;
				OnPropertyChanged(nameof(this.ContactTypes));
			}
		}

		public IRelayCommand OpenCommand { get; set; }
		public IRelayCommand AddCommand { get; set; }
		public IRelayCommand SearchCommand { get; set; }

		public ContactListViewModel(IContactList iContactList,
			                         IFileDialogService fileDialogService,
											 IImagesService IimageService,
			                         IMessageService Imessageservice,
			                         OPenContactViewModel vmOpenContact,
											 ContactDetailViewModel vmContactDetail)
		{
			this._IcontactList = iContactList;
			this._fileDialogService = fileDialogService;
			this._IimageService = IimageService;
			this._Imessageservice = Imessageservice;
			this._vmOpenContact = vmOpenContact;
			this._vmContactDetail = vmContactDetail;

			//this._IcontactList.GetAll()
			this.OpenCommand = new RelayCommand(OpenContact);
			this.AddCommand = new RelayCommand(AddContact);
			this.SearchCommand = new RelayCommand(SearchContacts);
		}

		private void SearchContacts()
		{
			throw new NotImplementedException();
		}

		private void AddContact()
		{
			this.ucOpenContact = new UcOpenContact();
			this.ucOpenContact.DataContext = this._vmOpenContact;
			this.ucOpenContact.Show();
		}

		private void OpenContact()
		{	

			this.ContactDetailView = new ContactDetailView();
			this.ContactDetailView.DataContext = this._vmContactDetail;
			this.ContactDetailView.Show();
		}
	}
}
