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
    
    public partial class tbCRMCustomer
    {
        [Key, Column(Order = 0)]
        public Guid Code { get; set; }
        public Guid? CustomerType { get; set; }
        public Guid? CustomerLevel { get; set; }
        public string Name { get; set; }
        public string CustomerID { get; set; }
        public string Contacts { get; set; }
        public string Telephone { get; set; }
        public string Mobilephone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string AreaCode { get; set; }
        public string QQ { get; set; }
        public string MSN { get; set; }
        public Guid? ChildCode { get; set; }
        public Guid? IntentionType { get; set; }
        public string Creater { get; set; }
        public string CreateTime { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string Remark { get; set; }
        public int? Sort { get; set; }
        public int? Status { get; set; }
    }
}
