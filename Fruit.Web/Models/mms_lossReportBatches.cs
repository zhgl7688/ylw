//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fruit.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mms_lossReportBatches
    {
        public int RowId { get; set; }
        public string BillNo { get; set; }
        public string MaterialCode { get; set; }
        public Nullable<decimal> Num { get; set; }
        public Nullable<decimal> Money { get; set; }
        public string SrcBillType { get; set; }
        public string SrcBillNo { get; set; }
        public Nullable<int> SrcRowId { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatePerson { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Remark { get; set; }
    
        public virtual mms_lossReport mms_lossReport { get; set; }
        public virtual mms_lossReport mms_lossReport1 { get; set; }
    }
}
