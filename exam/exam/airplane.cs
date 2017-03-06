using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exam
{
    class airplane
    {
        public event EventHandler AirplaneMoved;
        public int Speed { get; set; } = 0;
        public int Hight { get; set; } = 0;
        public bool TaskSimulation { get; set; } = false;
        public void Move(ConsoleKeyInfo Symbol)
        {
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.LeftArrow)
            {
                Speed -= 50;
                Console.WriteLine("Скорость полета понижена на 50 км/ч");
            }

                if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.RightArrow)
            {
                Speed += 50;
                Console.WriteLine("Скорость полета повышена на 50 км/ч"); 
            }

            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.LeftArrow)
            {
                Speed -= 150;
                Console.WriteLine("Скорость полета понижена на 150 км/ч");
            }

            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.RightArrow)
            {
                Speed += 150;
                Console.WriteLine("Скорость полета повышена на 150 км/ч");
            }

            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.DownArrow)
            {
                Hight -= 250;
                Console.WriteLine("Высота уменшена на 250 м");
            } 
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.UpArrow)
            {
                Hight += 250;
                Console.WriteLine("Высота увеличена на 250 м");
            }
            
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.DownArrow)
            {
                Hight -= 500;
                Console.WriteLine("Высота уменшена на 500 м");
            }
           
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.UpArrow)
            {
                Hight += 500;
                Console.WriteLine("Высота увеличена на 500 м");
            }
            if (Speed >= 1000)
            {
                TaskSimulation = true;
            }
            Console.WriteLine($"Текущая высота полета {Hight} скорость {Speed} км/ч");
            
                if (AirplaneMoved != null)
                {
                    AirplaneMoved(this, EventArgs.Empty);
                }
        }

        internal void StartFly()
        {
            while (true)
            {
                ConsoleKeyInfo Symbol = Console.ReadKey(true);
                if (((((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.LeftArrow) ||
               (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.LeftArrow)) &&
               (Speed == 0))
                {
                    Console.WriteLine("Наберите скорость");
                    Thread.Sleep(1000);
                    continue;
                }
                if (((((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.DownArrow) ||
                    (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.DownArrow)) &&
                    (Hight == 0))
                {
                    Console.WriteLine("Вы находитесь на земле");
                    Thread.Sleep(1000);
                    continue;
                }
                if (((((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.UpArrow) ||
                   (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.UpArrow)) &&
                   (Speed == 0))
                {
                    Console.WriteLine("Невозможно набрать высоту т.к. скорость равна 0 км/ч");
                    Thread.Sleep(1000);
                    continue;
                }
                if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.RightArrow)
                {
                    Speed += 50;
                    Console.WriteLine("Скорость полета повышена на 50 км/ч");
                    Console.WriteLine($"Текущая высота полета {Hight} скорость {Speed} км/ч");
                    break;
                }
                if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.RightArrow)
                {
                    Speed += 150;
                    Console.WriteLine("Скорость полета повышена на 150 км/ч");
                    Console.WriteLine($"Текущая высота полета {Hight} скорость {Speed} км/ч");
                    break;
                }
            }
            
        }
    }
}
//ConsoleKeyInfo Symbol;
//Symbol = Console.ReadKey();
//                Console.WriteLine();
//                Console.Clear();
//if ((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
//if ((Symbol.Key==ConsoleKey.DownArrow)) Console.Write(Symbol.Key);

//                Console.WriteLine(Symbol.Key);