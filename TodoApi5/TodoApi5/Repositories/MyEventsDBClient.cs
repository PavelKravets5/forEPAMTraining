using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi5.Translators;
using TodoApi5.Models;
using TodoApi5.Utility;
using System.Data;
using System.Data.SqlClient;

namespace TodoApi5.Repository
{
    public class MyEventsDBClient
    {
        public List<MyEventsModel> GetAllMyEvents(string connectstring)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<MyEventsModel>>(connectstring, "GetMyEvents", r => r.TranslateAsMyEventsList());
        }

        public string SaveMyEvent(MyEventsModel model, string connectionString)
        {

            if(model.Picture==null)
            {
                model.Picture = "";
            }
            if(model.Screen_format==null)
            {
                model.Screen_format = "";
            }
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@EventId",model.Id),
                new SqlParameter("@EventTitle",model.EventTitle),
                new SqlParameter("@EventDate",model.EventDate),
                new SqlParameter("@Category",model.Category),
                new SqlParameter("@Picture",model.Picture),
                new SqlParameter("@Screen_format",model.Screen_format),
                new SqlParameter("@EventVenue",model.EventVenue),
                new SqlParameter("@Discription",model.Discription),
                new SqlParameter("@Organizer",model.Organizer),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "SaveMyEvent", param);
            return (string)outParam.Value;
        }

        public string DeleteMyEvent(int id, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@EventId",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "DeleteMyEvent", param);
            return (string)outParam.Value;
        }

        public List<OrganizersModel> GetAllOrganizers(string connectstring)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<OrganizersModel>>(connectstring, "GetOrganizers", r => r.TranslateAsOrganizersList());
        }

        public string SaveOrganizer(OrganizersModel model, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Organizer",model.Organizer),
                new SqlParameter("@Adress",model.Adress),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "SaveOrganizer", param);
            return (string)outParam.Value;
        }

        public string DeleteOrganizer(int id, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "DeleteOrganizer", param);
            return (string)outParam.Value;
        }


        public List<CategoriesModel> GetAllCategories(string connectstring)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<CategoriesModel>>(connectstring, "GetCategories", r => r.TranslateAsCategoriesList());
        }

        public string SaveCategory(CategoriesModel model, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Category",model.Category),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "SaveCategory", param);
            return (string)outParam.Value;
        }

        public string DeleteCategory(int id, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "DeleteCategory", param);
            return (string)outParam.Value;
        }

        public List<EmailsModel> GetEmailsById(int id,string connectstring)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@OrganizerId",id)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<EmailsModel>>(connectstring, "GetEmailsByOrganizerId", r => r.TranslateAsEmailsList(),param);
        }

        public string SaveEmail(EmailsModel model, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@OrganizerId",model.OrganizerId),
                new SqlParameter("@Email",model.Email),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "SaveEmail", param);
            return (string)outParam.Value;
        }

        public string DeleteEmail(int Id, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",Id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "DeleteEmail", param);
            return (string)outParam.Value;
        }

        public List<PhonesModel> GetPhonesById(int id, string connectstring)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@OrganizerId",id)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<PhonesModel>>(connectstring, "GetPhonesByOrganizerId", r => r.TranslateAsPhonesList(), param);
        }

        public string SavePhone(PhonesModel model, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@OrganizerId",model.OrganizerId),
                new SqlParameter("@Phone",model.Phone),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "SavePhone", param);
            return (string)outParam.Value;
        }

        public string DeletePhone(int Id, string connectionString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param =
            {
                new SqlParameter("@Id",Id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connectionString, "DeletePhone", param);
            return (string)outParam.Value;
        }
    }
}
