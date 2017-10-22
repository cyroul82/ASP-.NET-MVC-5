using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ShortbrainWeb.Models;

namespace ShortbrainWeb.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        [Required(ErrorMessage = "Renseigner une adresse email valide.")]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


        [Required]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18Years]
        public DateTime? Birthdate { get; set; }
    }
}