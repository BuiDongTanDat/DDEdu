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
    
    public partial class course
    {
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public string detail { get; set; }
        public Nullable<System.DateTime> startOn { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<int> maxStudent { get; set; }
        public Nullable<int> currStudent { get; set; }
        public Nullable<int> tuition { get; set; }
        public Nullable<int> idCategory { get; set; }
        public string meta { get; set; }
        public Nullable<bool> hide { get; set; }
        public string image { get; set; }
    }
}
