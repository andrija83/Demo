//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contact
    {
        public int ContactID { get; set; }
        public int ContactTypeID { get; set; }
        public string Ime { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public System.DateTime InsertDate { get; set; }
    
        public virtual ContactType ContactType { get; set; }
    }
}
