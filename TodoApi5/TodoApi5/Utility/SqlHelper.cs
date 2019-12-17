using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.Common;
using System.Drawing;
using System.Text;

namespace TodoApi5.Utility
{
    public static class SqlHelper
    {
        public static string ExecuteProcedureReturnString
            (string connString, string procName,params SqlParameter[] paramters)
        {
            string result = "";
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procName;
                    if (paramters != null)
                    {
                        command.Parameters.AddRange(paramters);
                    }
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                    var ret = command.Parameters["@ReturnCode"].Value;
                    if (ret != null)
                        result = Convert.ToString(ret);
                }
            }
            return result;
        }

        public static TData ExtecuteProcedureReturnData<TData>
            (string connString, string procName,Func<SqlDataReader, TData> translator,params SqlParameter[] parameters)
        {
            using (var sqlConnection = new SqlConnection(connString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procName;
                    if (parameters != null)
                    {
                        sqlCommand.Parameters.AddRange(parameters);
                    }
                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            { }
                        }
                        return elements;
                    }
                }
            }
        }

        public static byte[] SetPictureToDB(string picture)
        {
            FileInfo fInfo = new FileInfo(picture);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(picture, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            byte[] imageData = br.ReadBytes((int)numBytes);

            return imageData;

            //string iImageExtension = (Path.GetExtension(iFile)).Replace(".", "").ToLower();

            //byte[] bytes = Convert.FromBase64String(picture);
            //return File.WriteAllBytes("image."+screen_format.ToString(), bytes);
        }

        ///Methods to get values of   
        ///individual columns from sql data reader  
 
        public static string GetNullableString(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToString(reader[colName]);
        }

        public static string GetNullableScreenFormat(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : (Convert.ToString(reader[colName])).TrimStart().TrimEnd();
        }

        public static DateTime GetNullableDateTime(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? new DateTime(0,0,0) : Convert.ToDateTime(reader[colName]);
        }

        public static int GetNullableInt32(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? 0 : Convert.ToInt32(reader[colName]);
        }

        public static bool GetBoolean(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? default(bool) : Convert.ToBoolean(reader[colName]);
        }

        public static string GetNullablePicture(SqlDataReader reader, string colName)
        {
            return reader.IsDBNull(reader.GetOrdinal(colName)) ? null : Convert.ToBase64String(Encoding.Default.GetBytes(Convert.ToString(reader[colName])));
        }

        //this method is to check wheater column exists or not in data reader  
        public static bool IsColumnExists(this System.Data.IDataRecord dr, string colName){
            try
            {
                return (dr.GetOrdinal(colName) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
