using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            airplane obj1 = (airplane)obj;
            if (obj1.Speed >= 50)
            {
                Console.WriteLine($"Рекомендуемая высота от {Name} равна = {7 * obj1.Speed - WatherCorrect}");
            }
            // Thread.Sleep(3000);
            if ((obj1.Speed==0 && obj1.Hight>0)|| (obj1.Speed > 0 && obj1.Hight == 0)|| obj1.Speed<0|| obj1.Hight<0)
            {
                throw new Exception("Самолет разбился");
            }
            //throw new Exception("Самолет не набрал высоту");
        }
    }
}
