using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class airplane
    {
        private int Speed { get; set; } = 0;
        public int Hight { get; set; } = 0;

        public void UppSpeed(ConsoleKeyInfo Symbol)
        {
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.LeftArrow) Speed -= 50;
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.RightArrow) Speed += 50;
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.LeftArrow) Speed -= 150;
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.RightArrow) Speed += 150;
        }
        public void UppHight(ConsoleKeyInfo Symbol)
        {
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.DownArrow) Hight -= 250;
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) == 0) && Symbol.Key == ConsoleKey.UpArrow) Hight += 250;
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.DownArrow) Hight -= 500;
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) && Symbol.Key == ConsoleKey.UpArrow) Hight += 500;
        }

        public event EventHandler AirplaneMoved;
        public void Move()
        {
            if (AirplaneMoved != null)
            {
                AirplaneMoved(this, EventArgs.Empty);
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