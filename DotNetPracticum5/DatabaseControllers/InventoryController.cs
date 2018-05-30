using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.DatabaseControllers
{
    public static class InventoryController
    {
        static SQLiteConnection connection = DatabaseController.GetConnection();

        public static List<Inventory> GetInventories()
        {
            List<Inventory> inventories = new List<Inventory>();
            List<Tuple<int, int>> productIDs = new List<Tuple<int, int>>();
            connection.Open();

            using (SQLiteCommand cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT * FROM inventory WHERE storage > 0";
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productIDs.Add(new Tuple<int,int>(reader.GetInt32(0), reader.GetInt32(1)));
                    }
                }
            }

            using (SQLiteCommand cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT * FROM products WHERE productid = @ProductId";

                productIDs.ForEach(productstorage =>
                {
                    cmd.Parameters.AddWithValue("@ProductId", productstorage.Item1);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product tempProduct = new Product();
                            tempProduct.ProductID = reader.GetInt32(0);
                            tempProduct.Name = reader.GetString(1);
                            tempProduct.Price = reader.GetFloat(2);

                            Inventory tempInventory = new Inventory();
                            tempInventory.Product = tempProduct;
                            tempInventory.Storage = productstorage.Item2;

                            inventories.Add(tempInventory);
                        }
                    }
                });
            }
            connection.Close();
            return inventories;
        }
    }
}
