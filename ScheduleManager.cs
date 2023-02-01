using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWOC_Audio_Scheduler
{
    internal class ScheduleManager
    {
        public List<ScheduleTemplate> templates;
        public List<ScheduleObject> todaysExceptions;
        public List<TemplateDayException> templateDayExceptions;
        public List<WorkerPair> backgroundWorkers;
        public BasicFunctionForm parentForm;

        string logFilePath = "logfile.txt";
        StreamWriter streamWriter;

        public ScheduleManager()
        {
            WriteToLog("Begining Log File on " + DateTime.Now.ToString());
            templates = new List<ScheduleTemplate>();
            todaysExceptions = new List<ScheduleObject>();
            templateDayExceptions = new List<TemplateDayException>();
            backgroundWorkers = new List<WorkerPair>(); 
        }

        public void CreateNextDayEvents()
        {
            string outS = "";
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);

            for (int i = 0; i < templateDayExceptions.Count; i++)
            {
                if (templateDayExceptions[i].date == today)
                {
                    ScheduleTemplate template = templateDayExceptions[i].template;
                    CreateScheduleEvents(template);
                    CreateEndOfDayEvent();
                    return;
                }
            }

            for (int i = 0; i < templates.Count; i++)
            {
                if (templates[i].schedulesDay(today))
                {
                    ScheduleTemplate template = templates[i];
                    CreateScheduleEvents(template);
                    CreateEndOfDayEvent();
                    return;
                }
            }
        }

        private void CreateEndOfDayEvent()
        {
            BackgroundWorker nextDayWorker = new BackgroundWorker();
            nextDayWorker.DoWork += new DoWorkEventHandler(LoadNextDay);
            nextDayWorker.RunWorkerAsync(nextDayWorker);
        }

        private void CreateScheduleEvents(ScheduleTemplate template)
        {
            for (int j = 0; j < template.scheduleObjects.Count; j++)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
                WorkerPair pair = new WorkerPair();
                pair.worker = worker;
                pair.scheduleObject = template.scheduleObjects[j];
                worker.WorkerSupportsCancellation = true;
                backgroundWorkers.Add(pair);
                worker.RunWorkerAsync(pair);
            }
        }

        public void appendTemplate(ScheduleTemplate template)
        {
            templates.Add(template);
        }

        public void killWorker(ScheduleObject scheduleObject)
        {
            for (int i = 0; i < backgroundWorkers.Count; i++)
            {
                ScheduleObject so = backgroundWorkers[i].scheduleObject;
                BackgroundWorker worker = backgroundWorkers[i].worker;
                if (so.time == scheduleObject.time && so.path == scheduleObject.path)
                {
                    worker.CancelAsync();
                    so.ToggleDisabled();
                    WorkerPair newPair = new();
                    newPair.scheduleObject = so;
                    newPair.worker = worker;
                    backgroundWorkers[i] = newPair;
                }
            }
        }

        private void WaitUntilEventTime(object sender, DoWorkEventArgs args)
        {
            WorkerPair pair = (WorkerPair) args.Argument;
            ScheduleObject scheduleObject = pair.scheduleObject;
            TimeSpan sleepTime = scheduleObject.time.ToTimeSpan() - DateTime.Now.TimeOfDay;
            if (sleepTime.TotalMilliseconds > 0)
            {
                Thread.Sleep(sleepTime);
                if (!((BackgroundWorker) sender).CancellationPending)
                {
                    play_sound(scheduleObject.path);
                    WriteToLog(pair.scheduleObject.ToString() + "," + DateTime.Now.ToString());
                } else
                {
                    WriteToLog(pair.scheduleObject.ToString() + "," + DateTime.Now.ToString() + " ---DISABLED---");
                }
            }
        }

        public void CreateExceptionToday(string path, TimeOnly time)
        {
            ScheduleObject scheduleObject = new();
            scheduleObject.path = path;
            scheduleObject.time = time; 

            todaysExceptions.Add(scheduleObject);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
            WorkerPair pair = new WorkerPair();
            worker.WorkerSupportsCancellation = true;
            pair.worker = worker;
            pair.scheduleObject = scheduleObject;


            backgroundWorkers.Add(pair);
            worker.RunWorkerAsync(pair);
        }

        public void CreateTemplateDayException(ScheduleTemplate template, DateOnly day)
        {
            TemplateDayException exception = new TemplateDayException();
            exception.template = template;
            exception.date = day;

            templateDayExceptions.Add(exception);
        }

        private void LoadNextDay(object sender, DoWorkEventArgs args)
        {
            TimeSpan sleepTime = (new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay) + new TimeSpan(0, 0, 1);
            Thread.Sleep(sleepTime);
            this.CreateNextDayEvents();
            WriteToLog("New Day Loaded " + DateTime.Now);
        }

        private void play_sound(string path)
        {
            var audioFile = new Mp3FileReader(path);
            var outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.Play();

        }

        private void WriteToLog(string str)
        {
            string logFileFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), logFilePath);
            logFileFullPath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, logFilePath);

            if (!File.Exists(logFileFullPath))
            {
                streamWriter = new StreamWriter(logFileFullPath);
            } else
            {
                streamWriter = new StreamWriter(logFileFullPath, true);
            }
            streamWriter.WriteLine(str);
            streamWriter.Close();
        }
    }

    internal struct TemplateDayException
    {
        public DateOnly date;
        public ScheduleTemplate template;
    }

    internal struct DayScheduleException
    {
        // DateOnly day; // Will be needed for future functionality
        ScheduleObject scheduleObject;

        public DayScheduleException(TimeOnly time, string soundPath)
        {
            scheduleObject = new ScheduleObject(soundPath, time);
        }
    }

    internal struct WorkerPair
    {
        public WorkerPair()
        {
            worker = new BackgroundWorker();
            scheduleObject = new();
        }
        public BackgroundWorker worker;
        public ScheduleObject scheduleObject;
    }
}
