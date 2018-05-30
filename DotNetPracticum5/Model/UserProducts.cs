using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.Model
{
    public class UserProducts
    {
        User _user;
        Product _product;
        int _amount;

        public User User { get => _user; set => _user = value; }
        public Product Product { get => _product; set => _product = value; }
        public int Amount { get => _amount; set => _amount = value; }
    }
}
