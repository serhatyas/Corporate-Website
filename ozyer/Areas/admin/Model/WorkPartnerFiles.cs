//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ozyer.Areas.admin.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkPartnerFiles
    {
        public int Id { get; set; }
        public Nullable<int> WorkPartnerId { get; set; }
        public string Path { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> IsPassive { get; set; }
    }
}
