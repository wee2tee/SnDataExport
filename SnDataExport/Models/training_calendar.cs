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
    
    public partial class training_calendar
    {
        public int id { get; set; }
        public System.DateTime date { get; set; }
        public int course_type { get; set; }
        public int status { get; set; }
        public int term { get; set; }
        public string remark { get; set; }
        public System.DateTime chgdat { get; set; }
        public int users_id { get; set; }
        public int recby { get; set; }
    
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
    }
}