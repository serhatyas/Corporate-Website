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
    
    public partial class WorkPartners
    {
        public int Id { get; set; }
        public Nullable<int> SectorId { get; set; }
        public Nullable<int> ParticipationsGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Logo { get; set; }
        public string Image { get; set; }
        public string FriendlyUrl { get; set; }
        public Nullable<bool> IsPassive { get; set; }
        public Nullable<bool> IsGroupCompany { get; set; }
    
        public virtual ParticipationsGroups ParticipationsGroups { get; set; }
        public virtual Sectors Sectors { get; set; }
    }
}
