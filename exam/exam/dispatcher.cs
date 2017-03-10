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
        public string Name;
        private int WatherCorrect;
        private int OldRecommendedHight;
        private int NewRecommendedHight;
        private static int limitPenaltyPoints=1000;
        public int PenaltyPoints { get; set; } = 0;
        private int CountDispatcherMessag { get; set; } = 0;
        public dispatcher(string Name,int WatherCorrect)
        {
            this.Name = Name;
            this.WatherCorrect = WatherCorrect;
        }

        public void OnAirplaneMove(object obj, EventArgs arg)
        {
            
            airplane obj1 = (airplane)obj;
            NewRecommendedHight = 7 * obj1.Speed - WatherCorrect;

            if ((obj1.Speed == 0 && obj1.Hight > 0) || /*(obj1.Speed > 0 && obj1.Hight == 0) ||*/ (obj1.Speed < 0 || obj1.Hight < 0) || (obj1.Speed == 0 && obj1.Hight == 0))
            {
                throw new Exception("Самолет разбился");
            }
            if (CountDispatcherMessag>=1)
            {
                if (((OldRecommendedHight - WatherCorrect)- obj1.Hight)>=300&& (OldRecommendedHight - obj1.Hight) < 600)
                {
                    PenaltyPoints += 25;
                }
                if (((OldRecommendedHight - WatherCorrect) - obj1.Hight) >= 600 && (OldRecommendedHight - obj1.Hight) <= limitPenaltyPoints)
                {
                    PenaltyPoints += 50;
                }
                if ((OldRecommendedHight - obj1.Hight) > limitPenaltyPoints)
                {
                    throw new Exception("Самолет разбился,разница рекомендуемой и текущей высоты превысила 1000");
                }
            }
            if (PenaltyPoints >= limitPenaltyPoints)
            {
                throw new Exception("Непригоден к полетам, штрафные очки превысили 1000");
            }
            if (obj1.Speed > limitPenaltyPoints)
            {
                Console.WriteLine($"Немедленно снизте скорость, диспетчер {Name}");
                PenaltyPoints += 100;
                return;
            }
            if (obj1.Speed >= 50)
            {
                Console.WriteLine($"Рекомендуемая высота от {Name} равна = {NewRecommendedHight}");
                OldRecommendedHight = NewRecommendedHight;
                CountDispatcherMessag++;
            }
            // Thread.Sleep(3000);
        }
    }
}
