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
    
    public partial class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Photo { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Author { get; set; }
        public string FriendlyUrl { get; set; }
        public Nullable<bool> IsPassive { get; set; }
    }
}
