//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class logPublication
    {
        public int ID { get; set; }
        public Nullable<int> publicationId { get; set; }
        public string publicationName { get; set; }
        public string log_islem { get; set; }
        public System.DateTime log_tarih { get; set; }
        public string log_olusturan { get; set; }
        public string log_ip { get; set; }
    }
}
