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
    
    public partial class wq_grouppurchase
    {
        public string CompCode { get; set; }
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string DealerCode { get; set; }
        public string DealerType { get; set; }
        public string DealertypeCode { get; set; }
        public int? Quantitygoods { get; set; }
        public decimal? unitprice { get; set; }
        public decimal? Commodityprice { get; set; }
        public string address { get; set; }
        public string tel { get; set; }
        public string phone { get; set; }
        public string Remark { get; set; }
        public string CreatePerson { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdatePerson { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? id { get; set; }
    }
}
