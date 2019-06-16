using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Suplements
{
    public class SuplementPayment
    {
        public int Id { get; set; }
        public string SuplementName { get; set; }
        public int Amount { get; set; }
        public double TotalPrice { get; set; }
        public string ClientName { get; set; }
        public string EmployeeName { get; set; }
        public string CreatedAt { get; set; }
    }
}
