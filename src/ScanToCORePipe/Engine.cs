using COReWriter;
using Nrcs.Nwcc.ReportGenerator;
using Nrcs.NWcc.ReportFormatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitOfMeasure;

namespace Ars.Ltar.CORe.ScanToCORePipe
{
    public class Engine
    {
        private readonly DataGrabber grabber;
        private readonly Formatter formatter;
        private readonly FileSystemWriter writer;

        public Engine(
            DataGrabber dataGrabber,
            Formatter formatter,
            FileSystemWriter writer)
        {
            this.grabber = dataGrabber;
            this.formatter = formatter;
            this.writer = writer;
        }

        
        public void Execute()
        {
            // TODO: Consider a DataTable class (or somesort) or mapper that maps headers, columns, to Measurements.  Will need one for the parser and the writer.  Potentially allow definition in a txt file for customization without coding exp.

            List<DataColumns> columns = new List<DataColumns>()
            {
                DataColumns.TAVG,
                DataColumns.WSPDV,
                DataColumns.WDIRV,
                DataColumns.RHUM,
                DataColumns.PRCP,
                DataColumns.BATT
            };

            // Single responsibility principle says I should have a "connection" class
            //and a "read" class.  But I'm putting them together here.

            DateTime today = DateTime.Today;
            today = new DateTime(2016, 9, 1);
            string content =
                grabber.GetHourly(
                    "2198:WA:SCAN",
                    new DateTime(2013,07,24),
                    new DateTime(2016,09,11),
                    columns);

            List<ITemperalMeasurement> measurements = formatter.ParseData(content);

            writer.CreateDataRecord(
                LtarSiteAcronymCodes.CookAgronomyFarm,
                "002",
                RecordTypeCodes.LegacySiteSpecificDefinition,
                -8,
                measurements);

            writer.Write();

            // SOLID be damned, this class connects to filesystem and writes to it
            //COReWriter.W
        }
    }
}
