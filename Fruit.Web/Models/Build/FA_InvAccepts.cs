﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已由 FruitBuilder 生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fruit.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public partial class FA_InvAccepts
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FID { get; set; }
        public decimal Amt { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatePerson { get; set; }
        public string CustID { get; set; }
        public DateTime Fdate { get; set; }
        public string PID { get; set; }
        public string Remark { get; set; }
        public DateTime UpdateDate { get; set; }
        public string invoiceTitle { get; set; }
        public string invoiceType { get; set; }
        public string FCode { get; set; }
        public string Corp { get; set; }
    }
}
