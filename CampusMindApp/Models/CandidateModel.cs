using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CampusMindApp.Models
{
    public class CandidateModel
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public int TechnologyId { get; set; }
        public int LeadId { get; set; }
    }
}