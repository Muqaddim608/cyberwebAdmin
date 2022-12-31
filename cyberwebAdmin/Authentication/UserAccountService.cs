using ClassLibraryDAL;
using ClassLibraryModel;
using System.Data.SqlClient;
namespace cyberwebAdmin.Authentication


{
    public class UserAccountService
    {
        private List<UserAccount> _users;
        public UserAccountService()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("returnAuth", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            _users = new List<UserAccount>();
            while (reader.Read())
            {
                UserAccount _user = new UserAccount();
                _user.UserName = reader["Name"].ToString();
                _user.Password = reader["Password"].ToString();
                _user.Role = reader["Role"].ToString();
                _users.Add(_user);
            };
        }
        public UserAccount? GetbyUserName (string UserName)
        {
            return _users.FirstOrDefault(x => x.UserName == UserName);
        }
    }
}

/*{
    public class UserAccountService
    {
        private List<UserAccount> _users;

        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount{UserName="admin",Password="admin",Role="Administrator"},
                new UserAccount{UserName="user",Password="user",Role="User"}
            };
        }

        public UserAccount? GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}*/
