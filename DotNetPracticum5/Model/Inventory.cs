using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetPracticum5.Model
{
    public class Inventory
    {
        Product _product;
        int _storage;

        public Product Product { get => _product; set => _product = value; }
        public int Storage { get => _storage; set => _storage = value; }
    }
}
