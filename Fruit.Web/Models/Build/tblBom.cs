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
    
    public partial class tblBom
    {
        public Guid guidmain { get; set; }
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid guid { get; set; }
        public Guid? parentGUID { get; set; }
        public Guid ProductCode { get; set; }
        public decimal qty { get; set; }
        public decimal? waste { get; set; }
        public string unit { get; set; }
        public bool isBOM { get; set; }
        public string Status { get; set; }
        public string Audit { get; set; }
        public DateTime? AuditDate { get; set; }
        public string CreatePerson { get; set; }
        public DateTime? CreateDate { get; set; }
        public string remark { get; set; }
        public Guid? productkindguid { get; set; }
        public decimal? price { get; set; }
        public decimal? totalmoney { get; set; }
        public string version { get; set; }
        public string bommodel { get; set; }
        public string CT { get; set; }
        public string position { get; set; }
        public string speccode { get; set; }
        public string color { get; set; }
        public string height { get; set; }
        public string lenght { get; set; }
        public string width { get; set; }
        public Guid? clientguid { get; set; }
        public DateTime? begindate { get; set; }
        public byte[] pirtuce { get; set; }
        public Guid? supplierguid { get; set; }
    }
}
