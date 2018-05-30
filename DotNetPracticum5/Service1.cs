using DotNetPracticum5.DatabaseControllers;
using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DotNetPracticum5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<Inventory> GetInventory()
        {
            return InventoryController.GetInventories();
        }

        public bool BuyProduct(int UserId, int ProductId)
        {
            return ProductController.BuyProduct(UserId, ProductId);
        }

        public List<UserProducts> GetUserProducts(int UserId)
        {
            return ProductController.GetProductsOfUser(UserId);
        }

        public bool Login(string Username, string Password)
        {
            if (UserController.GetUser(Username, Password) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String Register(string Username)
        {
            String returnString = UserController.InsertUser(Username, Helper.Reverse(Username));

            if (!String.IsNullOrEmpty(returnString))
            {
                return "Your password is: " + returnString;
            }
            else
            {
                return "User Register failed, please contact Atilla";
            }
        }

        public User GetUserByUsername(string Username)
        {
            return UserController.GetUserByUsername(Username);
        }
    }
}
