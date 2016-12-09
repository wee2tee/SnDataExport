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
    
    public partial class users
    {
        public users()
        {
            this.cloud_srv = new HashSet<cloud_srv>();
            this.d_msg = new HashSet<d_msg>();
            this.dealer = new HashSet<dealer>();
            this.event_calendar = new HashSet<event_calendar>();
            this.event_calendar1 = new HashSet<event_calendar>();
            this.istab = new HashSet<istab>();
            this.ma = new HashSet<ma>();
            this.note_calendar = new HashSet<note_calendar>();
            this.problem = new HashSet<problem>();
            this.serial = new HashSet<serial>();
            this.serial_password = new HashSet<serial_password>();
            this.spy_log = new HashSet<spy_log>();
            this.training_calendar = new HashSet<training_calendar>();
            this.training_calendar1 = new HashSet<training_calendar>();
            this.websession = new HashSet<websession>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string userpassword { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int level { get; set; }
        public string usergroup { get; set; }
        public string status { get; set; }
        public string allowed_web_login { get; set; }
        public string training_expert { get; set; }
        public int max_absent { get; set; }
        public System.DateTime create_at { get; set; }
        public Nullable<System.DateTime> last_use { get; set; }
    
        public virtual ICollection<cloud_srv> cloud_srv { get; set; }
        public virtual ICollection<d_msg> d_msg { get; set; }
        public virtual ICollection<dealer> dealer { get; set; }
        public virtual ICollection<event_calendar> event_calendar { get; set; }
        public virtual ICollection<event_calendar> event_calendar1 { get; set; }
        public virtual ICollection<istab> istab { get; set; }
        public virtual ICollection<ma> ma { get; set; }
        public virtual ICollection<note_calendar> note_calendar { get; set; }
        public virtual ICollection<problem> problem { get; set; }
        public virtual ICollection<serial> serial { get; set; }
        public virtual ICollection<serial_password> serial_password { get; set; }
        public virtual ICollection<spy_log> spy_log { get; set; }
        public virtual ICollection<training_calendar> training_calendar { get; set; }
        public virtual ICollection<training_calendar> training_calendar1 { get; set; }
        public virtual ICollection<websession> websession { get; set; }
    }
}
