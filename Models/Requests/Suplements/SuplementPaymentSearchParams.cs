using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests.Suplements
{
    public class SuplementPaymentSearchParams
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string SuplementName { get; set; }
        public string SuplementType { get; set; }
    }
}
