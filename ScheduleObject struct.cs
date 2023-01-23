using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWOC_Audio_Scheduler
{
    /**
     * Struct: ScheduleObject.
     * This stores a path to a file, and a specific time that the file will run.
     * Use of the TimeOnly type may be temporary.
     */
    internal struct ScheduleObject
    {
        public string path;
        public TimeOnly time;

        public ScheduleObject(string path, int hours, int minutes)
        {
            this.path = path;
            TimeOnly timeOnly = new TimeOnly(hours, minutes);
            this.time = timeOnly;
        }
    }
}
