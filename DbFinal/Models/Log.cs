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
    
    public partial class Log
    {
        public int logId { get; set; }
        public int changeID { get; set; }
        public string operation { get; set; }
        public string tableName { get; set; }
        public System.DateTime uptadated_at { get; set; }
    }
}