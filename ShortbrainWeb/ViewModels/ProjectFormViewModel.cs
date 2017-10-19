using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShortbrainWeb.Models;

namespace ShortbrainWeb.ViewModels
{
    public class ProjectFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public Project Project { get; set; }
    }
}