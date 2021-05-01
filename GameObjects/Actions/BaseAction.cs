using NullRPG.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullRPG.GameObjects.Actions
{
    public abstract class BaseAction : IAction
    {
        public BaseAction()
        {

        }

        public virtual void OnInteract()
        {

        }

        public virtual bool CanInteract
        {
            get
            {

            }
        }
    }
}
