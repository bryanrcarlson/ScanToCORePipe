using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ars.Ltar.CORe.ScanToCORePipe
{
    /// <summary>
    /// Wires up all dependencies, called by composition root
    /// </summary>
    /// <returns>Engine that runs the program</returns>
    public class Container
    {
        public Engine ResolveScanToCORePipe()
        {
            var g = new Nrcs.Nwcc.ReportGenerator.DataGrabber();
            var f = new Nrcs.NWcc.ReportFormatter.Formatter();
            var w = new COReWriter.FileSystemWriter(@"C:\");

            return new Engine(g,f,w);
        }
    }
}
