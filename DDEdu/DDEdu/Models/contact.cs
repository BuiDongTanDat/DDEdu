//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DDEdu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class contact
    {
        public int id { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string addressGPS { get; set; }
        public string hotline { get; set; }
        public string meta { get; set; }
        public Nullable<bool> hide { get; set; }
        public string name { get; set; }
    }
}