﻿using System.ComponentModel.DataAnnotations;

namespace LibraryFinalProject.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.EmailAddress , ErrorMessage ="Enter Right Email Address")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public ICollection<Checkouts>? checkouts { get; set; }

    }
}
