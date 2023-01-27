namespace CWOC_Audio_Scheduler;

class main
{
    public static void RunTest(string[] args)
    {
        ScheduleManager scheduleManager = new ScheduleManager();
        ScheduleObject scheduleObject = new ScheduleObject();
        scheduleObject.time = new TimeOnly(12, 45);
        scheduleObject.path = "C:\\Users\\cadet_admin\\source\\repos\\CWOC-Sound-Scheduler\\sounds\\ACQ.mp3";

        ScheduleTemplate scheduleTemplate = new ScheduleTemplate();
        for (int i = 0; i < scheduleTemplate.daysDefault.Count(); i++)
            scheduleTemplate.daysDefault[i] = true;

        scheduleTemplate.defaultTemplate = true;
        scheduleTemplate.scheduleObjects.Append(scheduleObject);
        scheduleManager.templates.Append(scheduleTemplate);
        scheduleManager.CreateNextEvent();
        Console.WriteLine("Done.");
    }
}