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
    
    public partial class usp_Lend_Result
    {
        public int lendId { get; set; }
        public System.DateTime lendTime { get; set; }
        public int lendLength { get; set; }
        public string bookName { get; set; }
        public string memberName { get; set; }
        public string memberSurname { get; set; }
    }
}