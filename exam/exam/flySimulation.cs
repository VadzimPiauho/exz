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
        public void AddDispether()
        {
            Console.WriteLine("Введите имя диспетчера");
            string NameDispether = Console.ReadLine();
            //if (Dispatcher.Count==2)
            //{
            //    Console.WriteLine("Два диспетчера уже имеется в системе");
            //    Thread.Sleep(1000);
            //    return;
            //}
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
            Console.WriteLine("Для удаления диспетчера нажмите F2");
            Console.WriteLine("Для добавления диспетчера нажмите F3");
            Console.WriteLine("*******************************************************");
            airplane.StartFly();
            while (go_onSimulation)
            {
                Console.WriteLine("Для удаления диспетчера нажмите F2");
                Console.WriteLine("Для добавления диспетчера нажмите F3");
                Symbol = Console.ReadKey(true);
                if (Symbol.Key == ConsoleKey.F3)
                {
                    AddDispether();
                    continue;
                }
                if (Symbol.Key == ConsoleKey.F2)
                {
                    RemoveDispether();
                    continue;
                }
                if (Dispatcher.Count < 2)
                {
                    Console.WriteLine("Диспетчеров меньше 2-х. Для полета добавьте диспетчера");
                    Thread.Sleep(1000);
                    continue;
                }
                //if (Symbol.Key == ConsoleKey.F1)
                //{
                //    go_onSimulation = false;
                //    return;
                //}
                airplane.Move(Symbol);
                if (airplane.Speed == 50 && airplane.Hight == 0)
                {
                    EndFly();
                    continue;
                }
                Console.WriteLine("************************************************");
            }
        }

        private void RemoveDispether()
        {
            if (Dispatcher.Count==0)
            {
                Console.WriteLine("Нет диспетчеров для удаления ");
                return;
            }
            Console.WriteLine("Введите имя диспетчера");
            string NameDispether = Console.ReadLine();
            bool trueOperation = false;

            foreach (var item in Dispatcher)
            {
                if (item.Name== NameDispether)
                {
                    PenaltyPointsFinale += item.PenaltyPoints;
                    airplane.AirplaneMoved -= item.OnAirplaneMove;
                    Dispatcher.Remove(item);
                    trueOperation = true;
                    break;
                }
            }
            if (trueOperation==true)
            {
                Console.WriteLine("Диспетчер с таким именем удален");
            }
            else
            {
                Console.WriteLine("Диспетчера с таким именем не найдено");
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
