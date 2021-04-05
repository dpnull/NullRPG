﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IEntityComponent
    {
        IEntity Source { get; set; }
        void ReceiveValue<T>(T value);
    }
}
