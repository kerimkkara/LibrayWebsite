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
    
    public partial class logLend
    {
        public int ID { get; set; }
        public Nullable<int> lendId { get; set; }
        public System.DateTime lendTime { get; set; }
        public int lendLength { get; set; }
        public int memberId { get; set; }
        public int bookId { get; set; }
        public string log_islem { get; set; }
        public System.DateTime log_tarih { get; set; }
        public string log_olusturan { get; set; }
        public string log_ip { get; set; }
    }
}