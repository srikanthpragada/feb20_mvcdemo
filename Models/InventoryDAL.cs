using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class InventoryDAL
    {
        public static List<Product> GetProducts()
        {
            try {
                using (SqlConnection con = new SqlConnection(Database.LocalDbConnection))
                {
                    con.Open();
                    var products = new List<Product>();
                    SqlCommand cmd = new SqlCommand("select * from products", con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        var prod = new Product
                        {
                            Id = Int32.Parse(reader["prodid"].ToString()),
                            Name = reader["prodname"].ToString(),
                            Qoh = Int32.Parse(reader["qoh"].ToString()),
                            Price = Decimal.Parse(reader["price"].ToString())
                        };
                        products.Add(prod);
                    }
                    reader.Close();
                    return products;
                }
            }
            catch(Exception ex)
            {
                HttpContext.Current.Trace.Write("Error : " + ex.Message);
                return null; 
            }
        }

        public static Product GetProduct(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Database.LocalDbConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from products where prodid = @prodid", con);
                    cmd.Parameters.AddWithValue("@prodid", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var prod = new Product
                        {
                            Id = Int32.Parse(reader["prodid"].ToString()),
                            Name = reader["prodname"].ToString(),
                            Qoh = Int32.Parse(reader["qoh"].ToString()),
                            Price = Decimal.Parse(reader["price"].ToString())
                        };
                        return prod;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Write("Error : " + ex.Message);
                return null;
            }
        }


        public static bool UpdateProduct(int id, Product product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Database.LocalDbConnection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update products set prodname=@name, qoh = @qoh, price = @price where prodid = @prodid", con);
                    cmd.Parameters.AddWithValue("@prodid", id);
                    cmd.Parameters.AddWithValue("@qoh", product.Qoh);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@name", product.Name);

                    int count = cmd.ExecuteNonQuery();
                    return count == 1; 
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Trace.Write("Error : " + ex.Message);
                return false;
            }
        }
    }
}