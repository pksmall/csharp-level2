using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.Events
{
    public class StateEvents : EventArgs
    {
        public string message { get; set; }
    }
}
