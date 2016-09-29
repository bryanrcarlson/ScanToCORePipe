using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COReWriter
{
    public class DataRecord
    {
        public string LTARSiteAcronym { get; set; }
        public string StationID { get; set; }
        public string DateTime { get; set; }
        public string RecordType { get; set; }
        public string AirTemperature { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string RelativeHumidity { get; set; }
        public string Precipitation { get; set; }
        public string AirPressure { get; set; }
        public string PAR { get; set; }
        public string ShortWaveIn { get; set; }
        public string LongWaveIn { get; set; }
        public string BatteryVoltage { get; set; }
        public string LoggerTemperature { get; set; }


    }
}
