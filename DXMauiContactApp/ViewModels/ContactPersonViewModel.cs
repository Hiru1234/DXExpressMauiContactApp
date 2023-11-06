using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Maui.Core;
using DXMauiContactApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiContactApp.ViewModels
{
    internal partial class ContactPersonViewModel: ObservableObject
    {
        [ObservableProperty]
        public static ObservableCollection<ContactPerson> contactPeople = new ObservableCollection<ContactPerson>()
        {
                new ContactPerson{ContactId= "20231105101423111", FirstName= "Nancy",LastName = "Davolio", Phone = "(206) 555-9857" },
                new ContactPerson{ContactId= "20231105101423112", FirstName="Andrew", LastName ="Fuller",Phone = "(206) 555-9482" },
                new ContactPerson{ContactId= "20231105101423113", FirstName="Janet", LastName ="Leverling", Phone ="(206) 555-3412" },
                new ContactPerson{ContactId= "20231105101423114", FirstName="Margaret", LastName ="Peacock", Phone ="(206) 555-8122" },
                new ContactPerson{ContactId= "20231105101423115", FirstName="Steven",LastName = "Buchanan", Phone ="(071) 555-4848" },
                new ContactPerson{ContactId= "20231105101423116", FirstName="Michael",LastName = "Suyama",Phone = "(071) 555-7773" },
                new ContactPerson{ContactId= "20231105101423117", FirstName="Robert", LastName ="King",Phone = "(071) 555-5598" },
                new ContactPerson{ContactId= "20231105101423118", FirstName="Laura",LastName = "Callahan",Phone = "(206) 555-1189" },
                new ContactPerson{ContactId= "20231105101423119", FirstName="Anne", LastName ="Dodsworth",Phone = "(071) 555-4444" },
        };

        [ObservableProperty]
        public static ContactPerson person = new();

        [RelayCommand]
        public void AddContact()
        {
            if (Person != null) 
            {
                if (string.IsNullOrEmpty(Person.FirstName) || string.IsNullOrEmpty(Person.LastName) || string.IsNullOrEmpty(Person.Phone)) {
                    return;
                }
                Person.ContactId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                ContactPeople.Add(Person);
            }
        }

        [RelayCommand]
        public void DeleteContact()
        {
            if (Person == null || string.IsNullOrEmpty(Person.ContactId)) return;

            var contactToDelete = ContactPeople.FirstOrDefault(x => x.ContactId.Equals(Person.ContactId));

            if(contactToDelete != null) {
                ContactPeople.Remove(contactToDelete);
            }
        }

        [RelayCommand]
        public void UpdateContact()
        {
            if (Person == null || 
                string.IsNullOrEmpty(Person.ContactId) ||
                string.IsNullOrEmpty(Person.FirstName) || 
                string.IsNullOrEmpty(Person.LastName) || 
                string.IsNullOrEmpty(Person.Phone)) return;

            var contactToUpdate = ContactPeople.FirstOrDefault(x => x.ContactId.Equals(Person.ContactId));
            if (contactToUpdate != null)
            {
                contactToUpdate.FirstName = Person.FirstName;
                contactToUpdate.LastName = Person.LastName;
                contactToUpdate.Phone = Person.Phone;
            }
        }

        public static ContactPerson GetContactById(string contactId)
        {
            var contact = contactPeople.FirstOrDefault(x => x.ContactId.Equals(contactId));
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

    }
}
