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
    
    public partial class mms_buildPart
    {
        public string BuildPartCode { get; set; }
        public string ProjectCode { get; set; }
        public string BuildPartName { get; set; }
        public string ParentCode { get; set; }
        public string PartAttr { get; set; }
        public string NodeControl { get; set; }
        public Nullable<System.DateTime> ActualBeginTime { get; set; }
        public Nullable<System.DateTime> ActualEndTime { get; set; }
        public string ImagePart { get; set; }
        public string Remark { get; set; }
        public string CreatePerson { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatePerson { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    
        public virtual mms_project mms_project { get; set; }
    }
}
