//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillInfo
    {
        public int BillId { get; set; }
        public int ServiceRef { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public decimal Qty { get; set; }
        public Nullable<decimal> ItemAmount { get; set; }
    
        public virtual ItemsInfo ItemsInfo { get; set; }
        public virtual ServiceRecordInfo ServiceRecordInfo { get; set; }
    }
}
