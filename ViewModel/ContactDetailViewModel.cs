using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KontaktBuchApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KontaktBuchApp.Models;
using Microsoft.Win32;
using System.Windows.Media;

namespace KontaktBuchApp.ViewModel
{
	public class ContactDetailViewModel : ViewModelBase
	{
		private IFileDialogService _fileDialogService;
		private IImagesService _imageService;
		private IMessageService _messageService;
		private OpenFileDialog _OpenFileDialog;

		private ImageSource _SelectedImage;
		public ImageSource SelectedImage
		{
			get { return this._SelectedImage; }
			set { this._SelectedImage = value;
				OnPropertyChanged(nameof(SelectedImage));
			}
		}

		public IRelayCommand SaveCommand { get; }
		public IRelayCommand DeleteCommand { get; }
		public IRelayCommand AddAddressCommand { get; }
		public IRelayCommand DeleteAddressCommand { get; }
		public IRelayCommand AddContactMethodCommand { get; }
		public IRelayCommand DeleteContactMethodCommand { get; }
		public IRelayCommand ChangeImageCommand { get; }

		public ContactDetailViewModel(IFileDialogService fileDialogService,
			                           IImagesService imageService, 
												IMessageService messageService)
		{
			this._fileDialogService = fileDialogService;
			this._imageService = imageService;
			this._messageService = messageService;
			this.SaveCommand = new RelayCommand(SaveContact);
			this.DeleteCommand = new RelayCommand(DeleteContact);
			this.AddAddressCommand = new RelayCommand(AddAddress);
			this.DeleteAddressCommand = new RelayCommand(DeleteAddress);
			this.AddContactMethodCommand = new RelayCommand(AddContactMethod);
			this.DeleteContactMethodCommand = new RelayCommand(DeleteContactMethod);
			this.ChangeImageCommand = new RelayCommand(ChangeImage);
		}

		private void SaveContact()
		{
			throw new NotImplementedException();
		}

		private void DeleteContact()
		{
			throw new NotImplementedException();
		}

		private void AddAddress()
		{
			throw new NotImplementedException();
		}

		private void DeleteAddress()
		{
			throw new NotImplementedException();
		}

		private void AddContactMethod()
		{
			throw new NotImplementedException();
		}

		private void DeleteContactMethod()
		{
			throw new NotImplementedException();
		}

		private void ChangeImage() {

			try
			{
				this._OpenFileDialog = this._fileDialogService.OpenImageFileDialog();
				this.SelectedImage = this._imageService.LoadImage(this._OpenFileDialog);
			}
			catch (Exception ex)
			{
				this._messageService.ShowMessage(ex.Message);
			}
		}		
	}
}
