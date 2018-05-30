using DotNetPracticum5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DotNetPracticum5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        String Register(string Username);

        [OperationContract]
        bool Login(string Username, string Password);

        [OperationContract]
        List<UserProducts> GetUserProducts(int UserId);

        [OperationContract]
        bool BuyProduct(int UserId, int ProductId);

        [OperationContract]
        List<Inventory> GetInventory();

        [OperationContract]
        User GetUserByUsername(string Username);
    }
}
