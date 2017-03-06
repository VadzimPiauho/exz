using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exam
{
    class flySimulation
    {
        private int PenaltyPointsFinale { get; set; } = 0;
        ConsoleKeyInfo Symbol;
        bool go_onSimulation = true;
        Random rand = new Random();
        protected static airplane airplane { get; set; }
        protected List<dispatcher> Dispatcher = new List<dispatcher>();
        public flySimulation()
        {
            airplane = new airplane();
        }
        public void AddDispether(string NameDispether)
        {
            if (Dispatcher.Count==2)
            {
                Console.WriteLine("Два диспетчера уже имеется в системе");
                Thread.Sleep(1000);
                return;
            }
            //создается диспетчер
            dispatcher dispatcher = new dispatcher(NameDispether, rand.Next(-200, 200));
            //подписывается на событие
            airplane.AirplaneMoved += dispatcher.OnAirplaneMove;
            //добовляется в лист диспетчер
            Dispatcher.Add(dispatcher);
        }
        public void Move()
        {
            if (Dispatcher.Count<2)
            {
                Console.WriteLine("Диспетчеров меньше 2-х. Для полета добавьте диспетчера");
                Thread.Sleep(1000);
                return;
            }
            Console.Clear();
            Console.WriteLine("******************Симуляция началась*******************");
            Console.WriteLine("Скорость - изменяется клавишами-стрелками Left и Right");
            Console.WriteLine("Высота -  изменяется клавишами-стрелками Up и Down");
            //Console.WriteLine("Для экстренного выхода из симуляции нажмите F1");
            Console.WriteLine("Для замены диспетчера нажмите F2");
            
            airplane.StartFly();
            while (go_onSimulation)
            {
                Symbol = Console.ReadKey(true);
                //if (Symbol.Key == ConsoleKey.F1)
                //{
                //    go_onSimulation = false;
                //    return;
                //}
                
                airplane.Move(Symbol);
                if (airplane.Speed >= 50 && airplane.Hight == 0)
                {
                    EndFly();
                    continue;
                }
                Console.WriteLine("************************************************");
            }
        }

        private void EndFly()
        {
            foreach (var item in Dispatcher)
            {
                PenaltyPointsFinale += item.PenaltyPoints;
            }
            if (airplane.TaskSimulation==false)
            {
                throw new Exception($"Симуляция завершена, штрафное количество очков равно {PenaltyPointsFinale}, задача достичь максимальной скорости не выполнена");
            }
            if (airplane.TaskSimulation == true)
            {
                throw new Exception($"Симуляция завершена, штрафное количество очков равно {PenaltyPointsFinale}, задача достичь максимальной скорости выполнена");
            }

        }
    }
}
