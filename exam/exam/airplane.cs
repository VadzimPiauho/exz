using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class airplane
    {
        public int Speed {get;set;}
        public int Hight { get; set; }

        public event EventHandler AirplaneMoved;
        public void Moved()
        {
            if (AirplaneMoved != null)
            {
                AirplaneMoved(this, EventArgs.Empty);
            }
        }
    }
}
