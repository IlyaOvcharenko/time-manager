using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Data
{
    public class Activity : BaseEntity
    {
        public int TaskId { get; set; } 

        public DateTime Date { get; set; }

        public double SpentTime { get; set; }

        public int? Amount { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public virtual Task Task { get; set; }
    }
}
