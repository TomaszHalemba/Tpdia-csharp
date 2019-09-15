using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.execute(args[0]);
        }
    }
}
