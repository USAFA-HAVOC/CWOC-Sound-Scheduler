namespace CWOC_Audio_Scheduler;
using Microsoft.VisualBasic.ApplicationServices;

using Microsoft.VisualBasic.Devices;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
class WorkBench
{
    public static List<ScheduleTemplate> staticTemplates = new List<ScheduleTemplate>();

    public static void RunTest()
    {
        string path = "C:\\Users\\Kayleb\\source\\repos\\Audio Scheduler Head\\sounds\\ACQ.mp3";
        ScheduleManager scheduleManager = new ScheduleManager();

        ScheduleTemplate scheduleTemplate = new ScheduleTemplate();
        for (int i = 0; i < scheduleTemplate.daysDefault.Count(); i++)
            scheduleTemplate.daysDefault[i] = true;

        scheduleTemplate.defaultTemplate = true;

        ScheduleObject scheduleObject = new ScheduleObject(path, 16, 23);
        ScheduleObject scheduleObject1 = new ScheduleObject(path, 16, 24);

        scheduleTemplate.scheduleObjects.Add(scheduleObject);
        scheduleTemplate.scheduleObjects.Add(scheduleObject1);
        scheduleManager.appendTemplate(scheduleTemplate);
        scheduleManager.CreateNextEvent();
        int await = 1;
    }

    // Manually Building Templates before GUI support for this function
    // For the manual template building portion of this project, these functions will be stored into files
    // and read into the form on startup
    public static void BuildTemplates()
    {
        string soundPath = "C:\\Users\\Kayleb\\source\\repos\\Audio Scheduler Head\\sounds\\";

        /**
         * M/T/W/TH Academic Schedule
         **/
        ScheduleTemplate weekDayAcademicTemplate = new ScheduleTemplate();
        weekDayAcademicTemplate.name = "M/T/W/Th Academics";

        // Set as default for M-Th
        weekDayAcademicTemplate.defaultTemplate = true;
        weekDayAcademicTemplate.daysDefault[(int) DayOfWeek.Monday] = true;
        weekDayAcademicTemplate.daysDefault[(int)DayOfWeek.Tuesday] = true;
        weekDayAcademicTemplate.daysDefault[(int)DayOfWeek.Wednesday] = true;
        weekDayAcademicTemplate.daysDefault[(int)DayOfWeek.Thursday] = true;

        //Temporarily Adding for weekend testing
        weekDayAcademicTemplate.daysDefault[(int)DayOfWeek.Friday] = true;
        weekDayAcademicTemplate.daysDefault[(int)DayOfWeek.Saturday] = true;
        weekDayAcademicTemplate.daysDefault[(int)DayOfWeek.Sunday] = true;

        // Build Schedule of Calls
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Reveille and To the Colors.mp3", 7, 00));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 7,  30));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 8,  23));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 8,  30));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 9,  23));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 9,  30));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 10, 23));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 10, 30));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 11, 23));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 12, 45));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 13, 38));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 13, 45));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 14, 38));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 14, 45));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 15, 38));

        //ACQ and Taps
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "ACQ.mp3",  19, 15));
        weekDayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "TAPS.mp3", 23, 00));

        staticTemplates.Add(weekDayAcademicTemplate);

        /**
         * Friday Schedule (Same as above, but no ACQ or TAPS)
         */
        ScheduleTemplate fridayAcademicTemplate = new ScheduleTemplate();
        fridayAcademicTemplate.name = "Friday Academics";

        // Set as default for Friday
        fridayAcademicTemplate.defaultTemplate = true;
        fridayAcademicTemplate.daysDefault[(int)DayOfWeek.Friday] = true;
        
        // Build Schedule
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Reveille and To the Colors.mp3", 7, 00));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 7, 30));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 8, 23));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 8, 30));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 9, 23));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 9, 30));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 10, 23));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 10, 30));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 11, 23));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 12, 45));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 13, 38));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 13, 45));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 14, 38));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 14, 45));
        fridayAcademicTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "Assembly.mp3", 15, 38));

        staticTemplates.Add(fridayAcademicTemplate);

        /**
         * Saturday: only TAPS for friday
         */
        ScheduleTemplate blueSaturdayTemplate = new ScheduleTemplate();
        blueSaturdayTemplate.defaultTemplate = true;
        blueSaturdayTemplate.daysDefault[(int)DayOfWeek.Saturday] = true;
        blueSaturdayTemplate.name = "Saturday: Blue";

        blueSaturdayTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "TAPS.mp3", 01, 30));

        staticTemplates.Add(blueSaturdayTemplate);

        /**
         * Sunday: TAPS for saturday, ACQ, and taps again
         */
        ScheduleTemplate sundayTemplate = new ScheduleTemplate();
        sundayTemplate.defaultTemplate = true;
        sundayTemplate.daysDefault[(int)DayOfWeek.Sunday] = true;
        sundayTemplate.name = "Sunday";

        sundayTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "TAPS.mp3", 01, 30));
        sundayTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "ACQ.mp3",  19, 15));
        sundayTemplate.scheduleObjects.Add(new ScheduleObject(soundPath + "TAPS.mp3", 23, 00));

        staticTemplates.Add(sundayTemplate);

    }

}