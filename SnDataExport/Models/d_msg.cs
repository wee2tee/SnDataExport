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
    
    public partial class d_msg
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string users_name { get; set; }
        public System.DateTime chgdat { get; set; }
        public int dealer_id { get; set; }
        public int recby { get; set; }
    
        public virtual dealer dealer { get; set; }
        public virtual users users { get; set; }
    }
}