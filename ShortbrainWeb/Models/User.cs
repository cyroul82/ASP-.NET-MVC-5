﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortbrainWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}