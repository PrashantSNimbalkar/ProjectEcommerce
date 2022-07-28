using Dapper;
using EcommerceProject.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjectEcommerce.DAL
{
    public class CartDAL
    {
        public static IEnumerable<Cart> GetAllCartItems()
        {
            List<Cart> cartList = new List<Cart>();
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                //cartList = con.Query<Cart>("SP_SelectAll_Cart_Table").ToList();

            }
            return cartList;
        }
        
        public static int AddToCart(int p_id,int u_id)
        {
            int result = 0;
           
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                
                DynamicParameters insertParameters = new DynamicParameters();
                insertParameters.Add("@p_id", p_id);
                insertParameters.Add("@u_id", u_id);           
                result = con.Execute("SP_Insert_Cart_Table", insertParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        //public static int UpdateCart(Cart c)
        //{
        //    int result = 0;
        //    using (IDbConnection con = new SqlConnection())
        //    {
        //        if (con.State == ConnectionState.Closed)
        //            con.Open();
        //        DynamicParameters dynamicParameters = new DynamicParameters();
        //        dynamicParameters.Add("@c_id", c.c_id);
        //        dynamicParameters.Add("@p_id", c.p_id);
        //        dynamicParameters.Add("@u_id", c.u_id);
        //        result = con.Execute("SP_Update_Cart_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
        //    }
        //    return result;
        //}

        public static int DeletefromCart(int id)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@c_id", id);
                result = con.Execute("SP_Delete_Cart_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }






}
