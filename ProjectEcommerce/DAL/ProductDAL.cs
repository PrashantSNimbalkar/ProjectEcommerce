using Dapper;
using EcommerceProject.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Data.SqlClient;
namespace ProjectEcommerce.DAL
{
    public class ProductDAL
    {
       
        public static IEnumerable<Product> GetAllProducts()
        {
            
            List<Product> prodList = new List<Product>();
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
               // prodList = con.Query<Product>("SP_SelectAll_Product_Table").ToList();

            }
            return prodList;
        }
        public static Product GetProductById(int id)
        {
            Product prod = new Product();
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                prod = con.Query<Product>("SP_SelectById_Product_Table", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
            return prod;
        }

        public static int AddProduct(Product prod)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection("Server=LAPTOP-5S1VEB5D\\SQLEXPRESS;Database=EcommercePrashant;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_name", prod.p_name);
                dynamicParameters.Add("@p_company", prod.p_company);
                dynamicParameters.Add("@p_price", prod.p_price);
                result = con.Execute("SP_Insert_Product_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public static int UpdateProduct(Product prod)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection("Server=DESKTOP-SQKJ3UE\\SQLEXPRESS;Database=Ecommerce;Integrated Security=True;"))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_id", prod.p_id);
                dynamicParameters.Add("@p_name", prod.p_name);
                dynamicParameters.Add("@p_company", prod.p_company);
                dynamicParameters.Add("@p_price", prod.p_price);
                result = con.Execute("SP_Update_Product_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public static int DeleteProduct(int id)
        {
            int result = 0;
            using (IDbConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@p_id", id);
                result = con.Execute("SP_Delete_Product_Table", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
