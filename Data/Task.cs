using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Data.Enums;
using Newtonsoft.Json;

namespace Data
{

    public class Task : BaseEntity
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public Priority Priority { get; set; }

        public int? ParentTaskId { get; set; }

        public int? MeasureUnitId { get; set; }

        public bool HasEndPoint { get; set; }

        public int? EndPoint { get; set; }

        public bool TrackTime { get; set; }

        public bool TrackAmount { get; set; }

        public User User { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public Task ParentTask { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }

        public ICollection<Activity> Activities { get; set; }

        public ICollection<Task> ChildTasks { get; set; }
    }
}
