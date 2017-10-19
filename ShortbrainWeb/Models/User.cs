using System;
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
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}