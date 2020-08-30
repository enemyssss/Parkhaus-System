using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Auto: Fahrzeug
    {
        public Auto(string kennzeichnen) : base(kennzeichnen)
        {
            this.Kennzeichnen = kennzeichnen;
        }
    }
}
