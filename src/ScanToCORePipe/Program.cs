using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ars.Ltar.CORe.ScanToCORePipe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Container container = new Container();

            container.ResolveScanToCORePipe().Execute();


        }
    }
}
