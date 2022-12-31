using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class YoutubeLinkDAL
    {
        public static int SaveYTL(YoutubeLinkModel YTL)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            string cmmd = "SaveYTL";
            SqlCommand cmd = new SqlCommand(cmmd, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@L", YTL.YoutubeLink);
            cmd.Parameters.AddWithValue("@N", YTL.Name);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static List<YoutubeLinkModel> GetYTL()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("ReturnYTL", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<YoutubeLinkModel> YTL = new List<YoutubeLinkModel>();
            while (reader.Read())
            {
                YoutubeLinkModel YTLD = new YoutubeLinkModel();
                YTLD.Id = int.Parse(reader["Id"].ToString());
                YTLD.YoutubeLink = reader["Link"].ToString();
                YTLD.Name = reader["Name"].ToString();
                YTL.Add(YTLD);
            }
            con.Close();
            return YTL;

        }
        public static int DeleteYTL(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteYTL", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
