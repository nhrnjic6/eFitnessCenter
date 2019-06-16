using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Requests.Suplements
{
    public class SuplementPaymentRequest
    {   
        [Required]
        public int ClientId { get; set; }
        [Required]
        public int SuplementId { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
