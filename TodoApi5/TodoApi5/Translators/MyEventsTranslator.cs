using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TodoApi5.Models;
using TodoApi5.Utility;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Configuration;

namespace TodoApi5.Translators
{
    public static class MyEventsTranslator
    {
        #region Event
        public static List<MyEventsModel> TranslateAsMyEventsList(this SqlDataReader reader)
        {
            var list = new List<MyEventsModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsMyEvent(reader, true));
            }
            return list;
        }

        public static MyEventsModel TranslateAsMyEvent(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new MyEventsModel();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("EventTitle"))
                item.EventTitle = SqlHelper.GetNullableString(reader, "EventTitle");

            if (reader.IsColumnExists("EventDate"))
                item.EventDate = SqlHelper.GetNullableDateTime(reader, "EventDate");

            if (reader.IsColumnExists("Category"))
                item.Category = SqlHelper.GetNullableString(reader, "Category");

            if (reader.IsColumnExists("Picture"))
                item.Picture = SqlHelper.GetNullableString(reader, "Picture");

            if (reader.IsColumnExists("Screen_format"))
                item.Screen_format = SqlHelper.GetNullableScreenFormat(reader, "Screen_format");

            if (reader.IsColumnExists("EventVenue"))
                item.EventVenue = SqlHelper.GetNullableString(reader, "EventVenue");

            if (reader.IsColumnExists("Discription"))
                item.Discription = SqlHelper.GetNullableString(reader, "Discription");

            if (reader.IsColumnExists("Organizer"))
                item.Organizer = SqlHelper.GetNullableString(reader, "Organizer");

            return item;
        }
        #endregion

        #region Category
        public static List<CategoriesModel> TranslateAsCategoriesList(this SqlDataReader reader)
        {
            var list = new List<CategoriesModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsCategory(reader, true));
            }
            return list;
        }

        public static CategoriesModel TranslateAsCategory(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new CategoriesModel();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("Category"))
                item.Category = SqlHelper.GetNullableString(reader, "Category");

            return item;
        }
        #endregion

        #region Organizer
        public static List<OrganizersModel> TranslateAsOrganizersList(this SqlDataReader reader)
        {
            var list = new List<OrganizersModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsOrganizer(reader, true));
            }
            return list;
        }

        public static OrganizersModel TranslateAsOrganizer(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new OrganizersModel();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("Organizer"))
                item.Organizer = SqlHelper.GetNullableString(reader, "Organizer");

            if (reader.IsColumnExists("Adress"))
                item.Adress = SqlHelper.GetNullableString(reader, "Adress");

            return item;
        }
        #endregion

        #region Email
        public static List<EmailsModel> TranslateAsEmailsList(this SqlDataReader reader)
        {
            var list = new List<EmailsModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsEmail(reader, true));
            }
            return list;
        }

        public static EmailsModel TranslateAsEmail(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new EmailsModel();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("OrganizerId"))
                item.OrganizerId = SqlHelper.GetNullableInt32(reader, "OrganizerId");

            if (reader.IsColumnExists("Email"))
                item.Email = SqlHelper.GetNullableString(reader, "Email");

            return item;
        }
        #endregion

        #region Phone
        public static List<PhonesModel> TranslateAsPhonesList(this SqlDataReader reader)
        {
            var list = new List<PhonesModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsPhone(reader, true));
            }
            return list;
        }

        public static PhonesModel TranslateAsPhone(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new PhonesModel();

            if (reader.IsColumnExists("Id"))
                item.Id = SqlHelper.GetNullableInt32(reader, "Id");

            if (reader.IsColumnExists("OrganizerId"))
                item.OrganizerId = SqlHelper.GetNullableInt32(reader, "OrganizerId");

            if (reader.IsColumnExists("Phone"))
                item.Phone = SqlHelper.GetNullableString(reader, "Phone");

            return item;
        }
        #endregion
    }
}