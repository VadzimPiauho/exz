using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exam
{
    class Program
    {
        [DllImport("msvcrt")]
        static extern int _getch();

        static void Main(string[] args)
        {
            bool go_on = true;
            string NameDispether;
            try
            {
                var manager = new flySimulation();
                while (go_on)
                {
                    Console.Clear();
                    Console.WriteLine("****************************Меню*******************************");
                    Console.WriteLine("1 - Добавить диспетчера");
                    Console.WriteLine("2 - Начать симуляцию");
                    Console.WriteLine("0 - Выход из программы");
                    Console.WriteLine("**************************************************************");

                    switch (_getch())
                    {
                        case '1':
                            Console.WriteLine("Введите имя диспетчера");
                            NameDispether = Console.ReadLine();
                            manager.AddDispether(NameDispether);
                            break;
                        case '2':
                            manager.Move();
                            break;
                        //case '3':
                        //    endCase();
                            break;
                        case '0':
                            go_on = false;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static void endCase()
        {
            Console.WriteLine("Нажмите любую клавишу...");
            _getch();
        }
    }
}
//gluckodrom @list.ru
//[IT step]
