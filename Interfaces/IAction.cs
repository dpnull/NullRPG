using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.Interfaces
{
    public interface IAction
    {
        void OnInteract();
        bool CanInteract { get; }
    }
}
