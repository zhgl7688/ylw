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
    
    public partial class wq_unittype
    {
        [Key, Column(Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string sbbh { get; set; }
        public string sbxh { get; set; }
        public string bbmc { get; set; }
        public string username { get; set; }
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string usercode { get; set; }
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string compcode { get; set; }
        public string CreateDate { get; set; }
        public string remark { get; set; }
    }
}
