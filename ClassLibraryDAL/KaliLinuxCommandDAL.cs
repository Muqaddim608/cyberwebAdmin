using ClassLibraryModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDAL
{
    public class KaliLinuxCommandDAL
    {
        public static int SaveKLC(KaliLinuxCommandModel KLC)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SaveKLC", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("klc", KLC.KaliLinuxCommand);
            cmd.Parameters.AddWithValue("P", KLC.Purpose);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static List<KaliLinuxCommandModel> GetKLC()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("ReturnKLC", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            List<KaliLinuxCommandModel> KLC = new List<KaliLinuxCommandModel>();
            while (reader.Read())
            {
                KaliLinuxCommandModel KLCD = new KaliLinuxCommandModel();
                KLCD.Id = int.Parse(reader["Id"].ToString());
                KLCD.KaliLinuxCommand = reader["KaliLinuxCommands"].ToString();
                KLCD.Purpose = reader["Purpose"].ToString();
                KLC.Add(KLCD);
            }
            con.Close();
            return KLC;

        }

        public static int DeleteKLC(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteKLC", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}
