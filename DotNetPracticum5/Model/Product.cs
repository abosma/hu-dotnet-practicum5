using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.Model
{
    public class Product
    {
        int _productID;
        string _name;
        float _price;

        public int ProductID { get => _productID; set => _productID = value; }
        public string Name { get => _name; set => _name = value; }
        public float Price { get => _price; set => _price = value; }
    }
}
