//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Leo.Blog.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sys_OrgInfo
    {
        public Sys_OrgInfo()
        {
            this.Sys_AccountInfo = new HashSet<Sys_AccountInfo>();
        }
    
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgDesc { get; set; }
        public int ParentOrgId { get; set; }
        public string ParentName { get; set; }
        public string OrgPath { get; set; }
        public Nullable<int> SortNo { get; set; }
        public Nullable<int> IsAutoExpend { get; set; }
        public string IconName { get; set; }
        public int IsEnable { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDT { get; set; }
        public Nullable<int> LastEditBy { get; set; }
        public Nullable<System.DateTime> LastEditDT { get; set; }
    
        public virtual ICollection<Sys_AccountInfo> Sys_AccountInfo { get; set; }
    }
}
