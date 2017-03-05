using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class dispatcher
    {
        private string Name;
        private int WatherCorrect;
        public dispatcher(string Name,int WatherCorrect)
        {
            this.Name = Name;
            this.WatherCorrect = WatherCorrect;
        }

        public void OnAirplaneMove(object obj, EventArgs arg)
        {
            throw new Exception("Самолет не набрал высоту");
        }
    }
}
