using ozyer.Areas.admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ozyer.Models
{
    public class ServiceModel
    {

        public Users User { get; set; }
        public List<Users> UserList { get; set; }

        public ContactMessages ContactMessage { get; set; }
        public List<ContactMessages> ContactMessageList { get; set; }

        public WorkPartners workPartners { get; set; }
        public List<WorkPartners> workPartnerList { get; set; }

        public Sectors Sector { get; set; }
        public List<Sectors> SectorList { get; set; }
        public ParticipationsGroups ParticipationsGroups { get; set; }
        public List<ParticipationsGroups> ParticipationsGroupsList { get; set; }
        public Participations Participations { get; set; }
        public List<Participations> ParticipationList { get; set; }
        public List<WorkPartnerFiles> WorkPartnerFileList { get; set; }
        public Pages Page { get; set; }
        public List<Pages> PageList { get; set; }
        public Settings Setting { get; set; }
        public List<Settings> SettingList { get; set; }
        public Blog Blog { get; set; }
        public List<Blog> BlogList { get; set; }
    }
}