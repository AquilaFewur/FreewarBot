using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeWarBot12
{
    public class Item
    {
        public string _amount;
        public string _id;
        public string _name;

        public Item(string id, string name, string amount)
        {
            _id = id;
            _name = name;
            _amount = amount;
        }
    }
}
