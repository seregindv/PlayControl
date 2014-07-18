using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PlayControl.Controllers
{
    public interface IModel
    {
        bool Enabled { set; get; }
        string Name { get; }
    }
}
