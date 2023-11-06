using DevExpress.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiContactApp.Models
{
    public class LoginInfo
    {
        [DataFormTextEditor(Placeholder = "Test_Username:Admin")]
        public string Username { get; set; }

        [DataFormPasswordEditor(Placeholder = "Test_Password:1234")]
        public string Password { get; set; }
    }
}
