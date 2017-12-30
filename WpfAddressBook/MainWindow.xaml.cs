using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAddressBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.dataContacts.ItemsSource = contacts;
		}

		List<Contact> contacts = new List<Contact>
		{
			new Contact() {name="John Sylvester", home="2445566458", mobile="0499004800", email="john.syl@mail.com", address= "Rue de Rivoli 33" },
			new Contact() {name="Mary Woon", home="2344456654", mobile="0445904830", email="mary.won@mail.com", address="Rue de la loi 2" },
			new Contact() {name="Anthony Jacob", home="2034343478", mobile="0484802444", email="anthony.pennen@mail.com", address="Rue de la science 20" }
		};

		// Generate grid columns
		private void grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "name":
					e.Column.Header = "Name";
					break;

				case "home":
					e.Column.Header = "Home";
					break;

				case "mobile":
					e.Column.Header = "Mobile";
					break;

				case "email":
					e.Column.Header = "E-mail";
					break;

				case "address":
					e.Column.Header = "Address";
					break;

				default:
					break;
			}
		}

		// On grid selection changed
		private void dataContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				Contact contact = (Contact)dataContacts.SelectedItem;
				if (contact != null)
				{
					txtName.Text = contact.name;
					txtHome.Text = contact.home;
					txtMobile.Text = contact.mobile;
					txtEmail.Text = contact.email;
					txtAddress.Text = contact.address;
				}
			}
			catch (Exception)
			{ }
		}

		// validate contact from fields
		private bool validateContact()
		{
			if (!txtName.Text.Any())
			{
				MessageBox.Show("You should enter a name!");
				return false;
			}
			if (!txtHome.Text.Any() && !txtMobile.Text.Any() && !txtEmail.Text.Any() && !txtAddress.Text.Any())
			{
				MessageBox.Show("You should fill in at least one field!");
				return false;
			}

			if (txtHome.Text.Any() && !Validator.IsPhoneNumber(txtHome.Text))
			{
				MessageBox.Show("The home phone number is not valid!");
				return false;
			}

			if (txtMobile.Text.Any() && !Validator.IsPhoneNumber(txtMobile.Text))
			{
				MessageBox.Show("The mobile phone number is not valid!");
				return false;
			}

			if (txtEmail.Text.Any() && !Validator.IsEmailValid(txtEmail.Text))
			{
				MessageBox.Show("The email address is not valid!");
				return false;
			}
			return true;
		}
		
		// On Add button clicked
		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			// Validate
			if (!validateContact())
				return;

			// Create a new contact
			Contact contact = new Contact() { name = txtName.Text, home = txtHome.Text, mobile = txtMobile.Text, email = txtEmail.Text, address = txtAddress.Text };

			// Add it to the list
			contacts.Add(contact);

			// Refresh grid data
			dataContacts.Items.Refresh();
		}
		
		// On Modify button clicked
		private void btnModify_Click(object sender, RoutedEventArgs e)
		{
			Contact contact = (Contact)dataContacts.SelectedItem;
			if (contact != null)
			{
				// Validate
				if (!validateContact())
					return;
				contact.name = txtName.Text;
				contact.home = txtHome.Text;
				contact.mobile = txtMobile.Text;
				contact.email = txtEmail.Text;
				contact.address = txtAddress.Text;

				// Refresh grid data
				dataContacts.Items.Refresh();
			}
		}

		// On Delete button clicked
		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			// Create a new contact
			Contact contact = (Contact)dataContacts.SelectedItem;
			if (contact != null)
			{
				MessageBoxResult result = MessageBox.Show("Do you want to delete this contact?", "Confirmation", MessageBoxButton.YesNo);
				if (result == MessageBoxResult.Yes)
				{
					contacts.Remove(contact);

					// Refresh grid data
					dataContacts.Items.Refresh();

					// Clear fields
					txtName.Text = "";
					txtHome.Text = "";
					txtMobile.Text = "";
					txtEmail.Text = "";
					txtAddress.Text = "";
				}
			}
		}
	}
}
