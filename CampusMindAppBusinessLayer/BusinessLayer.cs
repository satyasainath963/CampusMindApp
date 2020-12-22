using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampusMindAppDataAccessLayer;
using CampusMindEntityLayer;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace CampusMindAppBusinessLayer
{
    public class BusinessLayer
    {
        DataAccessLayer accessDataAcessLayer = new DataAccessLayer();
        public int AddTechnology(TechnologyEntity newTechnology)
        {
            // Serialization 
            IFormatter format = new BinaryFormatter();
            Stream serializeObj = new FileStream(@"C:\Users\Sangee\Desktop\FILES\campusMind.txt", FileMode.Create, FileAccess.Write);
            format.Serialize(serializeObj,newTechnology );
            serializeObj.Close();

            // Deserialization
            Stream desearlizeObj = new FileStream(@"C:\Users\Sangee\Desktop\FILES\campusMind.txt", FileMode.Open, FileAccess.Read);
            TechnologyEntity technology = (TechnologyEntity)format.Deserialize(desearlizeObj);

            return accessDataAcessLayer.AddTechnology(newTechnology);

        }

        public int AddLead(LeadEntity newLead)
        {
            return accessDataAcessLayer.AddLead(newLead);
        }

        public List<TechnologyEntity> GetAllTechnologies()
        {
            List<TechnologyEntity> Technologies = accessDataAcessLayer.GetAllTechnologies();
            return Technologies;
        }

        public List<CandidateEntity> GetAllCandidates()
        {
            List<CandidateEntity> Candidates = accessDataAcessLayer.GetAllCandidates();
            return Candidates;
        }

        public List<LeadEntity> GetAllLeads()
        {
            List<LeadEntity> Leads = accessDataAcessLayer.GetAllLeads();
            return Leads;
        }

        public int GetCountOfCandidatesByLeads(int LeadId)
        {
            return accessDataAcessLayer.GetCountOfCandidatesByLeads(LeadId);
        }

        public int GetCountOfCandidatesByTechnology(int technologyId)
        {
            return accessDataAcessLayer.GetCountOfCandidatesByTechnology(technologyId);
        }


    }
}
