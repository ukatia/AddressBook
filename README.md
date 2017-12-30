# AddressBook
C# Wpf Address Book 

## Build
Microsoft Visual Studio 2017
### Code Structure
```
WpfAddressBook/
   /App.config 
   /App.xaml
   /Contact.cs
   /MainWindow.cs
   /MainWindow.xaml
   /Validator.cs
```
``` App.config ``` - Application configuration  <br/>
``` App.xaml ``` - Application-scope resources file <br/>
``` Contact.cs ``` - contains Contact class  <br/>
Class members: name, home, mobile, email, address <br/>
``` MainWindow.cs ``` - code of Main window application <br/>
```  MainWindow.xaml ``` - layout of Main Window <br/>
``` Validator.cs ``` - contains Validator class for field validation<br/>
### UI
The main window contains a datagrid with the contacts. The columns are the members of the Contact class and the rows the objects contained in the list 'contacts'.<br/>
Below, there are textboxes with labels where the user can set every field and add a new contact, modify or remove an existing contact by clicking on the corresponding button.<br/>

