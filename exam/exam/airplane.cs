using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class airplane
    {
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
