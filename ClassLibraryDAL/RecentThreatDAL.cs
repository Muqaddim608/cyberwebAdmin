using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace ClassLibraryDAL
{
    public class RecentThreatDAL
    {
        public static int SaveRT(RecentThreatModel RT)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SaveRT", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Threat", RT.Threat);
            cmd.Parameters.AddWithValue("cause", RT.Cause);
            cmd.Parameters.AddWithValue("awareness", RT.Awareness);
            cmd.Parameters.AddWithValue("audio", RT.Audio);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static List<RecentThreatModel> GetRT()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("ReturnRT", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<RecentThreatModel> RL = new List<RecentThreatModel>();
            while (reader.Read())
            {
                RecentThreatModel RT = new RecentThreatModel();
                RT.ThreatId = int.Parse(reader["ThreatId"].ToString());
                RT.Threat = reader["Threat"].ToString();
                RT.Cause = reader["Cause"].ToString();
                RT.Awareness = reader["Awareness"].ToString();
                RT.Audio = reader["Audio"].ToString();
                RL.Add(RT);
            }
            con.Close();
            return RL;
        }
        public static int DeleteRT(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteRT", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
