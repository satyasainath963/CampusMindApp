using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CampusMindEntityLayer;


namespace CampusMindApp.Models
{
    public class ManagerModel
    {
        TechnologyEntity newTechnologyEntity = new TechnologyEntity();
        
        public TechnologyEntity ConvertTechnologyModelToEntity(TechnologyModel newTechnologyModel)
        {
            newTechnologyEntity.TechnologyId = newTechnologyModel.TechnologyId;
            newTechnologyEntity.TechnologyName = newTechnologyModel.TechnologyName;
            newTechnologyEntity.Description = newTechnologyModel.Description;
            return newTechnologyEntity;
        }

        public LeadEntity ConvertLeadModelToEntity(LeadModel newLeadModel)
        {
            LeadEntity newLeadEntity = new LeadEntity();
            newLeadEntity.LeadId = newLeadModel.LeadId;
            newLeadEntity.LeadName = newLeadModel.LeadName;
            newLeadEntity.TechnologyId = newLeadModel.TechnologyId;
            return newLeadEntity;
        }

       public List<TechnologyModel> ConvertTechnologyEntityToModel(List<TechnologyEntity> technologies)
        {
            List<TechnologyModel> technologyModels = new List<TechnologyModel>();
            foreach (var item in technologies)
            {
                TechnologyModel techModel = new TechnologyModel();
                techModel.TechnologyId = item.TechnologyId;
                techModel.TechnologyName = item.TechnologyName;
                techModel.Description = item.Description;
                technologyModels.Add(techModel);
            }
            return technologyModels;
        }

      public List<LeadModel> ConvertLeadEntityToModel(List<LeadEntity> leadEntities)
        {
            List<LeadModel> leadModels = new List<LeadModel>();
            foreach (var item in leadEntities)
            {
                LeadModel lead = new LeadModel();
                lead.LeadId = item.LeadId;
                lead.LeadName = item.LeadName;
                lead.TechnologyId = item.TechnologyId;
                leadModels.Add(lead);
            }
            return leadModels;
        }
        public List<CandidateModel> ConvertCandidateEntityToModel(List<CandidateEntity> candidates)
        {
            List<CandidateModel> candidateModels = new List<CandidateModel>();
            
            foreach (var item in candidates)
            {
                CandidateModel candidate = new CandidateModel();
                candidate.CandidateId = item.CandidateId;
                candidate.CandidateName = item.CandidateName;
                candidate.TechnologyId = item.TechnologyId;
                candidate.LeadId = item.LeadId;
                candidateModels.Add(candidate);

            }
            return candidateModels;
        }
    }
}