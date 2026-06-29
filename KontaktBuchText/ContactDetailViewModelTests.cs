using KontaktBuchApp.Models;
using KontaktBuchApp.ViewModel;

namespace KontaktBuchText;

[TestClass]
public class ContactDetailViewModelTests
{
    [TestMethod]
	public void SaveContact_Should_Update_Model()
	{
		// Arrange
		var contact = new MContact();
		var address = new MAddress();
		var contactMethod = new MContactMethod();

		var vm = new ContactDetailViewModel(
			 fileDialogService: null,
			 imageService: null,
			 messageService: null,
			 contactDetails: null,
			 contactList: null,
			 mContact: contact,
			 mAddress: address,
			 mContactMethod: contactMethod
		);

		vm.FirstName = "Yannick";
		vm.LastName = "Gongue";

		// Act
		vm.SaveCommand.Execute(null);

		// Assert
		Assert.AreEqual("Yannick", contact.Vorname);
		Assert.AreEqual("Gongue", contact.Nachname);
	}
}
