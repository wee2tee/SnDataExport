//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SnDataExport.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class problem
    {
        public int id { get; set; }
        public int? probcod { get; set; }
        public string probdesc { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string name { get; set; }
        public System.DateTime chgdat { get; set; }
        public int serial_id { get; set; }
        public int recby { get; set; }
    
        public virtual istab istab { get; set; }
        public virtual users users { get; set; }
        public virtual serial serial { get; set; }
    }
}
