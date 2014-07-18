using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayControl.Controllers
{
    public abstract class ModelBase : IModel
    {
        public virtual bool Enabled { get; set; }
        public abstract string Name { get; }
    }
}
