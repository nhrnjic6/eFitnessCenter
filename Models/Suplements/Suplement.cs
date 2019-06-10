using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Suplements
{
    public class Suplement
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SumplementTypeId { get; set; }
        public SuplementType SuplementType { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string MessureUnit { get; set; }
    }
}
