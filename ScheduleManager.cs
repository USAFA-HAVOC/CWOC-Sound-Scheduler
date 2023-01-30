using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWOC_Audio_Scheduler
{
    internal class ScheduleManager
    {
        public List<ScheduleTemplate> templates;
        public List<DayScheduleException> todaysExceptions;
        public List<TemplateDayException> templateDayExceptions;
        public List<WorkerPair> backgroundWorkers;

        string logFilePath = "logfile.txt";
        StreamWriter streamWriter;

        public ScheduleManager()
        {
            WriteToLog("Begining Log File on " + DateTime.Now.ToString());
            templates = new List<ScheduleTemplate>();
            todaysExceptions = new List<DayScheduleException>();
            templateDayExceptions = new List<TemplateDayException>();
            backgroundWorkers = new List<WorkerPair>(); 
        }

        public void CreateNextEvent()
        {
            string outS = "";
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            for (int i = 0; i < templates.Count; i++)
            {
                if (templates[i].schedulesDay(today))
                {
                    for (int j = 0; j < templates[i].scheduleObjects.Count; j++)
                    {
                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
                        WorkerPair pair = new WorkerPair();
                        pair.worker = worker;
                        pair.scheduleObject = templates[i].scheduleObjects[j];
                        backgroundWorkers.Add(pair);
                        worker.RunWorkerAsync(pair);
                    }
                    BackgroundWorker nextDayWorker = new BackgroundWorker();
                    nextDayWorker.DoWork += new DoWorkEventHandler(LoadNextDay);
                    nextDayWorker.RunWorkerAsync(nextDayWorker);
                    return;
                }
            }
        }
        public void appendTemplate(ScheduleTemplate template)
        {
            templates.Add(template);
        }

        public void killWorker(int index)
        {
            backgroundWorkers[index].worker.Dispose();
            backgroundWorkers.RemoveAt(index);
        }

        private void WaitUntilEventTime(object sender, DoWorkEventArgs args)
        {
            WorkerPair pair = (WorkerPair)args.Argument;
            ScheduleObject scheduleObject = pair.scheduleObject;
            TimeSpan sleepTime = scheduleObject.time.ToTimeSpan() - DateTime.Now.TimeOfDay;
            if (sleepTime.TotalMilliseconds > 0)
            {
                Thread.Sleep(sleepTime);
                play_sound(scheduleObject.path);
                WriteToLog(pair.scheduleObject.ToString() + "," + DateTime.Now.ToString());
            }
            pair.worker.Dispose();
        }

        private void CreateExceptionToday(string path, TimeOnly time)
        {
            ScheduleObject scheduleObject = new();
            scheduleObject.path = path;
            scheduleObject.time = time; 

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(WaitUntilEventTime);
            WorkerPair pair = new WorkerPair();
            pair.worker = worker;
            pair.scheduleObject = scheduleObject;
            backgroundWorkers.Add(pair);
            worker.RunWorkerAsync(scheduleObject);
        }


        private void LoadNextDay(object sender, DoWorkEventArgs args)
        {
            TimeSpan sleepTime = (new TimeSpan(23, 59, 59) - DateTime.Now.TimeOfDay) + new TimeSpan(0, 0, 1);
            Thread.Sleep(sleepTime);
            this.CreateNextEvent();
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
        TimeOnly time;
        string soundPath;

        public DayScheduleException(TimeOnly time, string soundPath)
        {
            this.time = time;
            this.soundPath = soundPath;
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
