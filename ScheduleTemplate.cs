using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWOC_Audio_Scheduler
{
    /**
     * Class: ScheduleTemplate
     * This class should store all of the methods and attributes associated with a 
     * template. A template should store a standard array of schedule objects, which 
     * represents a standard day's schedule.
     * 
     * For example: If we were going to make a template for a standard M/T/W/Th school day,
     * an instance of this classs would store and array of schedule objects:
     * 
     * Reveille: 0700
     * Assembly: 0730
     * Assembly: 0830
     * Assembly: 0930
     * ...
     * Taps: 1100
     * 
     * Note: The air force song will always be played manually in CWOC
     */
    internal class ScheduleTemplate
    {
        public string name;
        public List<ScheduleObject> scheduleObjects = new();

        // This stores whether or not this template should serve as a default template
        // for any day, as well as a day to start/ end.
        public bool defaultTemplate;
        public DateOnly startDate; // A timespan object might do this better
        public DateOnly endDate;

        // This serves as storage for which days to assume. This could be changed, currently
        // just being abstracted as an array of seven booleans
        // Sun, mon, ... sat, to be in line with DayOfTheWeek enum
        public bool[] daysDefault = { false, false, false, false, false, false, false };

        public ScheduleTemplate()
        {
            startDate = new DateOnly();
            endDate = new DateOnly();
            defaultTemplate = false;
            scheduleObjects = new List<ScheduleObject>();
            name = "Unnamed";
        }

        public ScheduleTemplate(string filePath)
        {
            //Read from the file, and pass the contents to the "fromString" method
            name = "Temp";
            return;
        }

        public ScheduleTemplate(string name, List<ScheduleObject> scheduleObjects, 
                                bool defaultTemplate, DateOnly startDate, DateOnly endDate, 
                                bool[] daysDefault)
        {
            this.name = name;
            this.scheduleObjects = scheduleObjects;
            this.defaultTemplate = defaultTemplate;
            this.startDate = startDate;
            this.endDate = endDate;
            this.daysDefault = daysDefault;
        }



        /**
         * Converts this entire object to a string, mostly for file reading purposes.
         * Binary files are also an option. This solution can be replaces, it just needs
         * to be the exact inverse of the fromString() function
         */
        public override string ToString()
        {
            string outStr = name + "\n";
            for (int i = 0; i < scheduleObjects.Count; i++)
            {
                outStr += scheduleObjects[i].ToString();
                outStr += "\n";
            }
            outStr += defaultTemplate.ToString();
            outStr += "\n";
            outStr += String.Join("\n", daysDefault);
            if (defaultTemplate)
                outStr += $"\n{startDate}\n{endDate}";

            return outStr;
        }

        private void FromString(string templateString)
        {
            //Take the string and store its contents into the properties of the calling
            // object. Should be exactly inverse to the toString function
            return;
        }

        public void ToFile(string path)
        {
            //Convert to string and save to file
            return;
        }

        /**
         * Checks if the given DateOnly is between the start date and the end date
         */
        public bool schedulesDay(DateOnly day)
        {
            if (this.defaultTemplate)
            {
                return daysDefault[(int) day.DayOfWeek];
            }
            return false;
        }
    }

    
}
