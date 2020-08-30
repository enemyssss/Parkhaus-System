using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    abstract class Fahrzeug
    {
        public string Kennzeichnen { get; protected set; }

        protected Fahrzeug(string kennzeichnen)
        {
            this.Kennzeichnen = kennzeichnen;
        }


        public override string ToString()
        {
            return $"{this.Kennzeichnen}";
        }
    }
}
