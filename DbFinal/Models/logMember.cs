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
    
    public partial class logMember
    {
        public int ID { get; set; }
        public Nullable<int> memberId { get; set; }
        public string memberName { get; set; }
        public string memberSurname { get; set; }
        public string log_islem { get; set; }
        public System.DateTime log_tarih { get; set; }
        public string log_olusturan { get; set; }
        public string log_ip { get; set; }
    }
}