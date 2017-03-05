using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class airplane
    {
        private int Speed {get;set;}
        public int Hight { get; set; }

        public void UppSpeed(ConsoleKeyInfo Symbol)
        {
            if (((Symbol.Modifiers & ConsoleModifiers.Shift) != 0)&& Symbol.Key==ConsoleKey.) Console.Write("SHIFT+");
            if ((Symbol.Key==ConsoleKey.DownArrow)) Console.Write(Symbol.Key);
        }

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
//ConsoleKeyInfo Symbol;
//Symbol = Console.ReadKey();
//                Console.WriteLine();
//                Console.Clear();
//if ((Symbol.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
//if ((Symbol.Key==ConsoleKey.DownArrow)) Console.Write(Symbol.Key);

//                Console.WriteLine(Symbol.Key);