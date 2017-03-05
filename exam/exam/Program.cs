using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var manager = new filemanager();
                manager.AddDispether();
                manager.Move();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
//gluckodrom @list.ru
//[IT step]
