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
        public bool disabled = false;
        public bool nextDay = false;
        public bool scheduled = false;
        public ScheduleObject(string path, int hours, int minutes, bool nextDay = false)
        {
            this.path = path;
            TimeOnly timeOnly = new TimeOnly(hours, minutes);
            this.time = timeOnly;
            this.nextDay = nextDay;
        }

        public ScheduleObject(string path, TimeOnly time, bool nextDay = false)
        {
            this.path = path;
            this.time = time;
            this.nextDay = nextDay;
        }


        public void ToggleDisabled()
        {
            this.disabled = !this.disabled;
        }

        public override string ToString()
        {
            string outStr = Path.GetFileNameWithoutExtension(path);
            outStr += ", ";
            outStr += time.ToString("HHmm");
            return outStr;
        }
    }
}
