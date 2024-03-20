using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_LINQ_2
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Department(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }   
    }

}
