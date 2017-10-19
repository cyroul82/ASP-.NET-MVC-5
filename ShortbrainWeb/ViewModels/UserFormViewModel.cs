using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShortbrainWeb.Migrations;
using ShortbrainWeb.Models;

namespace ShortbrainWeb.ViewModels
{
    public class UserFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public User User { get; set; }
    }
}