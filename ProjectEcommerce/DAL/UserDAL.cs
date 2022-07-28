using Dapper;
using EcommerceProject.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjectEcommerce.DAL
{
    public class UserDAL
    {
        public static IEnumerable<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                userList = con.Query<User>("SP_SelectAll_User_Table").ToList();

            }
            return userList;
        }
        public static User GetUserById(int id)
        {
            User u = new User();
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                u = con.Query<User>("SP_SelectById_User_Table", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return u;
        }

        public static User VerifyLogin(User u)
        {
            User user = new User();
            using (IDbConnection con = new SqlConnection("Server=DESKTOP-SQKJ3UE\\SQLEXPRESS;Database=Ecommerce;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@email", u.u_email);
                user = con.Query<User>("SP_SelectByEmail_User_Table", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                
            }
            return user;
        }

        public static int AddUser(User u)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@u_name", u.u_name);
                dynamicParameters.Add("@u_email", u.u_email);
                dynamicParameters.Add("@u_password", u.u_password);
                dynamicParameters.Add("@u_roleid", 2);
                result = con.Execute("SP_Insert_User_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public static int UpdateUser(User u)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@u_id", u.u_id);
                dynamicParameters.Add("@u_name", u.u_name);
                dynamicParameters.Add("@u_email", u.u_email);
                dynamicParameters.Add("@u_password", u.u_password);
                dynamicParameters.Add("@u_roleid", 2);
                result = con.Execute("SP_Update_User_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public static int DeleteUser(int id)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@u_id", id);
                result = con.Execute("SP_Delete_User_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }

   
        
    


}
