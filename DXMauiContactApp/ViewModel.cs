//using DevExpress.Android.Editors.Model.Masks;
using DevExpress.Maui.Core;
using DevExpress.Maui.DataForm;
using DXMauiContactApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiContactApp
{
    public class LoginInfo {
        [DataFormTextEditor(Placeholder = "Test_Username:admin")]
        public string Username { get; set; }

        [DataFormPasswordEditor(Placeholder = "Test_Password:1234")]
        public string Password { get; set; }
    }

    public class PersonalInfo
    {
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        [DataFormMaskedEditor(Mask = "(000) 000-0000", Keyboard = "Telephone")]
        public string Phone {  get; set; }
    }

    public class ContactPerson : BindableBase
    {
        public string ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string Initials
        {
            get
            {
                if (FirstName == null || LastName == null)
                    return "?";
                return FirstName.Substring(0, 1) + LastName.Substring(0, 1);
            }
        }

        Color categoryColor;
        public Color CategoryColor
        {
            get
            {
                if (categoryColor == null)
                {
                    categoryColor = ContactColors.GetRandomColor();
                }
                return categoryColor;
            }
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public List<ContactPerson> Data { 
            get => _data; 
            set {
            }
        }
        public static List<ContactPerson> _data = new List<ContactPerson>()
        {
                new ContactPerson{ContactId = "20231019133628051", FirstName= "Nancy",LastName = "Davolio", Phone = "(206) 555-9857" },
                new ContactPerson{ContactId = "20231019133628052", FirstName="Andrew", LastName ="Fuller",Phone = "(206) 555-9482" },
                new ContactPerson{ContactId = "20231019133628053", FirstName="Janet", LastName ="Leverling", Phone ="(206) 555-3412" },
                new ContactPerson{ContactId = "20231019133628054", FirstName="Margaret", LastName ="Peacock", Phone ="(206) 555-8122" },
                new ContactPerson{ContactId = "20231019133628055", FirstName="Steven",LastName = "Buchanan", Phone ="(071) 555-4848" },
                new ContactPerson{ContactId = "20231019133628056", FirstName="Michael",LastName = "Suyama",Phone = "(071) 555-7773" },
                new ContactPerson{ContactId = "20231019133628057", FirstName="Robert", LastName ="King",Phone = "(071) 555-5598" },
                new ContactPerson{ContactId = "20231019133628058", FirstName="Laura",LastName = "Callahan",Phone = "(206) 555-1189" },
                new ContactPerson{ContactId = "20231019133628059", FirstName="Anne", LastName ="Dodsworth",Phone = "(071) 555-4444" },
        };

        public static void AddContact(ContactPerson contact)
        {
             _data.Add(contact);
        }

        public static void DeleteContact(string contactId)
        {
            var contact = _data.FirstOrDefault(x => x.ContactId.Equals(contactId));

            if (contact != null)
            {
                _data.Remove(contact);
            }
        }

        public static void UpdateContact
            (string contactId, ContactPerson contact)
        {
            if (!contactId.Equals(contact.ContactId)) return;

            var contactToUpdate = _data.FirstOrDefault(x => x.ContactId.Equals(contactId));
            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = contact.FirstName;
                contactToUpdate.LastName = contact.LastName;
                contactToUpdate.Phone = contact.Phone;
            }

        }

        public static ContactPerson GetContactById(string contactId)
        {
            var contact = _data.FirstOrDefault(x => x.ContactId.Equals(contactId));
            if (contact != null)
            {
                return new ContactPerson
                {
                    ContactId = contactId,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Phone = contact.Phone,
                };
            }
            return null;
        }

        public static ContactPerson MapUserDataToModel(PersonalInfo personalInfo)
        {
            ContactPerson contactPerson = new ContactPerson();
            contactPerson.FirstName = personalInfo.FirstName;
            contactPerson.LastName = personalInfo.LastName;
            contactPerson.Phone = personalInfo.Phone;
            return contactPerson;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ContactColors
    {
        public static Color GetRandomColor()
        {
            return GetColor(new Random().Next(10));
        }
        public static Color GetColor(int colorNumber)
        {
            switch (colorNumber)
            {
                case 1: return Color.FromArgb("#f15558");
                case 2: return Color.FromArgb("#ff7c11");
                case 3: return Color.FromArgb("#ffbf22");
                case 4: return Color.FromArgb("#ff6e86");
                case 5: return Color.FromArgb("#9865b0");
                case 6: return Color.FromArgb("#756cfd");
                case 7: return Color.FromArgb("#0055d8");
                case 8: return Color.FromArgb("#01b0ee");
                case 9: return Color.FromArgb("#0097ad");
                case 0: return Color.FromArgb("#00c831");
                default: return Color.FromArgb("#949494");
            }
        }
    }
}
