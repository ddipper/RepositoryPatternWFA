﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWFA.Models
{
    public class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}; Name: {Name}; Price: {Price}";
        }
    }
}
