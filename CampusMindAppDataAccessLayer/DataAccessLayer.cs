using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CampusMindEntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace CampusMindAppDataAccessLayer
{
    public class DataAccessLayer
    {
        public int AddTechnology(TechnologyEntity newTechnology)
        {
            string strConString = "Data Source=DESKTOP-OTH8BE1;Initial Catalog=CampusMind;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into Technologies(TechnologyName,Description) values(@Name, @description)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", newTechnology.TechnologyName);
                cmd.Parameters.AddWithValue("@description",newTechnology.Description );
                cmd.ExecuteNonQuery();
            }
            return 0;
        }

        public int AddLead(LeadEntity newLead)
        {
            string strConString = "Data Source=DESKTOP-OTH8BE1;Initial Catalog=CampusMind;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into Leads(LeadName,TechnologyId) values(@Name, @TechId)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", newLead.LeadName);
                cmd.Parameters.AddWithValue("@TechId", newLead.TechnologyId);
                cmd.ExecuteNonQuery();
            }
            return 0;
        }

        public List<TechnologyEntity> GetAllTechnologies()
        {
            List<TechnologyEntity> Technologies = new List<TechnologyEntity>();
            
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-OTH8BE1;Initial Catalog=CampusMind;Integrated Security=True");
            connection.Open();
            string sqlQuery = string.Format("select * from Technologies");

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            connection.Close();
            
            foreach (DataRow item in table.Rows)
            {
                TechnologyEntity technology = new TechnologyEntity();
                technology.TechnologyId = Convert.ToInt32(item["TechnologyId"]);
                technology.TechnologyName = Convert.ToString(item["TechnologyName"]);
                technology.Description = Convert.ToString(item["Description"]);
                Technologies.Add(technology);
            }
            return Technologies;
        }

        public List<CandidateEntity> GetAllCandidates()
        {
            List<CandidateEntity> Candidates = new List<CandidateEntity>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-OTH8BE1;Initial Catalog=CampusMind;Integrated Security=True");
            connection.Open();
            string sqlQuery = string.Format("select * from Candidates");

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            connection.Close();

            foreach (DataRow item in table.Rows)
            {
                TechnologyEntity technology = new TechnologyEntity();
                CandidateEntity candidate = new CandidateEntity();
                candidate.CandidateId = Convert.ToInt32(item["CandidateId"]);
                candidate.TechnologyId = Convert.ToInt32(item["TechnologyId"]);
                candidate.CandidateName= Convert.ToString(item["CandidateName"]);
                candidate.LeadId= Convert.ToInt32(item["LeadId"]);
                Candidates.Add(candidate);
            }
            return Candidates;
        }

        public List<LeadEntity> GetAllLeads()
        {
            List<LeadEntity> Leads = new List<LeadEntity>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-OTH8BE1;Initial Catalog=CampusMind;Integrated Security=True");
            connection.Open();
            string sqlQuery = string.Format("select * from Leads");

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            connection.Close();

            foreach (DataRow item in table.Rows)
            {
                LeadEntity lead = new LeadEntity();
                lead.LeadId= Convert.ToInt32(item["LeadId"]);
                lead.TechnologyId = Convert.ToInt32(item["TechnologyId"]);
                lead.LeadName= Convert.ToString(item["LeadName"]);
                Leads.Add(lead);
            }
            return Leads;
        }

        public int GetCountOfCandidatesByTechnology(int technologyId)
        {
            List<CandidateEntity> Candidates = new List<CandidateEntity>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-OTH8BE1;Initial Catalog=CampusMind;Integrated Security=True");
            connection.Open();
            string sqlQuery = string.Format("select Count(*) from Candidates where TechnologyId=163");

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            int count= (Int32)command.ExecuteScalar();
            connection.Close();
            return count;
        }

        public int GetCountOfCandidatesByLeads(int LeadId)
        {
            return 0;
        }

    }

}
