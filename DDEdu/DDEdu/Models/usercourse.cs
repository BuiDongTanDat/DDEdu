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
    
    public partial class usercourse
    {
        public int id { get; set; }
        public Nullable<int> idUser { get; set; }
        public Nullable<int> idCourse { get; set; }
        public Nullable<System.DateTime> dateBegin { get; set; }
        public string meta { get; set; }
    }
}
