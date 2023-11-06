using CommunityToolkit.Mvvm.ComponentModel;
using DevExpress.Maui.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiContactApp.Models
{
    internal partial class ContactPerson
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
}
