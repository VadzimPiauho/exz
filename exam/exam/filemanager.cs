using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class filemanager
    {
        Random rand = new Random();
        protected airplane airplane { get; set; }
        protected List<dispatcher> Dispatcher = new List<dispatcher>();
        public void AddAirplane()
        {
            this.airplane = new airplane();
        }
        public void AddDispether()
        {
            //создается диспетчер
            dispatcher dispatcher = new dispatcher("Dfcz", rand.Next(-200, 200));
            //подписывается на событие

            //добовляется в лист
            Dispatcher.Add(dispatcher);
        }
        public void Move()
        {
            if (Dispatcher.Count<2)
            {
                throw new Exception("Диспетчеров меньше 2-х");
            }

        }
    }
}
