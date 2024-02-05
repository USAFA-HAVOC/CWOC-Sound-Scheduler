using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
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
    public class ScheduleTemplate
    {
        public string name;
        public List<ScheduleObject> scheduleObjects = new();

        // This stores whether or not this template should serve as a default template
        // for any day, as well as a day to start/ end.
        public bool defaultTemplate;
        public DateOnly startDate;
        public DateOnly endDate;

        // This serves as storage for which days to assume
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

        public override string ToString()
        {
            return name;
        }

        /**
         * Converts this entire object to a string, mostly for file reading purposes.
         * Binary files are also an option. This solution can be replaces, it just needs
         * to be the exact inverse of the fromString() function
         */
        public string ToOutputString()
        {
            string outStr = name + "\n";
            for (int i = 0; i < scheduleObjects.Count; i++)
            {
                outStr += scheduleObjects[i].ToDelimitedString(";");
                outStr += "-";
            }
            outStr = outStr.TrimEnd('-');
            outStr += "\n";
            outStr += defaultTemplate ? "True" : "False";
            outStr += "\n";
            outStr += String.Join(";", daysDefault);
            if (defaultTemplate)
                outStr += $"\n{startDate.ToString("MM/dd/yyyy")}\n{endDate.ToString("MM/dd/yyyy")}";

            return outStr;
        }

        public static ScheduleTemplate FromOutputString(string s, string startUpPath)
        {
            s = s.Trim();
            ScheduleTemplate newTemplate = new ScheduleTemplate();

            string[] attributes = s.Split("\n");
            newTemplate.name = attributes[0].Trim();


            if (attributes[1].Trim() != "")
            {
                string[] scheduleObjs = attributes[1].Split("-");
                foreach (string objectString in scheduleObjs)
                {
                    string[] fileObjAttributes = objectString.Split(";");
                    string fileName = fileObjAttributes[0];
                    string time = fileObjAttributes[1];
                    ScheduleObject scheduleObject = new ScheduleObject();
                    scheduleObject.time = TimeOnly.ParseExact(time, "HHmm");
                    scheduleObject.path = fileName; //Path.Combine(startUpPath, fileName);
                    newTemplate.scheduleObjects.Add(scheduleObject);
                }
            }
            

            newTemplate.defaultTemplate = attributes[2].Trim() == "True";

            string[] defaultDaysTemplate = attributes[3].Split(";");

            for (int i = 0; i < defaultDaysTemplate.Length; i++)
            {
                newTemplate.daysDefault[i] = defaultDaysTemplate[i].Trim() == "True";
            }

            newTemplate.startDate = DateOnly.ParseExact(attributes[4], "MM/dd/yyyy");
            newTemplate.endDate = DateOnly.ParseExact(attributes[5], "MM/dd/yyyy");


            return newTemplate;
        }

        public string ToCSVString()
        {
            string output = name + ',';
            output += startDate.ToString() + ",";
            output += endDate.ToString() + ",";
            output += defaultTemplate;
            output += ",";

            foreach (bool day in daysDefault)
            {
                output += day + ",";
            }


            return output;
        }

        public static ScheduleTemplate FromFile(string filePath)
        {
            StreamReader fp = new StreamReader(filePath);
            string fileText = fp.ReadToEnd();
            fp.Close();

            return FromOutputString(fileText.Trim(), "");

        }

        public string getFileName()
        {
            string fileName = this.name;
            char[] invalid_chars = Path.GetInvalidFileNameChars();


            foreach (char c in invalid_chars)
            {
                fileName = fileName.Replace(c, '_');
            }

            return fileName + ".template";
        }

        public void ToFile(string fileName)
        {
            StreamWriter streamWriter = new StreamWriter(Path.Combine(BasicFunctionForm.template_path, fileName));
            streamWriter.Write(this.ToOutputString());
            streamWriter.Close();
            return;
        }

        public void insertScheduleObject(ScheduleObject so)
        {
            long ticks = 0;
            int index = 0;
            long soTicks = so.time.Ticks;
            if (so.nextDay)
            {
                soTicks += TimeSpan.TicksPerDay;
            }

            while (index < this.scheduleObjects.Count() && ticks < soTicks)
            {
                ticks = scheduleObjects[index].time.Ticks;
                if (scheduleObjects[index].nextDay)
                {
                    ticks += TimeSpan.TicksPerDay;
                }

                if (ticks > soTicks)
                {
                    scheduleObjects.Insert(index, so);
                    return;
                }

                index++;
            }
            scheduleObjects.Add(so);

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
