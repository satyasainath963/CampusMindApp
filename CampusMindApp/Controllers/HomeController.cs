using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CampusMindApp.Models;
using CampusMindAppBusinessLayer;
using CampusMindEntityLayer;
namespace CampusMindApp.Controllers
{
    public class HomeController : Controller
    {
        BusinessLayer accessBusinessLayer = new BusinessLayer();
        ManagerModel manage = new ManagerModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet][Authorize]
        public ActionResult AddTechnology()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTechnology(TechnologyModel newTechnologyModel)
        {
            TechnologyEntity newTechnologyEntity = manage.ConvertTechnologyModelToEntity(newTechnologyModel);
            accessBusinessLayer.AddTechnology(newTechnologyEntity);
            return View("Index");
        }

        [HttpGet] [Authorize]
        public ActionResult AddLead()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddLead(LeadModel newLeadModel)
        {
            LeadEntity newLeadEntity = manage.ConvertLeadModelToEntity(newLeadModel);
            accessBusinessLayer.AddLead(newLeadEntity);
            return View("Index");
        }
        public ActionResult GetAllTechnologies()
        {
            List<TechnologyEntity> Technologies = accessBusinessLayer.GetAllTechnologies();
            List<TechnologyModel> TechnologyModels = manage.ConvertTechnologyEntityToModel(Technologies);
            ViewBag.Data = TechnologyModels;
            return View();
        }

        [HttpPost]
        public ActionResult GetAllTechnologies(int TechnologyId)
        {
            List<LeadEntity> leadEntities = accessBusinessLayer.GetAllLeads();
            List<LeadModel> leadModels = manage.ConvertLeadEntityToModel(leadEntities);
            List<LeadModel> technologyLeads = new List<LeadModel>();
            foreach (var item in leadModels)
            {
                if(item.TechnologyId==TechnologyId)
                {
                    technologyLeads.Add(item);
                }
            }
            Session["data1"] = technologyLeads;
            return RedirectToAction("GetAllLeads");

        }
        public ActionResult GetAllLeads(List<LeadModel> leadModels)
        {

            ViewBag.Data = Session["data1"];
            return View();
        }

        [HttpPost]
        public ActionResult GetAllLeads(int LeadId)
        {
            List<CandidateEntity> candidateEntities = accessBusinessLayer.GetAllCandidates();
            List<CandidateModel> candidateModels = manage.ConvertCandidateEntityToModel(candidateEntities);
            List<CandidateModel> leadCandidates = new List<CandidateModel>();
            foreach (var item in candidateModels)
            {
                if (item.LeadId == LeadId)
                { leadCandidates.Add(item); }
            }
         
            Session["data"]= leadCandidates;
            return RedirectToAction("GetAllCandidates");
        }

        public ActionResult GetAllCandidates(List<CandidateModel> candidates)
        {
            ViewBag.Data = Session["data"];
            return View();
        }

        public ActionResult TechnologiesAvialble()
        {
            List<TechnologyEntity> Technologies = accessBusinessLayer.GetAllTechnologies();
            List<TechnologyModel> TechnologyModels = manage.ConvertTechnologyEntityToModel(Technologies);
            ViewBag.Data = TechnologyModels;
            return View();
        }

        [HttpPost]
        public ActionResult TechnologiesAvialble(int technologyId)
        {
            int candidatesCount = accessBusinessLayer.GetCountOfCandidatesByTechnology(technologyId);
            string message = "Total Candidates under TechnologyId : " + technologyId + " are - " + candidatesCount;
            Session["message"] = message;
            return RedirectToAction("CountOfCandidatesByTechnology");
        }

        public ActionResult CountOfCandidatesByTechnology()
        {
            return View();
        }

    }
}