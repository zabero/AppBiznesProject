using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFirma.Models.EntitiesForView
{
    public class CustomerPreferencesForAllView
    {
        public int PreferenceID { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string Email{ get; set; }
        public string PhoneNumber{ get; set; }
        public string PreferenceKey { get; set; }
        public string PreferenceValue { get; set; }

    }
}
