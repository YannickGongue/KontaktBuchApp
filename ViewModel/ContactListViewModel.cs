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
using KontaktBuchApp.Models;

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
		private ObservableCollection<MContactMethod> contactMethods	;
		private IMessageService _Imessageservice;
		private IImagesService _IimageService;
		private IFileDialogService _fileDialogService;
		private ContactDetailViewModel _vmContactDetail;
		private ContactDetailView ContactDetailView;

		private OpenContactView openContactView;
		private OPenContactViewModel _vmOpenContact;

		private ObservableCollection<MContact> _contacts;
		private MContact _mContact;
		private MContact _selectedContact;
		private ImageSource _imageSource;
		

		public ImageSource ProfilbildImage
		{
			get => this._imageSource;
			set
			{
				_imageSource = value;
				OnPropertyChanged(nameof(ProfilbildImage));
			}
		}


		public MContact SelectedContact
		{
			get => _selectedContact;
			set
			{
				_selectedContact = value;
				OnPropertyChanged(nameof(SelectedContact));
			}
		}
		public ObservableCollection<MContact> Contacts
		{
			get => _contacts;
			set
			{
				_contacts = value;
				OnPropertyChanged(nameof(Contacts));
			}
		}
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

		public ObservableCollection<MContactMethod> ContactMethods
		{
			get { return contactMethods	; }
			set
			{
				contactMethods	 = value;
				OnPropertyChanged(nameof(this.ContactMethods));
			}
		}

		public IRelayCommand OpenCommand { get; set; }
		public IRelayCommand AddCommand { get; set; }
		public IRelayCommand SearchCommand { get; set; }

		public ContactListViewModel(IContactList iContactList,
			                         IFileDialogService fileDialogService,
											 IImagesService IimageService,
			                         IMessageService Imessageservice,
											 ContactDetailViewModel vmContactDetail,
											 MContact mContact)
		{
			this._mContact = mContact;
			this._IcontactList = iContactList;
			this._fileDialogService = fileDialogService;
			this._IimageService = IimageService;
			this._Imessageservice = Imessageservice;
			this._vmContactDetail = vmContactDetail;

			Contacts = _IcontactList.GetAll();

			foreach (var contact in this.Contacts)
			{

				contact.ProfilbildImage = _IimageService.ConvertToImage(contact.Profilbild);
			}



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
			this.ContactDetailView = new ContactDetailView();
			this.ContactDetailView.DataContext = this._vmContactDetail;
			this.ContactDetailView.Show();
			
		}

		//public void Load(MContact contact)
		//{
		//	Vorname = contact.Vorname;
		//	Nachname = contact.Nachname;
		//	ContactId = contact.ContactId;
		//}

		private void OpenContact()
		{

			this._mContact.ContactId = SelectedContact.ContactId;
			this._mContact.Nachname = SelectedContact.Nachname;
			this._mContact.Vorname = SelectedContact.Vorname;
			this._mContact.Profilbild = SelectedContact.Profilbild;
			this._vmOpenContact = new OPenContactViewModel(this._mContact, this._IimageService);
			this.openContactView = new OpenContactView();

			this.openContactView.DataContext = this._vmOpenContact;
			this.openContactView.Show();
		}
	}
}
