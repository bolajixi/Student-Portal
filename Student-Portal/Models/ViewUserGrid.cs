using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student_Portal.Models;

namespace Student_Portal.Models
{
    public class ViewUserGrid
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Program { get; set; }

        public string YearOfJoining { get; set; }

        //------------------------------------------------------------------------
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public string DateOfBirth { get; set; }
        //public Gender gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Institution { get; set; }

    }
}