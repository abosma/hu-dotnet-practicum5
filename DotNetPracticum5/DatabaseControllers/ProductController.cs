using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.DatabaseControllers
{
    public static class ProductController
    {
        static SQLiteConnection connection = DatabaseController.GetConnection();

        public static bool BuyProduct(int UserId, int ProductId)
        {
            try
            {
                bool productExists = false;
                User user = UserController.GetUserById(UserId);
                float price = 0;
                int storage = 0;
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM user_products WHERE user_id = @UserId AND product_id = @ProductId";
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                productExists = true;
                            }
                            else
                            {
                                productExists = false;
                            }
                        }
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM inventory WHERE product_id = @ProductId";
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            storage = reader.GetInt32(1);
                        }
                    }
                }

                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM products WHERE productid = @ProductId";
                    cmd.Parameters.AddWithValue("@ProductId", ProductId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            price = reader.GetFloat(2);
                        }
                    }
                }


                if (productExists && storage != 0 && user.Money >= price)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = "UPDATE user_products SET amount = amount + 1 WHERE user_id = @userid AND product_id = @productid";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@userid", UserId);
                        cmd.Parameters.AddWithValue("@productid", ProductId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return false;
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = "UPDATE inventory SET storage = storage - 1 WHERE product_id = @productid";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@productid", ProductId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return false;
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = "UPDATE user SET money = money - @price WHERE userid = @userid";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@userid", UserId);
                        cmd.Parameters.AddWithValue("@Price", price);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return false;
                        }
                    }
                    connection.Close();
                    return true;
                }
                else if(!productExists && storage != 0 && user.Money >= price)
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = "UPDATE inventory SET storage = storage - 1 WHERE product_id = @productid";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@productid", ProductId);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return false;
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        cmd.CommandText = "UPDATE user SET money = money - @price WHERE userid = @userid";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@userid", UserId);
                        cmd.Parameters.AddWithValue("@Price", price);

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return false;
                        }
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(connection))
                    {
                        int result = -1;
                        cmd.CommandText = "INSERT INTO user_products VALUES(@userid, @productid, 1)";
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@userid", UserId);
                        cmd.Parameters.AddWithValue("@productid", ProductId);

                        try
                        {
                            result = cmd.ExecuteNonQuery();
                        }
                        catch (SQLiteException e)
                        {
                            Debug.WriteLine(e);
                            connection.Close();
                            return false;
                        }
                    }
                    connection.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Debug.WriteLine(e);
                return false;
            }
        }

        public static List<UserProducts> GetProductsOfUser(int UserId)
        {
            List<Tuple<int, int>> productIDs = new List<Tuple<int,int>>();

            List<UserProducts> products = new List<UserProducts>();

            try
            {
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = "SELECT * FROM user_products WHERE user_id = @ID";
                    cmd.Parameters.AddWithValue("@ID", UserId);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productIDs.Add(new Tuple<int,int>(reader.GetInt32(1), reader.GetInt32(2)));
                        }
                    }
                }
                
                using (SQLiteCommand cmd = new SQLiteCommand(connection))
                {
                    User tempUser = UserController.GetUserById(UserId);
                    cmd.CommandText = "SELECT * FROM products WHERE productid = @ProductId";

                    productIDs.ForEach(productamount =>
                    {
                        cmd.Parameters.AddWithValue("@ProductId", productamount.Item1);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product tempProduct = new Product();
                                tempProduct.ProductID = reader.GetInt32(0);
                                tempProduct.Name = reader.GetString(1);
                                tempProduct.Price = reader.GetFloat(2);

                                UserProducts tempUserProducts = new UserProducts();
                                tempUserProducts.User = tempUser;
                                tempUserProducts.Product = tempProduct;
                                tempUserProducts.Amount = productamount.Item2;

                                products.Add(tempUserProducts);
                            }
                        }
                    });
                }
                connection.Close();
            }
            catch (SQLiteException e)
            {
                connection.Close();
                Debug.WriteLine(e);
                return null;
            }
            return products;
        }
    }
}
