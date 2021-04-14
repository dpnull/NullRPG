﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface ILocation : IIndexable
    {
        int ObjectId { get; set; }
        string Name { get; set; }
        int Level { get; set; }
    }
}
