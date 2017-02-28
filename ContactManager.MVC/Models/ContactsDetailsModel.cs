using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.MVC.Models
{
    public class ContactsDetailsModel
    {
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public string Ime { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public System.DateTime InsertDate { get; set; }
        public string caption { get; set; }
    }
}