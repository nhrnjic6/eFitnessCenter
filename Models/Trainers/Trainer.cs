using Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Trainers
{
    public class Trainer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string CreatedAt { get; set; }
        public UserStatus Status { get; set; }

        public string Name { get { return $"{FirstName} {LastName}"; } }
    }
}
